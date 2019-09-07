namespace Refactoring.Pipelines.InputsAndOutputs
{
    public static class Inputs1AndOutputs1Extensions
    {
        public static Inputs<TInput1> GetInputs<TInput1>(this IGraphNode node) { return new Inputs<TInput1>(node); }
    }

    public class Inputs<T>
    {
        private readonly IGraphNode _node;
        public Inputs(IGraphNode node) { this._node = node; }

        public Inputs1AndOutputs1<T, TOutput1> AndOutputs<TOutput1>()
        {
            return new Inputs1AndOutputs1<T, TOutput1>(this._node);
        }
    }
}
