using System.Collections.Generic;
using System.Linq;
using Refactoring.Pipelines.ReflectionUtilities;

namespace Refactoring.Pipelines
{
    public class InputPipe<T> : Sender<T>, IInputNode
    {
        private readonly string _label;

        public InputPipe(string label) { _label = label; }

        public override string Name =>
            $@"{typeof(T).ToReadableString()} {_label}";

        public override IEnumerable<IGraphNode> Parents =>
            Enumerable.Empty<IGraphNode>();

        public void Send(T value) { _Send(value); }
    }

    public interface IInputNode
    {
    }
}
