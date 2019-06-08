using System;
using System.Collections.Generic;
using System.Linq;
using ApprovalTests;
using ApprovalTests.Reporters;
using ApprovalTests.Writers;
using ApprovalUtilities.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pipelines.Test
{
    [UseReporter(typeof(VisualStudioReporter))]
    [TestClass]
    public class PipelineTests
    {
        [TestMethod]
        public void BasicPipelineFunctionalTest()
        {
            Func<string, long> normal = age =>
            {
                // startcode basic_code_line 
                var result = long.Parse(age);
                // endcode 
                return result;
            };
            Func<string, long> piped = age =>
            {
                // startcode basic_pipeline
                var inputPipe = new InputPipe<string>("age");
                var parsePipe = inputPipe.Process(long.Parse);
                var collector = parsePipe.Collect();

                inputPipe.Send("42");
                var result = collector.SingleResult;
                // endcode
                return result;
            };

            Assert.AreEqual(normal("42"), piped("42"));
        }

        [TestMethod]
        public void BasicPipelineTest()
        {
            var input = new InputPipe<string>("age");
            var parse = input.Process(long.Parse);
            var collector = parse.Collect();

            Verify(input);
            input.Send("42");
            Assert.AreEqual(42, collector.SingleResult);
        }

        [TestMethod]
        public void ProcessIsNotCovariant()
        {
            var input = new InputPipe<int>("i");
            var collector = input
                .Process(RangeArray)
                .Process(_ => (IEnumerable<int>) _) // Would be nice not to need this
                .Process(SumEnumerable)
                .Collect();
            input.Send(4);
            Assert.AreEqual(10, collector.SingleResult);
        }

        private int SumEnumerable(IEnumerable<int> _)
        {
            return _.Sum();
        }

        private int[] RangeArray(int count)
        {
            return Enumerable.Range(1, count).ToArray();
        }

        [TestMethod]
        public void ConnectedPipelinesTest()
        {
            var input = new InputPipe<string>("age");
            var parsePipe = input.Process(long.Parse);
            var collector = parsePipe.Collect();
            parsePipe.Process(LongToString).WithCollector().Process(long.Parse).WithCollector().Process(LongToString)
                .Collect();

            Verify(input);
        }

        [TestMethod]
        public void SplitAndJoin()
        {
            var input = new InputPipe<string>("age");
            var parse = input.Process(long.Parse);
            var longToString = parse.Process(LongToString);
            var incrementLong = parse.Process(IncrementLong);

            var joinedPipes = longToString.JoinTo(incrementLong).Collect();

            Verify(input);
        }

        [TestMethod]
        public void SplitInput()
        {
            var input = new InputPipe<long>("value");
            input.Process(LongToString);
            input.Process(IncrementLong);

            Verify(input);
        }

        [TestMethod]
        public void JoinInputs()
        {
            // startcode joined_pipeline 
            var input1 = new InputPipe<long>("value1");
            var input2 = new InputPipe<long>("value2");
            var join = input1.JoinTo(input2);
            // endcode
            var collector = join.Collect();

            input1.Send(42);
            Assert.IsTrue(collector.IsEmpty);

            input2.Send(99);
            Assert.AreEqual("(42, 99)", collector.SingleResult.ToString());

            Verify(join);
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

            var result = prefix.ApplyTo(values);
            var collector = result.Collect();

            prefix.Send("#");
            values.Send(new[] {1, 2});
            Assert.AreEqual("[(#, 1), (#, 2)]", collector.SingleResult.ToReadableString());

            Verify(result);
        }

        private string LongToString(long value)
        {
            return value.ToString();
        }

        private long IncrementLong(long value)
        {
            return value + 1;
        }

        private static void Verify(IGraphNode input)
        {
            Approvals.Verify(WriterFactory.CreateTextWriter(DotGraph.FromPipeline(input), "dot"));
        }
    }

    internal static class _
    {
        public static FunctionPipe<TInput, TOutput> WithCollector<TInput, TOutput>(
            this FunctionPipe<TInput, TOutput> @this)
        {
            @this.Collect();
            return @this;
        }
    }
}