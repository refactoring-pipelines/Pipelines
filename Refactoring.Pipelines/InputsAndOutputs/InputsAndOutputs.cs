using System.Collections.Generic;

namespace Refactoring.Pipelines.InputsAndOutputs
{
    public static class InputsAndOutputsExtensions
    {
        public static InputsAndOutputs GetInputsAndOutputs(this IGraphNode node) { return new InputsAndOutputs(node); }
    }

    public class InputsAndOutputs
    {
        private readonly IGraphNode _node;

        public List<IGraphNode> Inputs = new List<IGraphNode>();
        public List<IGraphNode> Outputs = new List<IGraphNode>();

        public InputsAndOutputs(IGraphNode node)
        {
            _node = node;
            Inputs.AddRange(IGraphNodeHelper.GetRoots(_node));
            Outputs.AddRange(IGraphNodeHelper.GetOutputs(_node));
        }
    }
}
