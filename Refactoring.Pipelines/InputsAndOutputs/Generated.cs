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
