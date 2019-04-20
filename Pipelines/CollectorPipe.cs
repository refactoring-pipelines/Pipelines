using System.Collections.Generic;
using System.Linq;

namespace Pipelines
{
    public static class CollectorPipe
    {
        public static CollectorPipe<T> Collect<T>(this Sender<T> sender)
        {
            return new CollectorPipe<T>(sender);
        }
    }

    public class CollectorPipe<T> : IListener<T>
    {
        private readonly Sender<T> _predecessor;
        private readonly List<T> _results = new List<T>();

        public CollectorPipe(Sender<T> predecessor)
        {
            _predecessor = predecessor;
            predecessor.AddListener(this);
        }

        public T SingleResult => _results.Single();

        public bool IsEmpty => !_results.Any();


        public void OnMessage(T value)
        {
            _results.Add(value);
        }

        string IGraphNode.Name => "Collector";
    }
}