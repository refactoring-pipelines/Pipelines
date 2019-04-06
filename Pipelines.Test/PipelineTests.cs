using ApprovalTests;
using ApprovalTests.Writers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pipelines.Test
{
    //[UseReporter(typeof(VisualStudioReporter))]
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

        private static void Verify(InputPipe<string> input)
        {
            Approvals.Verify(WriterFactory.CreateTextWriter($@"
digraph G {{
node [style=filled, shape=rec]

{input}
}}".Trim(), "dot"));
        }
    }
}