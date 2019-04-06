using ApprovalTests;
using ApprovalTests.Writers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pipelines.Test
{
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