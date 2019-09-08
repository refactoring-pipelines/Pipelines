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
            var subject = new InputsAndOutputsGenerator(2, 2);
            Approvals.Verify(subject);
        }
    }
}
