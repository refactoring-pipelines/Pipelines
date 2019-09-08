using System;
using System.Text;
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
            var generator = new InputsAndOutputsGenerator(inputCount, outputCount);
            var result = new StringBuilder();
            result.Append(generator.ToString());
            Approvals.Verify(result);
        }

        [TestMethod]
        public void GenerateInputsExtensions()
        {
            var inputCount = 2;
            var generator = new InputsExtensionsGenerator(inputCount);
            var result = new StringBuilder();
            result.Append(generator.ToString());
            Approvals.Verify(result);
        }

        [TestMethod]
        public void GenerateInputs()
        {
            var inputCount = 1;
            var outputCounts = new[] {1, 2};
            var generator = new InputsGenerator(inputCount, outputCounts);
            var result = new StringBuilder();
            result.Append(generator.ToString());
            Approvals.Verify(result);
        }
    }
}
