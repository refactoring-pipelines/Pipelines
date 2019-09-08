using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApprovalTests;
using ApprovalTests.Core;
using ApprovalTests.Reporters;

namespace Refactoring.Pipelines.Test
{
    [TestClass]
    [UseReporter(typeof(DiffReporter))]
    public class GenerateInputsAndOutputsRunner
    {
        [TestMethod]
        public void GenerateInputsAndOutputs()
        {
            var inputCount = 2;
            var outputCount = 2;
            var subject = new InputsAndOutputsGenerator(inputCount, outputCount);
            Approvals.Verify(subject);
        }

        [TestMethod]
        public void GenerateInputsExtensions()
        {
            var inputCount = 2;
            var subject = new InputsExtensionsGenerator(inputCount);
            Approvals.Verify(subject);
        }

        [TestMethod]
        public void GenerateInputs()
        {
            var inputCount = 1;
            var outputCounts = new[] {1, 2};
            var subject = new InputsGenerator(inputCount, outputCounts);
            Approvals.Verify(subject);
        }
    }
}
