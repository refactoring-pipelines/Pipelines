using System;
using System.Text;

namespace Pipelines
{
    public class InputPipe<T> : Sender<T>
    {
        private readonly string _label;

        public InputPipe(string label)
        {
            _label = label;
        }

        public override string Name => $@"{typeof(T).Name} {_label}";

        public void Send(T value)
        {
            _Send(value);
        }

        public FunctionPipe<T, TOutput> Process<TOutput>(Func<T, TOutput> func)
        {
            return new FunctionPipe<T, TOutput>(func, this);
        }
    }
}