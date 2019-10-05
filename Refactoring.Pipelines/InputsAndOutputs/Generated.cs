using System;
using System.Diagnostics;

namespace Refactoring.Pipelines.InputsAndOutputs
{
    public static class Inputs1Extensions
    {
        public static Inputs<TInput1> GetInputs<TInput1>(this IGraphNode node)
        {
            return new Inputs<TInput1>(node);
        }
    }
}
namespace Refactoring.Pipelines.InputsAndOutputs
{
    public class Inputs<TInput1>
    {
        private readonly IGraphNode _node;
        public Inputs(IGraphNode node) { this._node = node; }

        public Inputs1AndOutputs1<TInput1, TOutput1> AndOutputs<TOutput1>()
        {
            return new Inputs1AndOutputs1<TInput1, TOutput1>(this._node);
        }

        public Inputs1AndOutputs2<TInput1, TOutput1, TOutput2> AndOutputs<TOutput1, TOutput2>()
        {
            return new Inputs1AndOutputs2<TInput1, TOutput1, TOutput2>(this._node);
        }

        public Inputs1AndOutputs3<TInput1, TOutput1, TOutput2, TOutput3> AndOutputs<TOutput1, TOutput2, TOutput3>()
        {
            return new Inputs1AndOutputs3<TInput1, TOutput1, TOutput2, TOutput3>(this._node);
        }

        public Inputs1AndOutputs4<TInput1, TOutput1, TOutput2, TOutput3, TOutput4> AndOutputs<TOutput1, TOutput2, TOutput3, TOutput4>()
        {
            return new Inputs1AndOutputs4<TInput1, TOutput1, TOutput2, TOutput3, TOutput4>(this._node);
        }

    }
}
namespace Refactoring.Pipelines.InputsAndOutputs
{
    public class Inputs1AndOutputs1<TInput1, TOutput1>
    {
        private readonly InputsAndOutputs _inputsAndOutputs;

        public Inputs1AndOutputs1(IGraphNode node)
        {
            this._inputsAndOutputs = new InputsAndOutputs(node);
            Debug.Assert(_inputsAndOutputs.Inputs.Count == 1);
            Debug.Assert(_inputsAndOutputs.Outputs.Count == 1);
        }

        public InputPipe<TInput1> Input1
        {
            get
            {
                return (InputPipe<TInput1>) this._inputsAndOutputs.Inputs[0];
            }
        }

        public Tuple<InputPipe<TInput1>> Inputs
        {
            get
            {
                return Tuple.Create(Input1);
            }
        }

        public CollectorPipe<TOutput1> Output1
        {
            get
            {
                return (CollectorPipe<TOutput1>) this._inputsAndOutputs.Outputs[0];
            }
        }

        public Tuple<CollectorPipe<TOutput1>> Outputs
        {
            get
            {
                return Tuple.Create(Output1);
            }
        }

        public Tuple<InputPipe<TInput1>, CollectorPipe<TOutput1>> AsTuple()
        {
            return Tuple.Create(Input1, Output1);
        }

        public void Send(TInput1 value1)
        {
            this.Input1.Send(value1);
        }

    }
}
namespace Refactoring.Pipelines.InputsAndOutputs
{
    public class Inputs1AndOutputs2<TInput1, TOutput1, TOutput2>
    {
        private readonly InputsAndOutputs _inputsAndOutputs;

        public Inputs1AndOutputs2(IGraphNode node)
        {
            this._inputsAndOutputs = new InputsAndOutputs(node);
            Debug.Assert(_inputsAndOutputs.Inputs.Count == 1);
            Debug.Assert(_inputsAndOutputs.Outputs.Count == 2);
        }

        public InputPipe<TInput1> Input1
        {
            get
            {
                return (InputPipe<TInput1>) this._inputsAndOutputs.Inputs[0];
            }
        }

        public Tuple<InputPipe<TInput1>> Inputs
        {
            get
            {
                return Tuple.Create(Input1);
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

        public Tuple<CollectorPipe<TOutput1>, CollectorPipe<TOutput2>> Outputs
        {
            get
            {
                return Tuple.Create(Output1, Output2);
            }
        }

        public Tuple<InputPipe<TInput1>, CollectorPipe<TOutput1>, CollectorPipe<TOutput2>> AsTuple()
        {
            return Tuple.Create(Input1, Output1, Output2);
        }

        public void Send(TInput1 value1)
        {
            this.Input1.Send(value1);
        }

    }
}
namespace Refactoring.Pipelines.InputsAndOutputs
{
    public class Inputs1AndOutputs3<TInput1, TOutput1, TOutput2, TOutput3>
    {
        private readonly InputsAndOutputs _inputsAndOutputs;

        public Inputs1AndOutputs3(IGraphNode node)
        {
            this._inputsAndOutputs = new InputsAndOutputs(node);
            Debug.Assert(_inputsAndOutputs.Inputs.Count == 1);
            Debug.Assert(_inputsAndOutputs.Outputs.Count == 3);
        }

        public InputPipe<TInput1> Input1
        {
            get
            {
                return (InputPipe<TInput1>) this._inputsAndOutputs.Inputs[0];
            }
        }

        public Tuple<InputPipe<TInput1>> Inputs
        {
            get
            {
                return Tuple.Create(Input1);
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

        public CollectorPipe<TOutput3> Output3
        {
            get
            {
                return (CollectorPipe<TOutput3>) this._inputsAndOutputs.Outputs[2];
            }
        }

        public Tuple<CollectorPipe<TOutput1>, CollectorPipe<TOutput2>, CollectorPipe<TOutput3>> Outputs
        {
            get
            {
                return Tuple.Create(Output1, Output2, Output3);
            }
        }

        public Tuple<InputPipe<TInput1>, CollectorPipe<TOutput1>, CollectorPipe<TOutput2>, CollectorPipe<TOutput3>> AsTuple()
        {
            return Tuple.Create(Input1, Output1, Output2, Output3);
        }

        public void Send(TInput1 value1)
        {
            this.Input1.Send(value1);
        }

    }
}
namespace Refactoring.Pipelines.InputsAndOutputs
{
    public class Inputs1AndOutputs4<TInput1, TOutput1, TOutput2, TOutput3, TOutput4>
    {
        private readonly InputsAndOutputs _inputsAndOutputs;

        public Inputs1AndOutputs4(IGraphNode node)
        {
            this._inputsAndOutputs = new InputsAndOutputs(node);
            Debug.Assert(_inputsAndOutputs.Inputs.Count == 1);
            Debug.Assert(_inputsAndOutputs.Outputs.Count == 4);
        }

        public InputPipe<TInput1> Input1
        {
            get
            {
                return (InputPipe<TInput1>) this._inputsAndOutputs.Inputs[0];
            }
        }

        public Tuple<InputPipe<TInput1>> Inputs
        {
            get
            {
                return Tuple.Create(Input1);
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

        public CollectorPipe<TOutput3> Output3
        {
            get
            {
                return (CollectorPipe<TOutput3>) this._inputsAndOutputs.Outputs[2];
            }
        }

        public CollectorPipe<TOutput4> Output4
        {
            get
            {
                return (CollectorPipe<TOutput4>) this._inputsAndOutputs.Outputs[3];
            }
        }

        public Tuple<CollectorPipe<TOutput1>, CollectorPipe<TOutput2>, CollectorPipe<TOutput3>, CollectorPipe<TOutput4>> Outputs
        {
            get
            {
                return Tuple.Create(Output1, Output2, Output3, Output4);
            }
        }

        public Tuple<InputPipe<TInput1>, CollectorPipe<TOutput1>, CollectorPipe<TOutput2>, CollectorPipe<TOutput3>, CollectorPipe<TOutput4>> AsTuple()
        {
            return Tuple.Create(Input1, Output1, Output2, Output3, Output4);
        }

        public void Send(TInput1 value1)
        {
            this.Input1.Send(value1);
        }

    }
}
namespace Refactoring.Pipelines.InputsAndOutputs
{
    public class Inputs1AndOutputs5<TInput1, TOutput1, TOutput2, TOutput3, TOutput4, TOutput5>
    {
        private readonly InputsAndOutputs _inputsAndOutputs;

        public Inputs1AndOutputs5(IGraphNode node)
        {
            this._inputsAndOutputs = new InputsAndOutputs(node);
            Debug.Assert(_inputsAndOutputs.Inputs.Count == 1);
            Debug.Assert(_inputsAndOutputs.Outputs.Count == 5);
        }

        public InputPipe<TInput1> Input1
        {
            get
            {
                return (InputPipe<TInput1>) this._inputsAndOutputs.Inputs[0];
            }
        }

        public Tuple<InputPipe<TInput1>> Inputs
        {
            get
            {
                return Tuple.Create(Input1);
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

        public CollectorPipe<TOutput3> Output3
        {
            get
            {
                return (CollectorPipe<TOutput3>) this._inputsAndOutputs.Outputs[2];
            }
        }

        public CollectorPipe<TOutput4> Output4
        {
            get
            {
                return (CollectorPipe<TOutput4>) this._inputsAndOutputs.Outputs[3];
            }
        }

        public CollectorPipe<TOutput5> Output5
        {
            get
            {
                return (CollectorPipe<TOutput5>) this._inputsAndOutputs.Outputs[4];
            }
        }

        public Tuple<CollectorPipe<TOutput1>, CollectorPipe<TOutput2>, CollectorPipe<TOutput3>, CollectorPipe<TOutput4>, CollectorPipe<TOutput5>> Outputs
        {
            get
            {
                return Tuple.Create(Output1, Output2, Output3, Output4, Output5);
            }
        }

        public Tuple<InputPipe<TInput1>, CollectorPipe<TOutput1>, CollectorPipe<TOutput2>, CollectorPipe<TOutput3>, CollectorPipe<TOutput4>, CollectorPipe<TOutput5>> AsTuple()
        {
            return Tuple.Create(Input1, Output1, Output2, Output3, Output4, Output5);
        }

        public void Send(TInput1 value1)
        {
            this.Input1.Send(value1);
        }

    }
}
namespace Refactoring.Pipelines.InputsAndOutputs
{
    public class Inputs1AndOutputs6<TInput1, TOutput1, TOutput2, TOutput3, TOutput4, TOutput5, TOutput6>
    {
        private readonly InputsAndOutputs _inputsAndOutputs;

        public Inputs1AndOutputs6(IGraphNode node)
        {
            this._inputsAndOutputs = new InputsAndOutputs(node);
            Debug.Assert(_inputsAndOutputs.Inputs.Count == 1);
            Debug.Assert(_inputsAndOutputs.Outputs.Count == 6);
        }

        public InputPipe<TInput1> Input1
        {
            get
            {
                return (InputPipe<TInput1>) this._inputsAndOutputs.Inputs[0];
            }
        }

