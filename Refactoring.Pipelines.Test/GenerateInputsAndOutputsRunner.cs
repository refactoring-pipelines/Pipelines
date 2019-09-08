using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApprovalTests;
using ApprovalTests.Reporters;
using ApprovalUtilities.Utilities;

namespace Refactoring.Pipelines.Test
{
    [TestClass]
    [UseReporter(typeof(DiffReporter))]
    public class GenerateInputsAndOutputsRunner
    {
        [TestMethod]
        public void MyTestMethod()
        {
            var inputCount = 2;
            var outputCount = 2;
            var subject = new InputsAndOutputsGenerator(inputCount, outputCount);
            Approvals.Verify(subject);
        }
    }
}
