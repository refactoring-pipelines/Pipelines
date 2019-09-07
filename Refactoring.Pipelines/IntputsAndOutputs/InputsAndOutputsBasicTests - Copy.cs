using System;
using System.Linq;

namespace Refactoring.Pipelines.IntputsAndOutputs
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

    public class Inputs1AndOutputs1<TInput1, TOutput1>
    {
        private readonly InputsAndOutputs _inputsAndOutputs;

        public Inputs1AndOutputs1(IGraphNode node) { this._inputsAndOutputs = new InputsAndOutputs(node); }

        public InputPipe<TInput1> Input
        {
            get
            {
                return (InputPipe<TInput1>) this._inputsAndOutputs.Inputs.Single();
            }
        }

        public CollectorPipe<TOutput1> Output
        {
            get
            {
                return (CollectorPipe<TOutput1>) this._inputsAndOutputs.Outputs.Single();
            }
        }

        public Tuple<InputPipe<TInput1>, CollectorPipe<TOutput1>> AsTuple() { return Tuple.Create(Input, Output); }

        public void Send(TInput1 value1) { this.Input.Send(value1); }
    }
}