        public Tuple<InputPipe<TInput1>> Inputs
        {
            get
            {
                return Tuple.Create(Input1);
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

        public CollectorPipe<TOutput3> Output3
        {
            get
            {
                return (CollectorPipe<TOutput3>) this._inputsAndOutputs.Outputs[2];
            }
        }

        public CollectorPipe<TOutput4> Output4
        {
            get
            {
                return (CollectorPipe<TOutput4>) this._inputsAndOutputs.Outputs[3];
            }
        }

        public CollectorPipe<TOutput5> Output5
        {
            get
            {
                return (CollectorPipe<TOutput5>) this._inputsAndOutputs.Outputs[4];
            }
        }

        public CollectorPipe<TOutput6> Output6
        {
            get
            {
                return (CollectorPipe<TOutput6>) this._inputsAndOutputs.Outputs[5];
            }
        }

        public Tuple<CollectorPipe<TOutput1>, CollectorPipe<TOutput2>, CollectorPipe<TOutput3>, CollectorPipe<TOutput4>, CollectorPipe<TOutput5>, CollectorPipe<TOutput6>> Outputs
        {
            get
            {
                return Tuple.Create(Output1, Output2, Output3, Output4, Output5, Output6);
            }
        }

        public Tuple<InputPipe<TInput1>, CollectorPipe<TOutput1>, CollectorPipe<TOutput2>, CollectorPipe<TOutput3>, CollectorPipe<TOutput4>, CollectorPipe<TOutput5>, CollectorPipe<TOutput6>> AsTuple()
        {
            return Tuple.Create(Input1, Output1, Output2, Output3, Output4, Output5, Output6);
        }

        public void Send(TInput1 value1)
        {
            this.Input1.Send(value1);
        }

    }
}

namespace Refactoring.Pipelines.InputsAndOutputs
{
    public static class Inputs2Extensions
    {
        public static Inputs<TInput1, TInput2> GetInputs<TInput1, TInput2>(this IGraphNode node)
        {
            return new Inputs<TInput1, TInput2>(node);
        }
    }
}
namespace Refactoring.Pipelines.InputsAndOutputs
{
    public class Inputs<TInput1, TInput2>
    {
        private readonly IGraphNode _node;
        public Inputs(IGraphNode node) { this._node = node; }

        public Inputs2AndOutputs1<TInput1, TInput2, TOutput1> AndOutputs<TOutput1>()
        {
            return new Inputs2AndOutputs1<TInput1, TInput2, TOutput1>(this._node);
        }

        public Inputs2AndOutputs2<TInput1, TInput2, TOutput1, TOutput2> AndOutputs<TOutput1, TOutput2>()
        {
            return new Inputs2AndOutputs2<TInput1, TInput2, TOutput1, TOutput2>(this._node);
        }

        public Inputs2AndOutputs3<TInput1, TInput2, TOutput1, TOutput2, TOutput3> AndOutputs<TOutput1, TOutput2, TOutput3>()
        {
            return new Inputs2AndOutputs3<TInput1, TInput2, TOutput1, TOutput2, TOutput3>(this._node);
        }

        public Inputs2AndOutputs4<TInput1, TInput2, TOutput1, TOutput2, TOutput3, TOutput4> AndOutputs<TOutput1, TOutput2, TOutput3, TOutput4>()
        {
            return new Inputs2AndOutputs4<TInput1, TInput2, TOutput1, TOutput2, TOutput3, TOutput4>(this._node);
        }

    }
}
namespace Refactoring.Pipelines.InputsAndOutputs
{
    public class Inputs2AndOutputs1<TInput1, TInput2, TOutput1>
    {
        private readonly InputsAndOutputs _inputsAndOutputs;

        public Inputs2AndOutputs1(IGraphNode node)
        {
            this._inputsAndOutputs = new InputsAndOutputs(node);
            Debug.Assert(_inputsAndOutputs.Inputs.Count == 2);
            Debug.Assert(_inputsAndOutputs.Outputs.Count == 1);
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

        public Tuple<InputPipe<TInput1>, InputPipe<TInput2>> Inputs
        {
            get
            {
                return Tuple.Create(Input1, Input2);
            }
        }

        public CollectorPipe<TOutput1> Output1
        {
            get
            {
                return (CollectorPipe<TOutput1>) this._inputsAndOutputs.Outputs[0];
            }
        }

        public Tuple<CollectorPipe<TOutput1>> Outputs
        {
            get
            {
                return Tuple.Create(Output1);
            }
        }

        public Tuple<InputPipe<TInput1>, InputPipe<TInput2>, CollectorPipe<TOutput1>> AsTuple()
        {
            return Tuple.Create(Input1, Input2, Output1);
        }

        public void Send(TInput1 value1, TInput2 value2)
        {
            this.Input1.Send(value1);
            this.Input2.Send(value2);
        }

    }
}
namespace Refactoring.Pipelines.InputsAndOutputs
{
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

