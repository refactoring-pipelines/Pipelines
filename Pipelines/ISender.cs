using System.Collections.Generic;

namespace Pipelines
{
    public interface ISender<out T> : ISender
    {
        void AddListener(IListener<T> listener);
    }

    public interface ISender : IGraphNode
    {
        IGraphNode Collector { get; }
        IEnumerable<IGraphNode> Children { get; }
    }
}
