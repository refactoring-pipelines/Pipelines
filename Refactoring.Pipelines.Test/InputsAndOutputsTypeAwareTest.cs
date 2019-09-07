using System;
using ApprovalTests.Reporters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring.Pipelines.Approvals;
using Refactoring.Pipelines.InputsAndOutputs;

namespace Refactoring.Pipelines.Test
{
    [UseReporter(typeof(DotReporter))]
    [TestClass]
    public class InputsAndOutputsTypeAwareTest
    {
        [TestMethod]
        public void SingleBranchPipe()
        {
            var input = new InputPipe<int>("input");
            var middle = input.Process(p => p + 1);
            var end = middle.Process(p => p.ToString()).Collect();

            var inputsAndOutputs = middle.GetInputs<int>().AndOutputs<string>();
            var (inputPipe, collectorPipe) = inputsAndOutputs.AsTuple();

            Assert.AreEqual(input, inputPipe);
            Assert.AreEqual(end, collectorPipe);
            inputsAndOutputs.Send(1);
            var singleResult = collectorPipe.SingleResult;
            Assert.AreEqual("2", singleResult);
        }

        [TestMethod]
        public void MultipleBranchesPipe()
        {
            var input1 = new InputPipe<int>("input1");
            var input2 = new InputPipe<int>("input2");
            var joinedPipes = input1.JoinTo(input2);
            var sumCollector = joinedPipes.Process((a, b) => a + b).Collect();
            var productCollector = joinedPipes.Process((a, b) => a * b).Collect();

            var inputsAndOutputs = joinedPipes.GetInputs<int, int>().AndOutputs<int, int>();

            inputsAndOutputs.Send(3, 4);
            var (_, __, sum, product) = inputsAndOutputs.AsTuple();


            Assert.AreEqual(7, sum.SingleResult);
            Assert.AreEqual(12, product.SingleResult);
        }
    }
}
