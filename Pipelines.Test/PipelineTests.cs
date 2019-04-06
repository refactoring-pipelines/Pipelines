using System;
using ApprovalTests;
using ApprovalTests.Writers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pipelines;

namespace Pipelines.Test
{
    [TestClass]
    public class PipelineTests
    {
        [TestMethod]
        public void BasicPipelineTest()
        {
            var input = new InputPipe<string>("age");
            var uppercase = input.Process(Int64.Parse);
            var collector = uppercase.Collect();

            Verify(input);
        }

        private static void Verify(InputPipe<string> input)
        {
            
            Approvals.Verify(WriterFactory.CreateTextWriter("digraph G {" + input + "}", "dot"));
        }

        public static string ToUpper(string s)
        {
            return s.ToUpper();
        }
}
}
