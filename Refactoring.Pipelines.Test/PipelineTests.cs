using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using ApprovalTests;
using ApprovalTests.Reporters;
using ApprovalUtilities.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring.Pipelines.ApprovalTests;
using Refactoring.Pipelines.DotGraph;

namespace Refactoring.Pipelines.Test
{
    [UseReporter(typeof(DiffReporter))]
    [TestClass]
    public class PipelineTests
    {
        [TestMethod]
        public void BasicPipelineFunctionalTest()
        {
            Func<string, long> normal = age =>
            {
                // begin-snippet: basic_code_line
                var result = long.Parse(age);
                // end-snippet
                return result;
            };
            Func<string, long> piped = age =>
            {
                // begin-snippet: basic_pipeline
                var inputPipe = new InputPipe<string>("age");
                var parsePipe = inputPipe.ProcessFunction(long.Parse);
                var collector = parsePipe.Collect();

                inputPipe.Send("42");
                var result = collector.SingleResult;
                // end-snippet
                return result;
            };

            Assert.AreEqual(normal("42"), piped("42"));
        }

        [TestMethod]
        public void BasicPipelineTest()
        {
            var input = new InputPipe<string>("age");
            var parse = input.ProcessFunction(long.Parse);
            var collector = parse.Collect();

            PipelineApprovals.Verify(input);
            input.Send("42");
            Assert.AreEqual(42, collector.SingleResult);
        }

        [TestMethod]
        public void ProcessIsNotCovariant()
        {
            var input = new InputPipe<int>("i");
            var collector = input.ProcessFunction(RangeArray)
                .ProcessFunction(_ => (IEnumerable<int>) _) // Would be nice not to need this
                .ProcessFunction(SumEnumerable)
                .Collect();
            input.Send(4);
            Assert.AreEqual(10, collector.SingleResult);
        }

        private int SumEnumerable(IEnumerable<int> _) { return _.Sum(); }

        private int[] RangeArray(int count) { return Enumerable.Range(1, count).ToArray(); }

        [TestMethod]
        public void ConnectedPipelinesTest()
        {
            var input = new InputPipe<string>("age");
            var parsePipe = input.ProcessFunction(long.Parse);
            var collector = parsePipe.Collect();
            parsePipe.ProcessFunction(LongToString)
                .WithCollector()
                .ProcessFunction(long.Parse)
                .WithCollector()
                .ProcessFunction(LongToString)
                .Collect();

            PipelineApprovals.Verify(input);
        }

        [TestMethod]
        public void SplitAndJoin()
        {
            var input = new InputPipe<string>("age");
            var parse = input.ProcessFunction(long.Parse);
            var longToString = parse.ProcessFunction(LongToString);
            var incrementLong = parse.ProcessFunction(IncrementLong);

            var joinedPipes = longToString.JoinTo(incrementLong).Collect();

            PipelineApprovals.Verify(input);
        }

        [TestMethod]
        public void SplitInput()
        {
            var input = new InputPipe<long>("value");
            input.ProcessFunction(LongToString);
            input.ProcessFunction(IncrementLong);

            PipelineApprovals.Verify(input);
        }

        [TestMethod]
        public void JoinInputs()
        {
            var input1 = new InputPipe<long>("value1");
            var input2 = new InputPipe<long>("value2");
            var join = input1.JoinTo(input2);
            var collector = join.ProcessFunction(Echo).Collect();

            input1.Send(42);
            Assert.IsTrue(collector.IsEmpty);

            input2.Send(99);
            Assert.AreEqual("(42, 99)", collector.SingleResult.ToString());

            PipelineApprovals.Verify(join);
        }

        [TestMethod]
        public void MultipleParameters()
        {
            var input1 = new InputPipe<long>("value1");
            var input2 = new InputPipe<long>("value2");
            var join = input1.JoinTo(input2);
            var collector = join.Process((a, b) => a + b).Collect();

            input1.Send(3);
            Assert.IsTrue(collector.IsEmpty);

            input2.Send(4);
            Assert.AreEqual(7, collector.SingleResult);

            PipelineApprovals.Verify(join);
        }

        [TestMethod]
        public void Flatten()
        {
            var input1 = new InputPipe<long>("value1");
            var input2 = new InputPipe<long>("value2");
            var join = input1.JoinTo(input2);
            var input3 = new InputPipe<long>("value3");

            Sender<Tuple<long, long, long>> all = join.JoinTo(input3).Flatten();
            var collector = all.Collect();

            input1.Send(1);
            input2.Send(2);
            input3.Send(3);

            Assert.AreEqual("(1, 2, 3)", collector.SingleResult.ToString());

            PipelineApprovals.Verify(collector);
        }

        [TestMethod]
        public void JoinInputsSample()
        {
            // begin-snippet: joined_pipeline
            var input1 = new InputPipe<long>("value1");
            var input2 = new InputPipe<long>("value2");
            var join = input1.JoinTo(input2);
            // end-snippet

            PipelineApprovals.Verify(join);
        }

        [TestMethod]
        public void CannotFindNodeExceptionHelpMessage()
        {
            var input1 = new InputPipe<long>("value1");
            var subject = new NodeMetadata.CannotFindNodeException(input1);
            Approvals.Verify(subject);
        }

