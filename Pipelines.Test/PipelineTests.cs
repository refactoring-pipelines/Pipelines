using ApprovalTests;
using ApprovalTests.Reporters;
using ApprovalTests.Writers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pipelines.Test
{
    [UseReporter(typeof(VisualStudioReporter))]
    [TestClass]
    public class PipelineTests
    {
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
        public void ConnectedPipelinesTest()
        {
            var input = new InputPipe<string>("age");
            var parsePipe = input.Process(long.Parse);
            var collector = parsePipe.Collect();
            parsePipe.Process(LongToString).WithCollector().Process(long.Parse).WithCollector().Process(LongToString).Collect();

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
            input.Send("42");
            Assert.AreEqual("(42, 43)", joinedPipes.SingleResult.ToString());
        }

        private string LongToString(long value)
        {
            return value.ToString();
        }

        long IncrementLong(long value)
        {
            return value + 1;}

        private static void Verify(InputPipe<string> input)
        {
            Approvals.Verify(WriterFactory.CreateTextWriter(DotGraph.FromPipeline(input), "dot"));
        }
    }

    static class _
    {
        public static FunctionPipe<TInput, TOutput> WithCollector<TInput, TOutput>(
            this FunctionPipe<TInput, TOutput> @this)
        {
            @this.Collect();
            return @this;
        }

    }

}