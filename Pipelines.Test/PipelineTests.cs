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
            var uppercase = input.Process(long.Parse);
            var collector = uppercase.Collect();

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

        private string LongToString(long value)
        {
            return value.ToString();
        }

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