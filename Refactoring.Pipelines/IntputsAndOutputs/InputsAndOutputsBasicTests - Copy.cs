using System;
using System.Linq;

namespace Refactoring.Pipelines.IntputsAndOutputs
{
    public static class Inputs1AndOutputs1Extensions
    {
        public static Inputs1AndOutputs1<TInput1, TOutput1> GetInputAndOutput<TInput1, TOutput1>(this IGraphNode node)
        {
            return new Inputs1AndOutputs1<TInput1, TOutput1>(node);
        }
    }

    public class Inputs1AndOutputs1<TInput1, TOutput1>
    {
        private readonly InputsAndOutputs _inputsAndOutputs;

        public Inputs1AndOutputs1(IGraphNode node)
        {

            this._inputsAndOutputs = new InputsAndOutputs(node);
        }

        public InputPipe< TInput1> Input
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

        public Tuple<InputPipe<TInput1>, CollectorPipe<TOutput1>> InputsAndOutputs
        {
            get
            {
                return Tuple.Create(Input, Output);
            }
        }

        public void Send(TInput1 value1) { this.Input.Send(value1); }
    }
}
