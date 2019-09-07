using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ApprovalTests.Reporters;
using ApprovalTests.Reporters.TestFrameworks;
using ApprovalTests.Reporters.Windows;
using ApprovalUtilities.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring.Pipelines.Approvals;
using Refactoring.Pipelines.DotGraph;


namespace Refactoring.Pipelines.Test
{
    [UseReporter(typeof(DotReporter))]
    [TestClass]
    public class InputsAndOutputsBasicTests
    {
        [TestMethod]
        public void SingleBranchPipe()
        {
            var input = new InputPipe<int>("input");
            var middle = input.Process(p => p + 1);
            var end = middle.Process(p => p.ToString()).Collect();

            var inputsAndOutputs = middle.GetInputsAndOutputs();
            CollectorPipe<string> collectorPipe = (CollectorPipe<string>)inputsAndOutputs.Outputs.Single();
            InputPipe<int> inputPipe = (InputPipe<int>) inputsAndOutputs.Inputs.Single();

            Assert.AreEqual(input, inputPipe);
            Assert.AreEqual(end, collectorPipe);
            inputPipe.Send(1);
            var singleResult = collectorPipe.SingleResult;
            Assert.AreEqual("2", singleResult);
        }

        //[TestMethod]
        //public void MultipleBranchesPipe()
        //{
        //    var input1 = new InputPipe<int>("input1");
        //    var input2 = new InputPipe<int>("input2");
        //    var joinedPipes = input1.JoinTo(input2);
        //    var sumCollector = joinedPipes.Process((a, b) => a + b).Collect();
        //    var productCollector = joinedPipes.Process((a, b) => a * b).Collect();

        //    var inputsAndOutputs = joinedPipes.GetInputsAndOutputs<int, int, Tuple<int, int>>();


        //    ((InputPipe<int>) (inputsAndOutputs.Inputs[0])).Send(3);
        //    ((InputPipe<int>) (inputsAndOutputs.Inputs[1])).Send(4);

        //    Assert.AreEqual(7, ((CollectorPipe<int>) inputsAndOutputs.Outputs[0]).SingleResult);
        //    Assert.AreEqual(12, ((CollectorPipe<int>) inputsAndOutputs.Outputs[1]).SingleResult);
        //}
    }

    internal static class __
    {
        public static InputsAndOutputs GetInputsAndOutputs(this IGraphNode node) { return new InputsAndOutputs(node); }
    }

    public class InputsAndOutputs
    {
        private readonly IGraphNode _node;

        public InputsAndOutputs(IGraphNode node)
        {
            _node = node;
            Inputs.AddRange(IGraphNodeHelper.GetRoots(_node));
            Outputs.AddRange(IGraphNodeHelper.GetOutputs(_node));
        }

        public List<IGraphNode> Inputs = new List<IGraphNode>();
        public List<IGraphNode> Outputs = new List<IGraphNode>();
    }
}
