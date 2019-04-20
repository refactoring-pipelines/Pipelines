using System.Collections.Generic;

namespace Pipelines
{
    public interface ISender : IGraphNode
    {
        IGraphNode Collector { get; }
        IEnumerable<IGraphNode> Children { get; }
    }
}