        [TestMethod]
        public void ApplyTo()
        {
            var prefix = new InputPipe<string>("prefix");
            var values = new InputPipe<int[]>("values");

            var applyToPipeline = prefix.ApplyTo(values);
            var collector = applyToPipeline.Collect();
            PipelineApprovals.Verify(applyToPipeline);

            // begin-snippet: ApplyTo_inputs
            var apply = "#";
            var to = new[] {1, 2};
            // end-snippet

            // begin-snippet: ApplyTo_outputs
            var result = "[(#, 1), (#, 2)]";
            // end-snippet

            var manualApplyTo =
                // begin-snippet: ApplyTo_manual
                prefix.JoinTo(values).ProcessFunction(t => t.Item2.Select(i => Tuple.Create(t.Item1, i)));
            // end-snippet
            var manualApplyToResult = manualApplyTo.Collect();

            prefix.Send(apply);
            values.Send(to);
            Assert.AreEqual(result, collector.SingleResult.ToReadableString());

            Assert.AreEqual(
                manualApplyToResult.SingleResult.ToReadableString(),
                collector.SingleResult.ToReadableString());
        }

        [TestMethod]
        public void Concat()
        {
            var part1 = new InputPipe<List<int>>("part1");
            var part2 = new InputPipe<int[]>("part2");
            var concatWithPipeline = part1.ConcatWith(part2);
            var collector = concatWithPipeline.Collect();
            PipelineApprovals.Verify(concatWithPipeline);

            // begin-snippet: ConcatWith_inputs
            var concat = new List<int> {1, 2};
            var with = new[] {3, 4};
            // end-snippet

            // begin-snippet: ConcatWith_outputs
            var result = "[1, 2, 3, 4]";
            // end-snippet

            var manualConcatWith =
                // begin-snippet: ConcatWith_manual
                part1.JoinTo(part2).ProcessFunction(t => t.Item1.Concat(t.Item2).ToList());
            // end-snippet
            var manualConcatWithResult = manualConcatWith.Collect();

            part1.Send(concat);
            part2.Send(with);
            Assert.AreEqual(result, collector.SingleResult.ToReadableString());

            Assert.AreEqual(
                manualConcatWithResult.SingleResult.ToReadableString(),
                collector.SingleResult.ToReadableString());
        }

        [TestMethod]
        public void ForEach()
        {
            var part1 = new InputPipe<List<long>>("part1");
            var collector = part1.ProcessForEach(IncrementLong).Collect();
            part1.Send(new List<long> {1, 2});
            Assert.AreEqual("[2, 3]", collector.SingleResult.ToReadableString());

            PipelineApprovals.Verify(part1);
        }

        [TestMethod]
        public void Lambda()
        {
            // begin-snippet: process_lambda
            var input = new InputPipe<int>("input");
            input.Process(p => p.ToString());
            // end-snippet

            PipelineApprovals.Verify(input);
        }

        [TestMethod]
        public void MyTestMethod()
        {
            var methods = QueryMethodsFromAssembly<ISender>();

            //var methodsWhichReturnStrings = methods.Where(_ => _.ReturnType == typeof(string));
            //methods = methods.Where(_ => _.GetParameters().Length >= 1);
            //methods = methods.OrderBy(_ => _.GetParameters().Length);

            //methods = methods.Where(_ => _.GetParameters().All(parameterInfo => parameterInfo.ParameterType.IsPrimitive));

            //methods = methods.Where(_ => _.ReturnType.Assembly != typeof(ISender).Assembly);
            methods = methods.Where(_ => _.ToCodeMetics().LinesOfCode > 1000)

            Approvals.VerifyAll(methods, method => Visualizer.Of(method));
            methods.Visualize();
        }

        private static IEnumerable<MethodInfo> QueryMethodsFromAssembly(object instance)
        {
            return QueryMethodFromAssembly(instance.GetType());
        }

        private static IEnumerable<MethodInfo> QueryMethodsFromAssembly<T>()
        {
            return QueryMethodFromAssembly(typeof(T));
        }

        private static IEnumerable<MethodInfo> QueryMethodFromAssembly(Type type)
        {
            var methods = type.Assembly.GetTypes()
                .SelectMany(
                    _ => _.GetMethods(
                        BindingFlags.Instance
                        | BindingFlags.Static
                        | BindingFlags.Public
                        | BindingFlags.NonPublic
                        | BindingFlags.DeclaredOnly));

            Predicate<MethodInfo> isClosure = methodInfo => Attribute.IsDefined(
                methodInfo.DeclaringType,
                typeof(CompilerGeneratedAttribute));

            Predicate<MethodInfo> isFoo = methodInfo => Attribute.IsDefined(
                methodInfo,
                typeof(CompilerGeneratedAttribute));

            methods = methods.Where(_ => !isClosure(_)).Where(_ => !isFoo(_));
            return methods;
        }


        private string LongToString(long value) { return value.ToString(); }

        private long IncrementLong(long value) { return value + 1; }

        private T Echo<T>(T t) { return t; }
    }


    public static class Visualizer
    {
        static List<IVisualizer> visualizers = new List<IVisualizer>
        {
            new MethodInfoVisualizer(), new MethodNameVisualizer(),
        };

        public static string Of(object instance)
        {
            return visualizers.First(_ => _.IsValidFor(instance)).Visualize(instance);
        }

        public static string Visualize(this object instance) { return Of(instance).Visualize(); }
    }

    internal class MethodInfoVisualizer : IVisualizer
    {
        public bool IsValidFor(object instance) { return instance is MethodInfo; }

        public string Visualize(object instance)
        {
            var methodInfo = (MethodInfo) instance;
            var parameters = methodInfo.GetParameters().JoinStringsWith(_ => $"{_.ParameterType.Name} {_.Name}", ", ");
            return $"{methodInfo.ReturnType.Name} {methodInfo.DeclaringType.Name}.{methodInfo.Name} ({parameters})";
        }
    }


    public static class _
    {
        public static FunctionPipe<TInput, TOutput> WithCollector<TInput, TOutput>(
            this FunctionPipe<TInput, TOutput> @this)
        {
            @this.Collect();
            return @this;
        }
    }
}
