using System;
using ApprovalTests.Reporters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring.Pipelines.ApprovalTests;
using Refactoring.Pipelines.InputsAndOutputs;

namespace Refactoring.Pipelines.Test
{
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
            var (in1, in2, sum, product) = inputsAndOutputs.AsTuple();


            Assert.AreEqual(7, sum.SingleResult);
            Assert.AreEqual(12, product.SingleResult);

            var (in1_, in2_) = inputsAndOutputs.Inputs;
            Assert.AreEqual(in1_, in1);
            Assert.AreEqual(in2_, in2);

            var (out1_, out2_) = inputsAndOutputs.Outputs;
            Assert.AreEqual(out1_, sum);
            Assert.AreEqual(out2_, product);
        }

        [TestMethod]
        public void MultipleJoinedBranches()
        {
            var input1 = new InputPipe<int>("input1");
            var numbers1 = input1.Process(i1 => i1);
            var numbers2 = input1.Process(i2 => i2);

            var joinedPipes = numbers1.JoinTo(numbers2);
            var addPipe = joinedPipes.Process((a, b) => a + b);
            var collector = addPipe.Collect();

            AssertInputsAndOutputs(input1, input1, collector);
            AssertInputsAndOutputs(numbers1, input1, collector);
            AssertInputsAndOutputs(numbers2, input1, collector);
            AssertInputsAndOutputs(joinedPipes, input1, collector);
            AssertInputsAndOutputs(addPipe, input1, collector);
            AssertInputsAndOutputs(collector, input1, collector);
        }

        private static void AssertInputsAndOutputs(IGraphNode startingPoint, IGraphNode input1, IGraphNode output1)
        {
            var endPoints = startingPoint.GetInputs<int>().AndOutputs<int>();

            Assert.AreEqual(input1, endPoints.Input1);
            Assert.AreEqual(output1, endPoints.Output1);
        }
    }
}
