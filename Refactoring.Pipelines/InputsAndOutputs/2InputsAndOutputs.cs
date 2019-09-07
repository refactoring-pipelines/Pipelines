using System.Linq;

namespace Refactoring.Pipelines.InputsAndOutputs
{
    public static class Inputs2AndOutputs1Extensions
    {
        public static Inputs<TInput1, TInput2> GetInputs<TInput1, TInput2>(this IGraphNode node)
        {
            return new Inputs<TInput1, TInput2>(node);
        }
    }

    public class Inputs<TInput1, TInput2>
    {
        private readonly IGraphNode _node;
        public Inputs(IGraphNode node) { this._node = node; }

        public Inputs2AndOutputs2<TInput1, TInput2, TOutput1, TOutput2> AndOutputs<TOutput1, TOutput2>()
        {
            return new Inputs2AndOutputs2<TInput1, TInput2, TOutput1, TOutput2>(this._node);
        }
    }
}
