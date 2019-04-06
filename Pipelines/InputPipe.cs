using System;

namespace Pipelines
{
    public class InputPipe<T> : Sender<T>
    {
        private readonly string _label;

        public InputPipe(string label)
        {
            _label = label;
        }

        public void Send(T value)
        {
            _Send(value);
        }


        public FunctionPipe<T, TOutput> Process<TOutput>(Func<T, TOutput> func)
        {
            return new FunctionPipe<T, TOutput>(func, this);
        }

        public override string ToString()
        {
            var nodeName = $@"""{typeof(T).Name} {_label}""";
            return $@"
    {nodeName} -> ""CharacterFile.From()""  -> {{Collector1 , CharacterFile}}
    {nodeName} [color=green,shape=rect, style=filled]
";
        }
    }
}
