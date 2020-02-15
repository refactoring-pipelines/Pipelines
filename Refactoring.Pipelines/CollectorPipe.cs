using System.Collections.Generic;
using System.Linq;

namespace Refactoring.Pipelines
{
    public static class CollectorPipe
    {
        public static CollectorPipe<T> Collect<T>(this ISender<T> sender) { return new CollectorPipe<T>(sender); }
    }

    public interface ICollectorNode { }

    public class CollectorPipe<T> : IListener<T>, ICollectorNode
    {
        private readonly ISender<T> _predecessor;
        private readonly List<T> _results = new List<T>();

        public CollectorPipe(ISender<T> predecessor)
        {
            _predecessor = predecessor;
            predecessor.AddListener(this);
        }

        public T SingleResult =>
            _results.Single();

        public bool IsEmpty =>
            !_results.Any();

        IEnumerable<IGraphNode> IGraphNode.Parents =>
            new[] {_predecessor};

        public void OnMessage(T value) { _results.Add(value); }

        string IGraphNode.Name =>
            "Collector";
    }
}
