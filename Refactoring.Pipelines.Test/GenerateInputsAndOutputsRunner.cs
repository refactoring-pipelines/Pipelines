using System.IO;
using System.Linq;
using System.Text;
using ApprovalTests;
using ApprovalTests.Reporters;
using ApprovalUtilities.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            result.Append(generator);
            Approvals.Verify(result);
        }

        [TestMethod]
        public void GenerateInputsExtensions()
        {
            var inputCount = 2;
            var generator = new InputsExtensionsGenerator(inputCount);
            var result = new StringBuilder();
            result.Append(generator);
            Approvals.Verify(result);
        }

        [TestMethod]
        public void GenerateInputs()
        {
            var inputCount = 1;
            var outputCounts = new[] {1, 2};
            var generator = new InputsGenerator(inputCount, outputCounts);
            var result = new StringBuilder();
            result.Append(generator);
            Approvals.Verify(result);
        }


        [TestMethod]
        [Ignore("This writes to a file that gets compiled, which can create a loop or slowness. Only run manually.")]
        public void GenerateAll()
        {
            var result = new StringBuilder();
            result.AppendLine("using System;");
            result.AppendLine("using System.Collections.Generic;");
            result.AppendLine("using ApprovalUtilities.Utilities;");

            for (var inputCount = 1; inputCount <= 6; inputCount++)
            {
                result.Append(new InputsExtensionsGenerator(inputCount));
                result.Append(new InputsGenerator(inputCount, Enumerable.Range(1, 4)));
                for (var outputCount = 1; outputCount <= 6; outputCount++)
                {
                    result.Append(new InputsAndOutputsGenerator(inputCount, outputCount));
                }
            }

            Approvals.Verify(result);

            var sourceFilePath =
                PathUtilities.GetAdjacentFile(@"..\Refactoring.Pipelines\InputsAndOutputs\Generated.cs");
            File.WriteAllText(sourceFilePath, result.ToString());
        }
    }
}
