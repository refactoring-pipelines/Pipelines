using System;
using System.Diagnostics;
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

    public class Inputs2AndOutputs2<TInput1, TInput2, TOutput1, TOutput2>
    {
        private readonly InputsAndOutputs _inputsAndOutputs;

        public Inputs2AndOutputs2(IGraphNode node)
        {
            this._inputsAndOutputs = new InputsAndOutputs(node);
            Debug.Assert(_inputsAndOutputs.Inputs.Count == 2);
            Debug.Assert(_inputsAndOutputs.Outputs.Count == 2);
        }


        public InputPipe<TInput1> Input1
        {
            get
            {
                return (InputPipe<TInput1>) this._inputsAndOutputs.Inputs[0];
            }
        }

        public InputPipe<TInput2> Input2
        {
            get
            {
                return (InputPipe<TInput2>) this._inputsAndOutputs.Inputs[1];
            }
        }

        public CollectorPipe<TOutput1> Output1
        {
            get
            {
                return (CollectorPipe<TOutput1>) this._inputsAndOutputs.Outputs[0];
            }
        }

        public CollectorPipe<TOutput2> Output2
        {
            get
            {
                return (CollectorPipe<TOutput2>) this._inputsAndOutputs.Outputs[1];
            }
        }

        public Tuple<InputPipe<TInput1>, InputPipe<TInput2>, CollectorPipe<TOutput1>, CollectorPipe<TOutput2>> AsTuple()
        {
            return Tuple.Create(Input1, Input2, Output1, Output2);
        }

        public void Send(TInput1 value1, TInput2 value2)
        {
            this.Input1.Send(value1);
            this.Input2.Send(value2);
        }
    }
}