        public Tuple<InputPipe<TInput1>, InputPipe<TInput2>> Inputs
        {
            get
            {
                return Tuple.Create(Input1, Input2);
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

        public Tuple<CollectorPipe<TOutput1>, CollectorPipe<TOutput2>> Outputs
        {
            get
            {
                return Tuple.Create(Output1, Output2);
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
namespace Refactoring.Pipelines.InputsAndOutputs
{
    public class Inputs2AndOutputs3<TInput1, TInput2, TOutput1, TOutput2, TOutput3>
    {
        private readonly InputsAndOutputs _inputsAndOutputs;

        public Inputs2AndOutputs3(IGraphNode node)
        {
            this._inputsAndOutputs = new InputsAndOutputs(node);
            Debug.Assert(_inputsAndOutputs.Inputs.Count == 2);
            Debug.Assert(_inputsAndOutputs.Outputs.Count == 3);
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

        public Tuple<InputPipe<TInput1>, InputPipe<TInput2>> Inputs
        {
            get
            {
                return Tuple.Create(Input1, Input2);
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

        public CollectorPipe<TOutput3> Output3
        {
            get
            {
                return (CollectorPipe<TOutput3>) this._inputsAndOutputs.Outputs[2];
            }
        }

        public Tuple<CollectorPipe<TOutput1>, CollectorPipe<TOutput2>, CollectorPipe<TOutput3>> Outputs
        {
            get
            {
                return Tuple.Create(Output1, Output2, Output3);
            }
        }

        public Tuple<InputPipe<TInput1>, InputPipe<TInput2>, CollectorPipe<TOutput1>, CollectorPipe<TOutput2>, CollectorPipe<TOutput3>> AsTuple()
        {
            return Tuple.Create(Input1, Input2, Output1, Output2, Output3);
        }

        public void Send(TInput1 value1, TInput2 value2)
        {
            this.Input1.Send(value1);
            this.Input2.Send(value2);
        }

    }
}
namespace Refactoring.Pipelines.InputsAndOutputs
{
    public class Inputs2AndOutputs4<TInput1, TInput2, TOutput1, TOutput2, TOutput3, TOutput4>
    {
        private readonly InputsAndOutputs _inputsAndOutputs;

        public Inputs2AndOutputs4(IGraphNode node)
        {
            this._inputsAndOutputs = new InputsAndOutputs(node);
            Debug.Assert(_inputsAndOutputs.Inputs.Count == 2);
            Debug.Assert(_inputsAndOutputs.Outputs.Count == 4);
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

        public Tuple<InputPipe<TInput1>, InputPipe<TInput2>> Inputs
        {
            get
            {
                return Tuple.Create(Input1, Input2);
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

        public CollectorPipe<TOutput3> Output3
        {
            get
            {
                return (CollectorPipe<TOutput3>) this._inputsAndOutputs.Outputs[2];
            }
        }

        public CollectorPipe<TOutput4> Output4
        {
            get
            {
                return (CollectorPipe<TOutput4>) this._inputsAndOutputs.Outputs[3];
            }
        }

        public Tuple<CollectorPipe<TOutput1>, CollectorPipe<TOutput2>, CollectorPipe<TOutput3>, CollectorPipe<TOutput4>> Outputs
        {
            get
            {
                return Tuple.Create(Output1, Output2, Output3, Output4);
            }
        }

        public Tuple<InputPipe<TInput1>, InputPipe<TInput2>, CollectorPipe<TOutput1>, CollectorPipe<TOutput2>, CollectorPipe<TOutput3>, CollectorPipe<TOutput4>> AsTuple()
        {
            return Tuple.Create(Input1, Input2, Output1, Output2, Output3, Output4);
        }

        public void Send(TInput1 value1, TInput2 value2)
        {
            this.Input1.Send(value1);
            this.Input2.Send(value2);
        }

    }
}
namespace Refactoring.Pipelines.InputsAndOutputs
{
    public class Inputs2AndOutputs5<TInput1, TInput2, TOutput1, TOutput2, TOutput3, TOutput4, TOutput5>
    {
        private readonly InputsAndOutputs _inputsAndOutputs;

        public Inputs2AndOutputs5(IGraphNode node)
        {
            this._inputsAndOutputs = new InputsAndOutputs(node);
            Debug.Assert(_inputsAndOutputs.Inputs.Count == 2);
            Debug.Assert(_inputsAndOutputs.Outputs.Count == 5);
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

        public Tuple<InputPipe<TInput1>, InputPipe<TInput2>> Inputs
        {
            get
            {
                return Tuple.Create(Input1, Input2);
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

        public CollectorPipe<TOutput3> Output3
        {
            get
            {
                return (CollectorPipe<TOutput3>) this._inputsAndOutputs.Outputs[2];
            }
        }

        public CollectorPipe<TOutput4> Output4
        {
            get
            {
                return (CollectorPipe<TOutput4>) this._inputsAndOutputs.Outputs[3];
            }
        }

        public CollectorPipe<TOutput5> Output5
        {
            get
            {
                return (CollectorPipe<TOutput5>) this._inputsAndOutputs.Outputs[4];
            }
        }

        public Tuple<CollectorPipe<TOutput1>, CollectorPipe<TOutput2>, CollectorPipe<TOutput3>, CollectorPipe<TOutput4>, CollectorPipe<TOutput5>> Outputs
        {
            get
            {
                return Tuple.Create(Output1, Output2, Output3, Output4, Output5);
            }
        }

        public Tuple<InputPipe<TInput1>, InputPipe<TInput2>, CollectorPipe<TOutput1>, CollectorPipe<TOutput2>, CollectorPipe<TOutput3>, CollectorPipe<TOutput4>, CollectorPipe<TOutput5>> AsTuple()
        {
            return Tuple.Create(Input1, Input2, Output1, Output2, Output3, Output4, Output5);
        }

        public void Send(TInput1 value1, TInput2 value2)
        {
            this.Input1.Send(value1);
            this.Input2.Send(value2);
        }

    }
}
namespace Refactoring.Pipelines.InputsAndOutputs
{
    public class Inputs2AndOutputs6<TInput1, TInput2, TOutput1, TOutput2, TOutput3, TOutput4, TOutput5, TOutput6>
    {
        private readonly InputsAndOutputs _inputsAndOutputs;

        public Inputs2AndOutputs6(IGraphNode node)
        {
            this._inputsAndOutputs = new InputsAndOutputs(node);
            Debug.Assert(_inputsAndOutputs.Inputs.Count == 2);
            Debug.Assert(_inputsAndOutputs.Outputs.Count == 6);
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

        public Tuple<InputPipe<TInput1>, InputPipe<TInput2>> Inputs
        {
            get
            {
                return Tuple.Create(Input1, Input2);
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

        public CollectorPipe<TOutput3> Output3
        {
            get
            {
                return (CollectorPipe<TOutput3>) this._inputsAndOutputs.Outputs[2];
            }
        }

        public CollectorPipe<TOutput4> Output4
        {
            get
            {
                return (CollectorPipe<TOutput4>) this._inputsAndOutputs.Outputs[3];
            }
        }

        public CollectorPipe<TOutput5> Output5
        {
            get
            {
                return (CollectorPipe<TOutput5>) this._inputsAndOutputs.Outputs[4];
            }
        }

        public CollectorPipe<TOutput6> Output6
        {
            get
            {
                return (CollectorPipe<TOutput6>) this._inputsAndOutputs.Outputs[5];
            }
        }

        public Tuple<CollectorPipe<TOutput1>, CollectorPipe<TOutput2>, CollectorPipe<TOutput3>, CollectorPipe<TOutput4>, CollectorPipe<TOutput5>, CollectorPipe<TOutput6>> Outputs
        {
            get
            {
                return Tuple.Create(Output1, Output2, Output3, Output4, Output5, Output6);
            }
        }

        // AsTuple() not valid for more than 7 parameters

        public void Send(TInput1 value1, TInput2 value2)
        {
            this.Input1.Send(value1);
            this.Input2.Send(value2);
        }

    }
}

namespace Refactoring.Pipelines.InputsAndOutputs
{
    public static class Inputs3Extensions
    {
        public static Inputs<TInput1, TInput2, TInput3> GetInputs<TInput1, TInput2, TInput3>(this IGraphNode node)
        {
            return new Inputs<TInput1, TInput2, TInput3>(node);
        }
    }
}
namespace Refactoring.Pipelines.InputsAndOutputs
{
    public class Inputs<TInput1, TInput2, TInput3>
    {
        private readonly IGraphNode _node;
        public Inputs(IGraphNode node) { this._node = node; }

        public Inputs3AndOutputs1<TInput1, TInput2, TInput3, TOutput1> AndOutputs<TOutput1>()
        {
            return new Inputs3AndOutputs1<TInput1, TInput2, TInput3, TOutput1>(this._node);
        }

        public Inputs3AndOutputs2<TInput1, TInput2, TInput3, TOutput1, TOutput2> AndOutputs<TOutput1, TOutput2>()
        {
            return new Inputs3AndOutputs2<TInput1, TInput2, TInput3, TOutput1, TOutput2>(this._node);
        }

        public Inputs3AndOutputs3<TInput1, TInput2, TInput3, TOutput1, TOutput2, TOutput3> AndOutputs<TOutput1, TOutput2, TOutput3>()
        {
            return new Inputs3AndOutputs3<TInput1, TInput2, TInput3, TOutput1, TOutput2, TOutput3>(this._node);
        }

        public Inputs3AndOutputs4<TInput1, TInput2, TInput3, TOutput1, TOutput2, TOutput3, TOutput4> AndOutputs<TOutput1, TOutput2, TOutput3, TOutput4>()
        {
            return new Inputs3AndOutputs4<TInput1, TInput2, TInput3, TOutput1, TOutput2, TOutput3, TOutput4>(this._node);
        }

    }
}
namespace Refactoring.Pipelines.InputsAndOutputs
{
    public class Inputs3AndOutputs1<TInput1, TInput2, TInput3, TOutput1>
    {
        private readonly InputsAndOutputs _inputsAndOutputs;

        public Inputs3AndOutputs1(IGraphNode node)
        {
            this._inputsAndOutputs = new InputsAndOutputs(node);
            Debug.Assert(_inputsAndOutputs.Inputs.Count == 3);
            Debug.Assert(_inputsAndOutputs.Outputs.Count == 1);
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

        public InputPipe<TInput3> Input3
        {
            get
            {
                return (InputPipe<TInput3>) this._inputsAndOutputs.Inputs[2];
            }
        }

        public Tuple<InputPipe<TInput1>, InputPipe<TInput2>, InputPipe<TInput3>> Inputs
        {
            get
            {
                return Tuple.Create(Input1, Input2, Input3);
            }
        }

        public CollectorPipe<TOutput1> Output1
        {
            get
            {
                return (CollectorPipe<TOutput1>) this._inputsAndOutputs.Outputs[0];
            }
        }

        public Tuple<CollectorPipe<TOutput1>> Outputs
        {
            get
            {
                return Tuple.Create(Output1);
            }
        }

        public Tuple<InputPipe<TInput1>, InputPipe<TInput2>, InputPipe<TInput3>, CollectorPipe<TOutput1>> AsTuple()
        {
            return Tuple.Create(Input1, Input2, Input3, Output1);
        }

        public void Send(TInput1 value1, TInput2 value2, TInput3 value3)
        {
            this.Input1.Send(value1);
            this.Input2.Send(value2);
            this.Input3.Send(value3);
        }

    }
}
namespace Refactoring.Pipelines.InputsAndOutputs
{
    public class Inputs3AndOutputs2<TInput1, TInput2, TInput3, TOutput1, TOutput2>
    {
        private readonly InputsAndOutputs _inputsAndOutputs;

        public Inputs3AndOutputs2(IGraphNode node)
        {
            this._inputsAndOutputs = new InputsAndOutputs(node);
            Debug.Assert(_inputsAndOutputs.Inputs.Count == 3);
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

        public InputPipe<TInput3> Input3
        {
            get
            {
                return (InputPipe<TInput3>) this._inputsAndOutputs.Inputs[2];
            }
        }

        public Tuple<InputPipe<TInput1>, InputPipe<TInput2>, InputPipe<TInput3>> Inputs
        {
            get
            {
                return Tuple.Create(Input1, Input2, Input3);
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

        public Tuple<CollectorPipe<TOutput1>, CollectorPipe<TOutput2>> Outputs
        {
            get
            {
                return Tuple.Create(Output1, Output2);
            }
        }

        public Tuple<InputPipe<TInput1>, InputPipe<TInput2>, InputPipe<TInput3>, CollectorPipe<TOutput1>, CollectorPipe<TOutput2>> AsTuple()
        {
            return Tuple.Create(Input1, Input2, Input3, Output1, Output2);
        }

        public void Send(TInput1 value1, TInput2 value2, TInput3 value3)
        {
            this.Input1.Send(value1);
            this.Input2.Send(value2);
            this.Input3.Send(value3);
        }

    }
}
namespace Refactoring.Pipelines.InputsAndOutputs
{
    public class Inputs3AndOutputs3<TInput1, TInput2, TInput3, TOutput1, TOutput2, TOutput3>
    {
        private readonly InputsAndOutputs _inputsAndOutputs;

        public Inputs3AndOutputs3(IGraphNode node)
        {
            this._inputsAndOutputs = new InputsAndOutputs(node);
            Debug.Assert(_inputsAndOutputs.Inputs.Count == 3);
            Debug.Assert(_inputsAndOutputs.Outputs.Count == 3);
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

        public InputPipe<TInput3> Input3
        {
            get
            {
                return (InputPipe<TInput3>) this._inputsAndOutputs.Inputs[2];
            }
        }

        public Tuple<InputPipe<TInput1>, InputPipe<TInput2>, InputPipe<TInput3>> Inputs
        {
            get
            {
                return Tuple.Create(Input1, Input2, Input3);
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

        public CollectorPipe<TOutput3> Output3
        {
            get
            {
                return (CollectorPipe<TOutput3>) this._inputsAndOutputs.Outputs[2];
            }
        }

        public Tuple<CollectorPipe<TOutput1>, CollectorPipe<TOutput2>, CollectorPipe<TOutput3>> Outputs
        {
            get
            {
                return Tuple.Create(Output1, Output2, Output3);
            }
        }

        public Tuple<InputPipe<TInput1>, InputPipe<TInput2>, InputPipe<TInput3>, CollectorPipe<TOutput1>, CollectorPipe<TOutput2>, CollectorPipe<TOutput3>> AsTuple()
        {
            return Tuple.Create(Input1, Input2, Input3, Output1, Output2, Output3);
        }

        public void Send(TInput1 value1, TInput2 value2, TInput3 value3)
        {
            this.Input1.Send(value1);
            this.Input2.Send(value2);
            this.Input3.Send(value3);
        }

    }
}
namespace Refactoring.Pipelines.InputsAndOutputs
{
    public class Inputs3AndOutputs4<TInput1, TInput2, TInput3, TOutput1, TOutput2, TOutput3, TOutput4>
    {
        private readonly InputsAndOutputs _inputsAndOutputs;

        public Inputs3AndOutputs4(IGraphNode node)
        {
            this._inputsAndOutputs = new InputsAndOutputs(node);
            Debug.Assert(_inputsAndOutputs.Inputs.Count == 3);
            Debug.Assert(_inputsAndOutputs.Outputs.Count == 4);
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

        public InputPipe<TInput3> Input3
        {
            get
            {
                return (InputPipe<TInput3>) this._inputsAndOutputs.Inputs[2];
            }
        }

        public Tuple<InputPipe<TInput1>, InputPipe<TInput2>, InputPipe<TInput3>> Inputs
        {
            get
            {
                return Tuple.Create(Input1, Input2, Input3);
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

        public CollectorPipe<TOutput3> Output3
        {
            get
            {
                return (CollectorPipe<TOutput3>) this._inputsAndOutputs.Outputs[2];
            }
        }

        public CollectorPipe<TOutput4> Output4
        {
            get
            {
                return (CollectorPipe<TOutput4>) this._inputsAndOutputs.Outputs[3];
            }
        }

        public Tuple<CollectorPipe<TOutput1>, CollectorPipe<TOutput2>, CollectorPipe<TOutput3>, CollectorPipe<TOutput4>> Outputs
        {
            get
            {
                return Tuple.Create(Output1, Output2, Output3, Output4);
            }
        }

        public Tuple<InputPipe<TInput1>, InputPipe<TInput2>, InputPipe<TInput3>, CollectorPipe<TOutput1>, CollectorPipe<TOutput2>, CollectorPipe<TOutput3>, CollectorPipe<TOutput4>> AsTuple()
        {
            return Tuple.Create(Input1, Input2, Input3, Output1, Output2, Output3, Output4);
        }

        public void Send(TInput1 value1, TInput2 value2, TInput3 value3)
        {
            this.Input1.Send(value1);
            this.Input2.Send(value2);
            this.Input3.Send(value3);
        }

    }
}
namespace Refactoring.Pipelines.InputsAndOutputs
{
    public class Inputs3AndOutputs5<TInput1, TInput2, TInput3, TOutput1, TOutput2, TOutput3, TOutput4, TOutput5>
    {
        private readonly InputsAndOutputs _inputsAndOutputs;

        public Inputs3AndOutputs5(IGraphNode node)
        {
            this._inputsAndOutputs = new InputsAndOutputs(node);
            Debug.Assert(_inputsAndOutputs.Inputs.Count == 3);
            Debug.Assert(_inputsAndOutputs.Outputs.Count == 5);
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

        public InputPipe<TInput3> Input3
        {
            get
            {
                return (InputPipe<TInput3>) this._inputsAndOutputs.Inputs[2];
            }
        }

        public Tuple<InputPipe<TInput1>, InputPipe<TInput2>, InputPipe<TInput3>> Inputs
        {
            get
            {
                return Tuple.Create(Input1, Input2, Input3);
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

        public CollectorPipe<TOutput3> Output3
        {
            get
            {
                return (CollectorPipe<TOutput3>) this._inputsAndOutputs.Outputs[2];
            }
        }

        public CollectorPipe<TOutput4> Output4
        {
            get
            {
                return (CollectorPipe<TOutput4>) this._inputsAndOutputs.Outputs[3];
            }
        }

        public CollectorPipe<TOutput5> Output5
        {
            get
            {
                return (CollectorPipe<TOutput5>) this._inputsAndOutputs.Outputs[4];
            }
        }

        public Tuple<CollectorPipe<TOutput1>, CollectorPipe<TOutput2>, CollectorPipe<TOutput3>, CollectorPipe<TOutput4>, CollectorPipe<TOutput5>> Outputs
        {
            get
            {
                return Tuple.Create(Output1, Output2, Output3, Output4, Output5);
            }
        }

        // AsTuple() not valid for more than 7 parameters

        public void Send(TInput1 value1, TInput2 value2, TInput3 value3)
        {
            this.Input1.Send(value1);
            this.Input2.Send(value2);
            this.Input3.Send(value3);
        }

    }
}
namespace Refactoring.Pipelines.InputsAndOutputs
{
    public class Inputs3AndOutputs6<TInput1, TInput2, TInput3, TOutput1, TOutput2, TOutput3, TOutput4, TOutput5, TOutput6>
    {
        private readonly InputsAndOutputs _inputsAndOutputs;

        public Inputs3AndOutputs6(IGraphNode node)
        {
            this._inputsAndOutputs = new InputsAndOutputs(node);
            Debug.Assert(_inputsAndOutputs.Inputs.Count == 3);
            Debug.Assert(_inputsAndOutputs.Outputs.Count == 6);
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

        public InputPipe<TInput3> Input3
        {
            get
            {
                return (InputPipe<TInput3>) this._inputsAndOutputs.Inputs[2];
            }
        }

        public Tuple<InputPipe<TInput1>, InputPipe<TInput2>, InputPipe<TInput3>> Inputs
        {
            get
            {
                return Tuple.Create(Input1, Input2, Input3);
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

        public CollectorPipe<TOutput3> Output3
        {
            get
            {
                return (CollectorPipe<TOutput3>) this._inputsAndOutputs.Outputs[2];
            }
        }

        public CollectorPipe<TOutput4> Output4
        {
            get
            {
                return (CollectorPipe<TOutput4>) this._inputsAndOutputs.Outputs[3];
            }
        }

        public CollectorPipe<TOutput5> Output5
        {
            get
            {
                return (CollectorPipe<TOutput5>) this._inputsAndOutputs.Outputs[4];
            }
        }

        public CollectorPipe<TOutput6> Output6
        {
            get
            {
                return (CollectorPipe<TOutput6>) this._inputsAndOutputs.Outputs[5];
            }
        }

        public Tuple<CollectorPipe<TOutput1>, CollectorPipe<TOutput2>, CollectorPipe<TOutput3>, CollectorPipe<TOutput4>, CollectorPipe<TOutput5>, CollectorPipe<TOutput6>> Outputs
        {
            get
            {
                return Tuple.Create(Output1, Output2, Output3, Output4, Output5, Output6);
            }
        }

        // AsTuple() not valid for more than 7 parameters

        public void Send(TInput1 value1, TInput2 value2, TInput3 value3)
        {
            this.Input1.Send(value1);
            this.Input2.Send(value2);
            this.Input3.Send(value3);
        }

    }
}

namespace Refactoring.Pipelines.InputsAndOutputs
{
    public static class Inputs4Extensions
    {
        public static Inputs<TInput1, TInput2, TInput3, TInput4> GetInputs<TInput1, TInput2, TInput3, TInput4>(this IGraphNode node)
        {
            return new Inputs<TInput1, TInput2, TInput3, TInput4>(node);
        }
    }
}
namespace Refactoring.Pipelines.InputsAndOutputs
{
    public class Inputs<TInput1, TInput2, TInput3, TInput4>
    {
        private readonly IGraphNode _node;
        public Inputs(IGraphNode node) { this._node = node; }

        public Inputs4AndOutputs1<TInput1, TInput2, TInput3, TInput4, TOutput1> AndOutputs<TOutput1>()
        {
            return new Inputs4AndOutputs1<TInput1, TInput2, TInput3, TInput4, TOutput1>(this._node);
        }

        public Inputs4AndOutputs2<TInput1, TInput2, TInput3, TInput4, TOutput1, TOutput2> AndOutputs<TOutput1, TOutput2>()
        {
            return new Inputs4AndOutputs2<TInput1, TInput2, TInput3, TInput4, TOutput1, TOutput2>(this._node);
        }

        public Inputs4AndOutputs3<TInput1, TInput2, TInput3, TInput4, TOutput1, TOutput2, TOutput3> AndOutputs<TOutput1, TOutput2, TOutput3>()
        {
            return new Inputs4AndOutputs3<TInput1, TInput2, TInput3, TInput4, TOutput1, TOutput2, TOutput3>(this._node);
        }

        public Inputs4AndOutputs4<TInput1, TInput2, TInput3, TInput4, TOutput1, TOutput2, TOutput3, TOutput4> AndOutputs<TOutput1, TOutput2, TOutput3, TOutput4>()
        {
            return new Inputs4AndOutputs4<TInput1, TInput2, TInput3, TInput4, TOutput1, TOutput2, TOutput3, TOutput4>(this._node);
        }

    }
}
namespace Refactoring.Pipelines.InputsAndOutputs
{
    public class Inputs4AndOutputs1<TInput1, TInput2, TInput3, TInput4, TOutput1>
    {
        private readonly InputsAndOutputs _inputsAndOutputs;

        public Inputs4AndOutputs1(IGraphNode node)
        {
            this._inputsAndOutputs = new InputsAndOutputs(node);
            Debug.Assert(_inputsAndOutputs.Inputs.Count == 4);
            Debug.Assert(_inputsAndOutputs.Outputs.Count == 1);
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

        public InputPipe<TInput3> Input3
        {
            get
            {
                return (InputPipe<TInput3>) this._inputsAndOutputs.Inputs[2];
            }
        }

        public InputPipe<TInput4> Input4
        {
            get
            {
                return (InputPipe<TInput4>) this._inputsAndOutputs.Inputs[3];
            }
        }

        public Tuple<InputPipe<TInput1>, InputPipe<TInput2>, InputPipe<TInput3>, InputPipe<TInput4>> Inputs
        {
            get
            {
                return Tuple.Create(Input1, Input2, Input3, Input4);
            }
        }

        public CollectorPipe<TOutput1> Output1
        {
            get
            {
                return (CollectorPipe<TOutput1>) this._inputsAndOutputs.Outputs[0];
            }
        }

        public Tuple<CollectorPipe<TOutput1>> Outputs
        {
            get
            {
                return Tuple.Create(Output1);
            }
        }

        public Tuple<InputPipe<TInput1>, InputPipe<TInput2>, InputPipe<TInput3>, InputPipe<TInput4>, CollectorPipe<TOutput1>> AsTuple()
        {
            return Tuple.Create(Input1, Input2, Input3, Input4, Output1);
        }

        public void Send(TInput1 value1, TInput2 value2, TInput3 value3, TInput4 value4)
        {
            this.Input1.Send(value1);
            this.Input2.Send(value2);
            this.Input3.Send(value3);
            this.Input4.Send(value4);
        }

    }
}
namespace Refactoring.Pipelines.InputsAndOutputs
{
    public class Inputs4AndOutputs2<TInput1, TInput2, TInput3, TInput4, TOutput1, TOutput2>
    {
        private readonly InputsAndOutputs _inputsAndOutputs;

        public Inputs4AndOutputs2(IGraphNode node)
        {
            this._inputsAndOutputs = new InputsAndOutputs(node);
            Debug.Assert(_inputsAndOutputs.Inputs.Count == 4);
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

        public InputPipe<TInput3> Input3
        {
            get
            {
                return (InputPipe<TInput3>) this._inputsAndOutputs.Inputs[2];
            }
        }

        public InputPipe<TInput4> Input4
        {
            get
            {
                return (InputPipe<TInput4>) this._inputsAndOutputs.Inputs[3];
            }
        }

        public Tuple<InputPipe<TInput1>, InputPipe<TInput2>, InputPipe<TInput3>, InputPipe<TInput4>> Inputs
        {
            get
            {
                return Tuple.Create(Input1, Input2, Input3, Input4);
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

        public Tuple<CollectorPipe<TOutput1>, CollectorPipe<TOutput2>> Outputs
        {
            get
            {
                return Tuple.Create(Output1, Output2);
            }
        }

        public Tuple<InputPipe<TInput1>, InputPipe<TInput2>, InputPipe<TInput3>, InputPipe<TInput4>, CollectorPipe<TOutput1>, CollectorPipe<TOutput2>> AsTuple()
        {
            return Tuple.Create(Input1, Input2, Input3, Input4, Output1, Output2);
        }

        public void Send(TInput1 value1, TInput2 value2, TInput3 value3, TInput4 value4)
        {
            this.Input1.Send(value1);
            this.Input2.Send(value2);
            this.Input3.Send(value3);
            this.Input4.Send(value4);
        }

    }
}
namespace Refactoring.Pipelines.InputsAndOutputs
{
    public class Inputs4AndOutputs3<TInput1, TInput2, TInput3, TInput4, TOutput1, TOutput2, TOutput3>
    {
        private readonly InputsAndOutputs _inputsAndOutputs;

        public Inputs4AndOutputs3(IGraphNode node)
        {
            this._inputsAndOutputs = new InputsAndOutputs(node);
            Debug.Assert(_inputsAndOutputs.Inputs.Count == 4);
            Debug.Assert(_inputsAndOutputs.Outputs.Count == 3);
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

        public InputPipe<TInput3> Input3
        {
            get
            {
                return (InputPipe<TInput3>) this._inputsAndOutputs.Inputs[2];
            }
        }

        public InputPipe<TInput4> Input4
        {
            get
            {
                return (InputPipe<TInput4>) this._inputsAndOutputs.Inputs[3];
            }
        }

        public Tuple<InputPipe<TInput1>, InputPipe<TInput2>, InputPipe<TInput3>, InputPipe<TInput4>> Inputs
        {
            get
            {
                return Tuple.Create(Input1, Input2, Input3, Input4);
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

        public CollectorPipe<TOutput3> Output3
        {
            get
            {
                return (CollectorPipe<TOutput3>) this._inputsAndOutputs.Outputs[2];
            }
        }

        public Tuple<CollectorPipe<TOutput1>, CollectorPipe<TOutput2>, CollectorPipe<TOutput3>> Outputs
        {
            get
            {
                return Tuple.Create(Output1, Output2, Output3);
            }
        }

        public Tuple<InputPipe<TInput1>, InputPipe<TInput2>, InputPipe<TInput3>, InputPipe<TInput4>, CollectorPipe<TOutput1>, CollectorPipe<TOutput2>, CollectorPipe<TOutput3>> AsTuple()
        {
            return Tuple.Create(Input1, Input2, Input3, Input4, Output1, Output2, Output3);
        }

        public void Send(TInput1 value1, TInput2 value2, TInput3 value3, TInput4 value4)
        {
            this.Input1.Send(value1);
            this.Input2.Send(value2);
            this.Input3.Send(value3);
            this.Input4.Send(value4);
        }

    }
}
namespace Refactoring.Pipelines.InputsAndOutputs
{
    public class Inputs4AndOutputs4<TInput1, TInput2, TInput3, TInput4, TOutput1, TOutput2, TOutput3, TOutput4>
    {
        private readonly InputsAndOutputs _inputsAndOutputs;

        public Inputs4AndOutputs4(IGraphNode node)
        {
            this._inputsAndOutputs = new InputsAndOutputs(node);
            Debug.Assert(_inputsAndOutputs.Inputs.Count == 4);
            Debug.Assert(_inputsAndOutputs.Outputs.Count == 4);
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

        public InputPipe<TInput3> Input3
        {
            get
            {
                return (InputPipe<TInput3>) this._inputsAndOutputs.Inputs[2];
            }
        }

        public InputPipe<TInput4> Input4
        {
            get
            {
                return (InputPipe<TInput4>) this._inputsAndOutputs.Inputs[3];
            }
        }

        public Tuple<InputPipe<TInput1>, InputPipe<TInput2>, InputPipe<TInput3>, InputPipe<TInput4>> Inputs
        {
            get
            {
                return Tuple.Create(Input1, Input2, Input3, Input4);
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

        public CollectorPipe<TOutput3> Output3
        {
            get
            {
                return (CollectorPipe<TOutput3>) this._inputsAndOutputs.Outputs[2];
            }
        }

        public CollectorPipe<TOutput4> Output4
        {
            get
            {
                return (CollectorPipe<TOutput4>) this._inputsAndOutputs.Outputs[3];
            }
        }

        public Tuple<CollectorPipe<TOutput1>, CollectorPipe<TOutput2>, CollectorPipe<TOutput3>, CollectorPipe<TOutput4>> Outputs
        {
            get
            {
                return Tuple.Create(Output1, Output2, Output3, Output4);
            }
        }

        // AsTuple() not valid for more than 7 parameters

        public void Send(TInput1 value1, TInput2 value2, TInput3 value3, TInput4 value4)
        {
            this.Input1.Send(value1);
            this.Input2.Send(value2);
            this.Input3.Send(value3);
            this.Input4.Send(value4);
        }

    }
}
namespace Refactoring.Pipelines.InputsAndOutputs
{
    public class Inputs4AndOutputs5<TInput1, TInput2, TInput3, TInput4, TOutput1, TOutput2, TOutput3, TOutput4, TOutput5>
    {
        private readonly InputsAndOutputs _inputsAndOutputs;

        public Inputs4AndOutputs5(IGraphNode node)
        {
            this._inputsAndOutputs = new InputsAndOutputs(node);
            Debug.Assert(_inputsAndOutputs.Inputs.Count == 4);
            Debug.Assert(_inputsAndOutputs.Outputs.Count == 5);
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

        public InputPipe<TInput3> Input3
        {
            get
            {
                return (InputPipe<TInput3>) this._inputsAndOutputs.Inputs[2];
            }
        }

        public InputPipe<TInput4> Input4
        {
            get
            {
                return (InputPipe<TInput4>) this._inputsAndOutputs.Inputs[3];
            }
        }

        public Tuple<InputPipe<TInput1>, InputPipe<TInput2>, InputPipe<TInput3>, InputPipe<TInput4>> Inputs
        {
            get
            {
                return Tuple.Create(Input1, Input2, Input3, Input4);
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

        public CollectorPipe<TOutput3> Output3
        {
            get
            {
                return (CollectorPipe<TOutput3>) this._inputsAndOutputs.Outputs[2];
            }
        }

        public CollectorPipe<TOutput4> Output4
        {
            get
            {
                return (CollectorPipe<TOutput4>) this._inputsAndOutputs.Outputs[3];
            }
        }

        public CollectorPipe<TOutput5> Output5
        {
            get
            {
                return (CollectorPipe<TOutput5>) this._inputsAndOutputs.Outputs[4];
            }
        }

        public Tuple<CollectorPipe<TOutput1>, CollectorPipe<TOutput2>, CollectorPipe<TOutput3>, CollectorPipe<TOutput4>, CollectorPipe<TOutput5>> Outputs
        {
            get
            {
                return Tuple.Create(Output1, Output2, Output3, Output4, Output5);
            }
        }

        // AsTuple() not valid for more than 7 parameters

        public void Send(TInput1 value1, TInput2 value2, TInput3 value3, TInput4 value4)
        {
            this.Input1.Send(value1);
            this.Input2.Send(value2);
            this.Input3.Send(value3);
            this.Input4.Send(value4);
        }

    }
}
namespace Refactoring.Pipelines.InputsAndOutputs
{
    public class Inputs4AndOutputs6<TInput1, TInput2, TInput3, TInput4, TOutput1, TOutput2, TOutput3, TOutput4, TOutput5, TOutput6>
    {
        private readonly InputsAndOutputs _inputsAndOutputs;

        public Inputs4AndOutputs6(IGraphNode node)
        {
            this._inputsAndOutputs = new InputsAndOutputs(node);
            Debug.Assert(_inputsAndOutputs.Inputs.Count == 4);
            Debug.Assert(_inputsAndOutputs.Outputs.Count == 6);
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

        public InputPipe<TInput3> Input3
        {
            get
            {
                return (InputPipe<TInput3>) this._inputsAndOutputs.Inputs[2];
            }
        }

        public InputPipe<TInput4> Input4
        {
            get
            {
                return (InputPipe<TInput4>) this._inputsAndOutputs.Inputs[3];
            }
        }

        public Tuple<InputPipe<TInput1>, InputPipe<TInput2>, InputPipe<TInput3>, InputPipe<TInput4>> Inputs
        {
            get
            {
                return Tuple.Create(Input1, Input2, Input3, Input4);
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

        public CollectorPipe<TOutput3> Output3
        {
            get
            {
                return (CollectorPipe<TOutput3>) this._inputsAndOutputs.Outputs[2];
            }
        }

        public CollectorPipe<TOutput4> Output4
        {
            get
            {
                return (CollectorPipe<TOutput4>) this._inputsAndOutputs.Outputs[3];
            }
        }

        public CollectorPipe<TOutput5> Output5
        {
            get
            {
                return (CollectorPipe<TOutput5>) this._inputsAndOutputs.Outputs[4];
            }
        }

        public CollectorPipe<TOutput6> Output6
        {
            get
            {
                return (CollectorPipe<TOutput6>) this._inputsAndOutputs.Outputs[5];
            }
        }

        public Tuple<CollectorPipe<TOutput1>, CollectorPipe<TOutput2>, CollectorPipe<TOutput3>, CollectorPipe<TOutput4>, CollectorPipe<TOutput5>, CollectorPipe<TOutput6>> Outputs
        {
            get
            {
                return Tuple.Create(Output1, Output2, Output3, Output4, Output5, Output6);
            }
        }

        // AsTuple() not valid for more than 7 parameters

        public void Send(TInput1 value1, TInput2 value2, TInput3 value3, TInput4 value4)
        {
            this.Input1.Send(value1);
            this.Input2.Send(value2);
            this.Input3.Send(value3);
            this.Input4.Send(value4);
        }

    }
}

namespace Refactoring.Pipelines.InputsAndOutputs
{
    public static class Inputs5Extensions
    {
        public static Inputs<TInput1, TInput2, TInput3, TInput4, TInput5> GetInputs<TInput1, TInput2, TInput3, TInput4, TInput5>(this IGraphNode node)
        {
            return new Inputs<TInput1, TInput2, TInput3, TInput4, TInput5>(node);
        }
    }
}
namespace Refactoring.Pipelines.InputsAndOutputs
{
    public class Inputs<TInput1, TInput2, TInput3, TInput4, TInput5>
    {
        private readonly IGraphNode _node;
        public Inputs(IGraphNode node) { this._node = node; }

        public Inputs5AndOutputs1<TInput1, TInput2, TInput3, TInput4, TInput5, TOutput1> AndOutputs<TOutput1>()
        {
            return new Inputs5AndOutputs1<TInput1, TInput2, TInput3, TInput4, TInput5, TOutput1>(this._node);
        }

        public Inputs5AndOutputs2<TInput1, TInput2, TInput3, TInput4, TInput5, TOutput1, TOutput2> AndOutputs<TOutput1, TOutput2>()
        {
            return new Inputs5AndOutputs2<TInput1, TInput2, TInput3, TInput4, TInput5, TOutput1, TOutput2>(this._node);
        }

        public Inputs5AndOutputs3<TInput1, TInput2, TInput3, TInput4, TInput5, TOutput1, TOutput2, TOutput3> AndOutputs<TOutput1, TOutput2, TOutput3>()
        {
            return new Inputs5AndOutputs3<TInput1, TInput2, TInput3, TInput4, TInput5, TOutput1, TOutput2, TOutput3>(this._node);
        }

        public Inputs5AndOutputs4<TInput1, TInput2, TInput3, TInput4, TInput5, TOutput1, TOutput2, TOutput3, TOutput4> AndOutputs<TOutput1, TOutput2, TOutput3, TOutput4>()
        {
            return new Inputs5AndOutputs4<TInput1, TInput2, TInput3, TInput4, TInput5, TOutput1, TOutput2, TOutput3, TOutput4>(this._node);
        }

    }
}
namespace Refactoring.Pipelines.InputsAndOutputs
{
    public class Inputs5AndOutputs1<TInput1, TInput2, TInput3, TInput4, TInput5, TOutput1>
    {
        private readonly InputsAndOutputs _inputsAndOutputs;

        public Inputs5AndOutputs1(IGraphNode node)
        {
            this._inputsAndOutputs = new InputsAndOutputs(node);
            Debug.Assert(_inputsAndOutputs.Inputs.Count == 5);
            Debug.Assert(_inputsAndOutputs.Outputs.Count == 1);
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

        public InputPipe<TInput3> Input3
        {
            get
            {
                return (InputPipe<TInput3>) this._inputsAndOutputs.Inputs[2];
            }
        }

        public InputPipe<TInput4> Input4
        {
            get
            {
                return (InputPipe<TInput4>) this._inputsAndOutputs.Inputs[3];
            }
        }

        public InputPipe<TInput5> Input5
        {
            get
            {
                return (InputPipe<TInput5>) this._inputsAndOutputs.Inputs[4];
            }
        }

        public Tuple<InputPipe<TInput1>, InputPipe<TInput2>, InputPipe<TInput3>, InputPipe<TInput4>, InputPipe<TInput5>> Inputs
        {
            get
            {
                return Tuple.Create(Input1, Input2, Input3, Input4, Input5);
            }
        }

        public CollectorPipe<TOutput1> Output1
        {
            get
            {
                return (CollectorPipe<TOutput1>) this._inputsAndOutputs.Outputs[0];
            }
        }

        public Tuple<CollectorPipe<TOutput1>> Outputs
        {
            get
            {
                return Tuple.Create(Output1);
            }
        }

        public Tuple<InputPipe<TInput1>, InputPipe<TInput2>, InputPipe<TInput3>, InputPipe<TInput4>, InputPipe<TInput5>, CollectorPipe<TOutput1>> AsTuple()
        {
            return Tuple.Create(Input1, Input2, Input3, Input4, Input5, Output1);
        }

        public void Send(TInput1 value1, TInput2 value2, TInput3 value3, TInput4 value4, TInput5 value5)
        {
            this.Input1.Send(value1);
            this.Input2.Send(value2);
            this.Input3.Send(value3);
            this.Input4.Send(value4);
            this.Input5.Send(value5);
        }

    }
}
namespace Refactoring.Pipelines.InputsAndOutputs
{
    public class Inputs5AndOutputs2<TInput1, TInput2, TInput3, TInput4, TInput5, TOutput1, TOutput2>
    {
        private readonly InputsAndOutputs _inputsAndOutputs;

        public Inputs5AndOutputs2(IGraphNode node)
        {
            this._inputsAndOutputs = new InputsAndOutputs(node);
            Debug.Assert(_inputsAndOutputs.Inputs.Count == 5);
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

        public InputPipe<TInput3> Input3
        {
            get
            {
                return (InputPipe<TInput3>) this._inputsAndOutputs.Inputs[2];
            }
        }

        public InputPipe<TInput4> Input4
        {
            get
            {
                return (InputPipe<TInput4>) this._inputsAndOutputs.Inputs[3];
            }
        }

        public InputPipe<TInput5> Input5
        {
            get
            {
                return (InputPipe<TInput5>) this._inputsAndOutputs.Inputs[4];
            }
        }

        public Tuple<InputPipe<TInput1>, InputPipe<TInput2>, InputPipe<TInput3>, InputPipe<TInput4>, InputPipe<TInput5>> Inputs
        {
            get
            {
                return Tuple.Create(Input1, Input2, Input3, Input4, Input5);
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

        public Tuple<CollectorPipe<TOutput1>, CollectorPipe<TOutput2>> Outputs
        {
            get
            {
                return Tuple.Create(Output1, Output2);
            }
        }

        public Tuple<InputPipe<TInput1>, InputPipe<TInput2>, InputPipe<TInput3>, InputPipe<TInput4>, InputPipe<TInput5>, CollectorPipe<TOutput1>, CollectorPipe<TOutput2>> AsTuple()
        {
            return Tuple.Create(Input1, Input2, Input3, Input4, Input5, Output1, Output2);
        }

        public void Send(TInput1 value1, TInput2 value2, TInput3 value3, TInput4 value4, TInput5 value5)
        {
            this.Input1.Send(value1);
            this.Input2.Send(value2);
            this.Input3.Send(value3);
            this.Input4.Send(value4);
            this.Input5.Send(value5);
        }

    }
}
namespace Refactoring.Pipelines.InputsAndOutputs
{
    public class Inputs5AndOutputs3<TInput1, TInput2, TInput3, TInput4, TInput5, TOutput1, TOutput2, TOutput3>
    {
        private readonly InputsAndOutputs _inputsAndOutputs;

        public Inputs5AndOutputs3(IGraphNode node)
        {
            this._inputsAndOutputs = new InputsAndOutputs(node);
            Debug.Assert(_inputsAndOutputs.Inputs.Count == 5);
            Debug.Assert(_inputsAndOutputs.Outputs.Count == 3);
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

        public InputPipe<TInput3> Input3
        {
            get
            {
                return (InputPipe<TInput3>) this._inputsAndOutputs.Inputs[2];
            }
        }

        public InputPipe<TInput4> Input4
        {
            get
            {
                return (InputPipe<TInput4>) this._inputsAndOutputs.Inputs[3];
            }
        }

        public InputPipe<TInput5> Input5
        {
            get
            {
                return (InputPipe<TInput5>) this._inputsAndOutputs.Inputs[4];
            }
        }

        public Tuple<InputPipe<TInput1>, InputPipe<TInput2>, InputPipe<TInput3>, InputPipe<TInput4>, InputPipe<TInput5>> Inputs
        {
            get
            {
                return Tuple.Create(Input1, Input2, Input3, Input4, Input5);
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

        public CollectorPipe<TOutput3> Output3
        {
            get
            {
                return (CollectorPipe<TOutput3>) this._inputsAndOutputs.Outputs[2];
            }
        }

        public Tuple<CollectorPipe<TOutput1>, CollectorPipe<TOutput2>, CollectorPipe<TOutput3>> Outputs
        {
            get
            {
                return Tuple.Create(Output1, Output2, Output3);
            }
        }

        // AsTuple() not valid for more than 7 parameters

        public void Send(TInput1 value1, TInput2 value2, TInput3 value3, TInput4 value4, TInput5 value5)
        {
            this.Input1.Send(value1);
            this.Input2.Send(value2);
            this.Input3.Send(value3);
            this.Input4.Send(value4);
            this.Input5.Send(value5);
        }

    }
}
namespace Refactoring.Pipelines.InputsAndOutputs
{
    public class Inputs5AndOutputs4<TInput1, TInput2, TInput3, TInput4, TInput5, TOutput1, TOutput2, TOutput3, TOutput4>
    {
        private readonly InputsAndOutputs _inputsAndOutputs;

        public Inputs5AndOutputs4(IGraphNode node)
        {
            this._inputsAndOutputs = new InputsAndOutputs(node);
            Debug.Assert(_inputsAndOutputs.Inputs.Count == 5);
            Debug.Assert(_inputsAndOutputs.Outputs.Count == 4);
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

        public InputPipe<TInput3> Input3
        {
            get
            {
                return (InputPipe<TInput3>) this._inputsAndOutputs.Inputs[2];
            }
        }

        public InputPipe<TInput4> Input4
        {
            get
            {
                return (InputPipe<TInput4>) this._inputsAndOutputs.Inputs[3];
            }
        }

        public InputPipe<TInput5> Input5
        {
            get
            {
                return (InputPipe<TInput5>) this._inputsAndOutputs.Inputs[4];
            }
        }

        public Tuple<InputPipe<TInput1>, InputPipe<TInput2>, InputPipe<TInput3>, InputPipe<TInput4>, InputPipe<TInput5>> Inputs
        {
            get
            {
                return Tuple.Create(Input1, Input2, Input3, Input4, Input5);
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

        public CollectorPipe<TOutput3> Output3
        {
            get
            {
                return (CollectorPipe<TOutput3>) this._inputsAndOutputs.Outputs[2];
            }
        }

        public CollectorPipe<TOutput4> Output4
        {
            get
            {
                return (CollectorPipe<TOutput4>) this._inputsAndOutputs.Outputs[3];
            }
        }

        public Tuple<CollectorPipe<TOutput1>, CollectorPipe<TOutput2>, CollectorPipe<TOutput3>, CollectorPipe<TOutput4>> Outputs
        {
            get
            {
                return Tuple.Create(Output1, Output2, Output3, Output4);
            }
        }

        // AsTuple() not valid for more than 7 parameters

        public void Send(TInput1 value1, TInput2 value2, TInput3 value3, TInput4 value4, TInput5 value5)
        {
            this.Input1.Send(value1);
            this.Input2.Send(value2);
            this.Input3.Send(value3);
            this.Input4.Send(value4);
            this.Input5.Send(value5);
        }

    }
}
namespace Refactoring.Pipelines.InputsAndOutputs
{
    public class Inputs5AndOutputs5<TInput1, TInput2, TInput3, TInput4, TInput5, TOutput1, TOutput2, TOutput3, TOutput4, TOutput5>
    {
        private readonly InputsAndOutputs _inputsAndOutputs;

        public Inputs5AndOutputs5(IGraphNode node)
        {
            this._inputsAndOutputs = new InputsAndOutputs(node);
            Debug.Assert(_inputsAndOutputs.Inputs.Count == 5);
            Debug.Assert(_inputsAndOutputs.Outputs.Count == 5);
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

        public InputPipe<TInput3> Input3
        {
            get
            {
                return (InputPipe<TInput3>) this._inputsAndOutputs.Inputs[2];
            }
        }

        public InputPipe<TInput4> Input4
        {
            get
            {
                return (InputPipe<TInput4>) this._inputsAndOutputs.Inputs[3];
            }
        }

        public InputPipe<TInput5> Input5
        {
            get
            {
                return (InputPipe<TInput5>) this._inputsAndOutputs.Inputs[4];
            }
        }

        public Tuple<InputPipe<TInput1>, InputPipe<TInput2>, InputPipe<TInput3>, InputPipe<TInput4>, InputPipe<TInput5>> Inputs
        {
            get
            {
                return Tuple.Create(Input1, Input2, Input3, Input4, Input5);
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

        public CollectorPipe<TOutput3> Output3
        {
            get
            {
                return (CollectorPipe<TOutput3>) this._inputsAndOutputs.Outputs[2];
            }
        }

        public CollectorPipe<TOutput4> Output4
        {
            get
            {
                return (CollectorPipe<TOutput4>) this._inputsAndOutputs.Outputs[3];
            }
        }

        public CollectorPipe<TOutput5> Output5
        {
            get
            {
                return (CollectorPipe<TOutput5>) this._inputsAndOutputs.Outputs[4];
            }
        }

        public Tuple<CollectorPipe<TOutput1>, CollectorPipe<TOutput2>, CollectorPipe<TOutput3>, CollectorPipe<TOutput4>, CollectorPipe<TOutput5>> Outputs
        {
            get
            {
                return Tuple.Create(Output1, Output2, Output3, Output4, Output5);
            }
        }

        // AsTuple() not valid for more than 7 parameters

        public void Send(TInput1 value1, TInput2 value2, TInput3 value3, TInput4 value4, TInput5 value5)
        {
            this.Input1.Send(value1);
            this.Input2.Send(value2);
            this.Input3.Send(value3);
            this.Input4.Send(value4);
            this.Input5.Send(value5);
        }

    }
}
namespace Refactoring.Pipelines.InputsAndOutputs
{
    public class Inputs5AndOutputs6<TInput1, TInput2, TInput3, TInput4, TInput5, TOutput1, TOutput2, TOutput3, TOutput4, TOutput5, TOutput6>
    {
        private readonly InputsAndOutputs _inputsAndOutputs;

        public Inputs5AndOutputs6(IGraphNode node)
        {
            this._inputsAndOutputs = new InputsAndOutputs(node);
            Debug.Assert(_inputsAndOutputs.Inputs.Count == 5);
            Debug.Assert(_inputsAndOutputs.Outputs.Count == 6);
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

        public InputPipe<TInput3> Input3
        {
            get
            {
                return (InputPipe<TInput3>) this._inputsAndOutputs.Inputs[2];
            }
        }

        public InputPipe<TInput4> Input4
        {
            get
            {
                return (InputPipe<TInput4>) this._inputsAndOutputs.Inputs[3];
            }
        }

        public InputPipe<TInput5> Input5
        {
            get
            {
                return (InputPipe<TInput5>) this._inputsAndOutputs.Inputs[4];
            }
        }

        public Tuple<InputPipe<TInput1>, InputPipe<TInput2>, InputPipe<TInput3>, InputPipe<TInput4>, InputPipe<TInput5>> Inputs
        {
            get
            {
                return Tuple.Create(Input1, Input2, Input3, Input4, Input5);
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

        public CollectorPipe<TOutput3> Output3
        {
            get
            {
                return (CollectorPipe<TOutput3>) this._inputsAndOutputs.Outputs[2];
            }
        }

        public CollectorPipe<TOutput4> Output4
        {
            get
            {
                return (CollectorPipe<TOutput4>) this._inputsAndOutputs.Outputs[3];
            }
        }

        public CollectorPipe<TOutput5> Output5
        {
            get
            {
                return (CollectorPipe<TOutput5>) this._inputsAndOutputs.Outputs[4];
            }
        }

        public CollectorPipe<TOutput6> Output6
        {
            get
            {
                return (CollectorPipe<TOutput6>) this._inputsAndOutputs.Outputs[5];
            }
        }

        public Tuple<CollectorPipe<TOutput1>, CollectorPipe<TOutput2>, CollectorPipe<TOutput3>, CollectorPipe<TOutput4>, CollectorPipe<TOutput5>, CollectorPipe<TOutput6>> Outputs
        {
            get
            {
                return Tuple.Create(Output1, Output2, Output3, Output4, Output5, Output6);
            }
        }

        // AsTuple() not valid for more than 7 parameters

        public void Send(TInput1 value1, TInput2 value2, TInput3 value3, TInput4 value4, TInput5 value5)
        {
            this.Input1.Send(value1);
            this.Input2.Send(value2);
            this.Input3.Send(value3);
            this.Input4.Send(value4);
            this.Input5.Send(value5);
        }

    }
}

namespace Refactoring.Pipelines.InputsAndOutputs
{
    public static class Inputs6Extensions
    {
        public static Inputs<TInput1, TInput2, TInput3, TInput4, TInput5, TInput6> GetInputs<TInput1, TInput2, TInput3, TInput4, TInput5, TInput6>(this IGraphNode node)
        {
            return new Inputs<TInput1, TInput2, TInput3, TInput4, TInput5, TInput6>(node);
        }
    }
}
namespace Refactoring.Pipelines.InputsAndOutputs
{
    public class Inputs<TInput1, TInput2, TInput3, TInput4, TInput5, TInput6>
    {
        private readonly IGraphNode _node;
        public Inputs(IGraphNode node) { this._node = node; }

        public Inputs6AndOutputs1<TInput1, TInput2, TInput3, TInput4, TInput5, TInput6, TOutput1> AndOutputs<TOutput1>()
        {
            return new Inputs6AndOutputs1<TInput1, TInput2, TInput3, TInput4, TInput5, TInput6, TOutput1>(this._node);
        }

        public Inputs6AndOutputs2<TInput1, TInput2, TInput3, TInput4, TInput5, TInput6, TOutput1, TOutput2> AndOutputs<TOutput1, TOutput2>()
        {
            return new Inputs6AndOutputs2<TInput1, TInput2, TInput3, TInput4, TInput5, TInput6, TOutput1, TOutput2>(this._node);
        }

        public Inputs6AndOutputs3<TInput1, TInput2, TInput3, TInput4, TInput5, TInput6, TOutput1, TOutput2, TOutput3> AndOutputs<TOutput1, TOutput2, TOutput3>()
        {
            return new Inputs6AndOutputs3<TInput1, TInput2, TInput3, TInput4, TInput5, TInput6, TOutput1, TOutput2, TOutput3>(this._node);
        }

        public Inputs6AndOutputs4<TInput1, TInput2, TInput3, TInput4, TInput5, TInput6, TOutput1, TOutput2, TOutput3, TOutput4> AndOutputs<TOutput1, TOutput2, TOutput3, TOutput4>()
        {
            return new Inputs6AndOutputs4<TInput1, TInput2, TInput3, TInput4, TInput5, TInput6, TOutput1, TOutput2, TOutput3, TOutput4>(this._node);
        }

    }
}
namespace Refactoring.Pipelines.InputsAndOutputs
{
    public class Inputs6AndOutputs1<TInput1, TInput2, TInput3, TInput4, TInput5, TInput6, TOutput1>
    {
        private readonly InputsAndOutputs _inputsAndOutputs;

        public Inputs6AndOutputs1(IGraphNode node)
        {
            this._inputsAndOutputs = new InputsAndOutputs(node);
            Debug.Assert(_inputsAndOutputs.Inputs.Count == 6);
            Debug.Assert(_inputsAndOutputs.Outputs.Count == 1);
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

        public InputPipe<TInput3> Input3
        {
            get
            {
                return (InputPipe<TInput3>) this._inputsAndOutputs.Inputs[2];
            }
        }

        public InputPipe<TInput4> Input4
        {
            get
            {
                return (InputPipe<TInput4>) this._inputsAndOutputs.Inputs[3];
            }
        }

        public InputPipe<TInput5> Input5
        {
            get
            {
                return (InputPipe<TInput5>) this._inputsAndOutputs.Inputs[4];
            }
        }

        public InputPipe<TInput6> Input6
        {
            get
            {
                return (InputPipe<TInput6>) this._inputsAndOutputs.Inputs[5];
            }
        }

        public Tuple<InputPipe<TInput1>, InputPipe<TInput2>, InputPipe<TInput3>, InputPipe<TInput4>, InputPipe<TInput5>, InputPipe<TInput6>> Inputs
        {
            get
            {
                return Tuple.Create(Input1, Input2, Input3, Input4, Input5, Input6);
            }
        }

        public CollectorPipe<TOutput1> Output1
        {
            get
            {
                return (CollectorPipe<TOutput1>) this._inputsAndOutputs.Outputs[0];
            }
        }

        public Tuple<CollectorPipe<TOutput1>> Outputs
        {
            get
            {
                return Tuple.Create(Output1);
            }
        }

        public Tuple<InputPipe<TInput1>, InputPipe<TInput2>, InputPipe<TInput3>, InputPipe<TInput4>, InputPipe<TInput5>, InputPipe<TInput6>, CollectorPipe<TOutput1>> AsTuple()
        {
            return Tuple.Create(Input1, Input2, Input3, Input4, Input5, Input6, Output1);
        }

        public void Send(TInput1 value1, TInput2 value2, TInput3 value3, TInput4 value4, TInput5 value5, TInput6 value6)
        {
            this.Input1.Send(value1);
            this.Input2.Send(value2);
            this.Input3.Send(value3);
            this.Input4.Send(value4);
            this.Input5.Send(value5);
            this.Input6.Send(value6);
        }

    }
}
namespace Refactoring.Pipelines.InputsAndOutputs
{
    public class Inputs6AndOutputs2<TInput1, TInput2, TInput3, TInput4, TInput5, TInput6, TOutput1, TOutput2>
    {
        private readonly InputsAndOutputs _inputsAndOutputs;

        public Inputs6AndOutputs2(IGraphNode node)
        {
            this._inputsAndOutputs = new InputsAndOutputs(node);
            Debug.Assert(_inputsAndOutputs.Inputs.Count == 6);
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

        public InputPipe<TInput3> Input3
        {
            get
            {
                return (InputPipe<TInput3>) this._inputsAndOutputs.Inputs[2];
            }
        }

        public InputPipe<TInput4> Input4
        {
            get
            {
                return (InputPipe<TInput4>) this._inputsAndOutputs.Inputs[3];
            }
        }

        public InputPipe<TInput5> Input5
        {
            get
            {
                return (InputPipe<TInput5>) this._inputsAndOutputs.Inputs[4];
            }
        }

        public InputPipe<TInput6> Input6
        {
            get
            {
                return (InputPipe<TInput6>) this._inputsAndOutputs.Inputs[5];
            }
        }

        public Tuple<InputPipe<TInput1>, InputPipe<TInput2>, InputPipe<TInput3>, InputPipe<TInput4>, InputPipe<TInput5>, InputPipe<TInput6>> Inputs
        {
            get
            {
                return Tuple.Create(Input1, Input2, Input3, Input4, Input5, Input6);
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

        public Tuple<CollectorPipe<TOutput1>, CollectorPipe<TOutput2>> Outputs
        {
            get
            {
                return Tuple.Create(Output1, Output2);
            }
        }

        // AsTuple() not valid for more than 7 parameters

        public void Send(TInput1 value1, TInput2 value2, TInput3 value3, TInput4 value4, TInput5 value5, TInput6 value6)
        {
            this.Input1.Send(value1);
            this.Input2.Send(value2);
            this.Input3.Send(value3);
            this.Input4.Send(value4);
            this.Input5.Send(value5);
            this.Input6.Send(value6);
        }

    }
}
namespace Refactoring.Pipelines.InputsAndOutputs
{
    public class Inputs6AndOutputs3<TInput1, TInput2, TInput3, TInput4, TInput5, TInput6, TOutput1, TOutput2, TOutput3>
    {
        private readonly InputsAndOutputs _inputsAndOutputs;

        public Inputs6AndOutputs3(IGraphNode node)
        {
            this._inputsAndOutputs = new InputsAndOutputs(node);
            Debug.Assert(_inputsAndOutputs.Inputs.Count == 6);
            Debug.Assert(_inputsAndOutputs.Outputs.Count == 3);
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

        public InputPipe<TInput3> Input3
        {
            get
            {
                return (InputPipe<TInput3>) this._inputsAndOutputs.Inputs[2];
            }
        }

        public InputPipe<TInput4> Input4
        {
            get
            {
                return (InputPipe<TInput4>) this._inputsAndOutputs.Inputs[3];
            }
        }

        public InputPipe<TInput5> Input5
        {
            get
            {
                return (InputPipe<TInput5>) this._inputsAndOutputs.Inputs[4];
            }
        }

        public InputPipe<TInput6> Input6
        {
            get
            {
                return (InputPipe<TInput6>) this._inputsAndOutputs.Inputs[5];
            }
        }

        public Tuple<InputPipe<TInput1>, InputPipe<TInput2>, InputPipe<TInput3>, InputPipe<TInput4>, InputPipe<TInput5>, InputPipe<TInput6>> Inputs
        {
            get
            {
                return Tuple.Create(Input1, Input2, Input3, Input4, Input5, Input6);
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

        public CollectorPipe<TOutput3> Output3
        {
            get
            {
                return (CollectorPipe<TOutput3>) this._inputsAndOutputs.Outputs[2];
            }
        }

        public Tuple<CollectorPipe<TOutput1>, CollectorPipe<TOutput2>, CollectorPipe<TOutput3>> Outputs
        {
            get
            {
                return Tuple.Create(Output1, Output2, Output3);
            }
        }

        // AsTuple() not valid for more than 7 parameters

        public void Send(TInput1 value1, TInput2 value2, TInput3 value3, TInput4 value4, TInput5 value5, TInput6 value6)
        {
            this.Input1.Send(value1);
            this.Input2.Send(value2);
            this.Input3.Send(value3);
            this.Input4.Send(value4);
            this.Input5.Send(value5);
            this.Input6.Send(value6);
        }

    }
}
namespace Refactoring.Pipelines.InputsAndOutputs
{
    public class Inputs6AndOutputs4<TInput1, TInput2, TInput3, TInput4, TInput5, TInput6, TOutput1, TOutput2, TOutput3, TOutput4>
    {
        private readonly InputsAndOutputs _inputsAndOutputs;

        public Inputs6AndOutputs4(IGraphNode node)
        {
            this._inputsAndOutputs = new InputsAndOutputs(node);
            Debug.Assert(_inputsAndOutputs.Inputs.Count == 6);
            Debug.Assert(_inputsAndOutputs.Outputs.Count == 4);
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

        public InputPipe<TInput3> Input3
        {
            get
            {
                return (InputPipe<TInput3>) this._inputsAndOutputs.Inputs[2];
            }
        }

        public InputPipe<TInput4> Input4
        {
            get
            {
                return (InputPipe<TInput4>) this._inputsAndOutputs.Inputs[3];
            }
        }

        public InputPipe<TInput5> Input5
        {
            get
            {
                return (InputPipe<TInput5>) this._inputsAndOutputs.Inputs[4];
            }
        }

        public InputPipe<TInput6> Input6
        {
            get
            {
                return (InputPipe<TInput6>) this._inputsAndOutputs.Inputs[5];
            }
        }

        public Tuple<InputPipe<TInput1>, InputPipe<TInput2>, InputPipe<TInput3>, InputPipe<TInput4>, InputPipe<TInput5>, InputPipe<TInput6>> Inputs
        {
            get
            {
                return Tuple.Create(Input1, Input2, Input3, Input4, Input5, Input6);
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

        public CollectorPipe<TOutput3> Output3
        {
            get
            {
                return (CollectorPipe<TOutput3>) this._inputsAndOutputs.Outputs[2];
            }
        }

        public CollectorPipe<TOutput4> Output4
        {
            get
            {
                return (CollectorPipe<TOutput4>) this._inputsAndOutputs.Outputs[3];
            }
        }

        public Tuple<CollectorPipe<TOutput1>, CollectorPipe<TOutput2>, CollectorPipe<TOutput3>, CollectorPipe<TOutput4>> Outputs
        {
            get
            {
                return Tuple.Create(Output1, Output2, Output3, Output4);
            }
        }

        // AsTuple() not valid for more than 7 parameters

        public void Send(TInput1 value1, TInput2 value2, TInput3 value3, TInput4 value4, TInput5 value5, TInput6 value6)
        {
            this.Input1.Send(value1);
            this.Input2.Send(value2);
            this.Input3.Send(value3);
            this.Input4.Send(value4);
            this.Input5.Send(value5);
            this.Input6.Send(value6);
        }

    }
}
namespace Refactoring.Pipelines.InputsAndOutputs
{
    public class Inputs6AndOutputs5<TInput1, TInput2, TInput3, TInput4, TInput5, TInput6, TOutput1, TOutput2, TOutput3, TOutput4, TOutput5>
    {
        private readonly InputsAndOutputs _inputsAndOutputs;

        public Inputs6AndOutputs5(IGraphNode node)
        {
            this._inputsAndOutputs = new InputsAndOutputs(node);
            Debug.Assert(_inputsAndOutputs.Inputs.Count == 6);
            Debug.Assert(_inputsAndOutputs.Outputs.Count == 5);
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

        public InputPipe<TInput3> Input3
        {
            get
            {
                return (InputPipe<TInput3>) this._inputsAndOutputs.Inputs[2];
            }
        }

        public InputPipe<TInput4> Input4
        {
            get
            {
                return (InputPipe<TInput4>) this._inputsAndOutputs.Inputs[3];
            }
        }

        public InputPipe<TInput5> Input5
        {
            get
            {
                return (InputPipe<TInput5>) this._inputsAndOutputs.Inputs[4];
            }
        }

        public InputPipe<TInput6> Input6
        {
            get
            {
                return (InputPipe<TInput6>) this._inputsAndOutputs.Inputs[5];
            }
        }

        public Tuple<InputPipe<TInput1>, InputPipe<TInput2>, InputPipe<TInput3>, InputPipe<TInput4>, InputPipe<TInput5>, InputPipe<TInput6>> Inputs
        {
            get
            {
                return Tuple.Create(Input1, Input2, Input3, Input4, Input5, Input6);
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

        public CollectorPipe<TOutput3> Output3
        {
            get
            {
                return (CollectorPipe<TOutput3>) this._inputsAndOutputs.Outputs[2];
            }
        }

        public CollectorPipe<TOutput4> Output4
        {
            get
            {
                return (CollectorPipe<TOutput4>) this._inputsAndOutputs.Outputs[3];
            }
        }

        public CollectorPipe<TOutput5> Output5
        {
            get
            {
                return (CollectorPipe<TOutput5>) this._inputsAndOutputs.Outputs[4];
            }
        }

        public Tuple<CollectorPipe<TOutput1>, CollectorPipe<TOutput2>, CollectorPipe<TOutput3>, CollectorPipe<TOutput4>, CollectorPipe<TOutput5>> Outputs
        {
            get
            {
                return Tuple.Create(Output1, Output2, Output3, Output4, Output5);
            }
        }

        // AsTuple() not valid for more than 7 parameters

        public void Send(TInput1 value1, TInput2 value2, TInput3 value3, TInput4 value4, TInput5 value5, TInput6 value6)
        {
            this.Input1.Send(value1);
            this.Input2.Send(value2);
            this.Input3.Send(value3);
            this.Input4.Send(value4);
            this.Input5.Send(value5);
            this.Input6.Send(value6);
        }

    }
}
namespace Refactoring.Pipelines.InputsAndOutputs
{
    public class Inputs6AndOutputs6<TInput1, TInput2, TInput3, TInput4, TInput5, TInput6, TOutput1, TOutput2, TOutput3, TOutput4, TOutput5, TOutput6>
    {
        private readonly InputsAndOutputs _inputsAndOutputs;

        public Inputs6AndOutputs6(IGraphNode node)
        {
            this._inputsAndOutputs = new InputsAndOutputs(node);
            Debug.Assert(_inputsAndOutputs.Inputs.Count == 6);
            Debug.Assert(_inputsAndOutputs.Outputs.Count == 6);
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

        public InputPipe<TInput3> Input3
        {
            get
            {
                return (InputPipe<TInput3>) this._inputsAndOutputs.Inputs[2];
            }
        }

        public InputPipe<TInput4> Input4
        {
            get
            {
                return (InputPipe<TInput4>) this._inputsAndOutputs.Inputs[3];
            }
        }

        public InputPipe<TInput5> Input5
        {
            get
            {
                return (InputPipe<TInput5>) this._inputsAndOutputs.Inputs[4];
            }
        }

        public InputPipe<TInput6> Input6
        {
            get
            {
                return (InputPipe<TInput6>) this._inputsAndOutputs.Inputs[5];
            }
        }

        public Tuple<InputPipe<TInput1>, InputPipe<TInput2>, InputPipe<TInput3>, InputPipe<TInput4>, InputPipe<TInput5>, InputPipe<TInput6>> Inputs
        {
            get
            {
                return Tuple.Create(Input1, Input2, Input3, Input4, Input5, Input6);
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

        public CollectorPipe<TOutput3> Output3
        {
            get
            {
                return (CollectorPipe<TOutput3>) this._inputsAndOutputs.Outputs[2];
            }
        }

        public CollectorPipe<TOutput4> Output4
        {
            get
            {
                return (CollectorPipe<TOutput4>) this._inputsAndOutputs.Outputs[3];
            }
        }

        public CollectorPipe<TOutput5> Output5
        {
            get
            {
                return (CollectorPipe<TOutput5>) this._inputsAndOutputs.Outputs[4];
            }
        }

        public CollectorPipe<TOutput6> Output6
        {
            get
            {
                return (CollectorPipe<TOutput6>) this._inputsAndOutputs.Outputs[5];
            }
        }

        public Tuple<CollectorPipe<TOutput1>, CollectorPipe<TOutput2>, CollectorPipe<TOutput3>, CollectorPipe<TOutput4>, CollectorPipe<TOutput5>, CollectorPipe<TOutput6>> Outputs
        {
            get
            {
                return Tuple.Create(Output1, Output2, Output3, Output4, Output5, Output6);
            }
        }

        // AsTuple() not valid for more than 7 parameters

        public void Send(TInput1 value1, TInput2 value2, TInput3 value3, TInput4 value4, TInput5 value5, TInput6 value6)
        {
            this.Input1.Send(value1);
            this.Input2.Send(value2);
            this.Input3.Send(value3);
            this.Input4.Send(value4);
            this.Input5.Send(value5);
            this.Input6.Send(value6);
        }

    }
}
