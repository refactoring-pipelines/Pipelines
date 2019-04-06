using System.Collections.Generic;
using System.Linq;

namespace Pipelines
{
    public class CollectorPipe<T> : IListener<T>
    {
        private static int counter;
        private readonly int _counter;
        private readonly Sender<T> _predecessor;
        private readonly List<T> _results = new List<T>();

        public CollectorPipe(Sender<T> predecessor)
        {
            _counter = counter++;
            _predecessor = predecessor;
            predecessor.AddListener(this);
        }


        public void OnMessage(T value)
        {
            _results.Add(value);
        }

        public T SingleResult => _results.Single();

        public virtual string NodeName => $"Collector{_counter}";

        public string PrintFormatting()
        {
            return $@"
{NodeName} [label=""Collector"", color=""#c361f4""]
{{ rank=same; {_predecessor.NodeName}, {NodeName}}}
";
        }
    }
}