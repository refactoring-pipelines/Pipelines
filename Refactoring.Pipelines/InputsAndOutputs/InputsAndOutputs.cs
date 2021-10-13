using System.Collections.Generic;
using ApprovalUtilities.Utilities;

namespace Refactoring.Pipelines.InputsAndOutputs
{
    public static class InputsAndOutputsExtensions
    {
        public static InputsAndOutputs GetInputsAndOutputs(this IGraphNode node) { return new InputsAndOutputs(node); }
        public static List<TOutput1> SendAll<TInput1, TOutput1>(this Inputs1AndOutputs1<TInput1, TOutput1> pipeline, IEnumerable<TInput1> inputs)
        {
            inputs.ForEach(pipeline.Send);
            return pipeline.Output1.Results;
        }
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
