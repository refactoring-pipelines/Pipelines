using System.Collections.Generic;

namespace Pipelines
{
    public interface IGraphNode
    {
        string Name { get; }

        IEnumerable<IGraphNode> Children { get; }
    }
}