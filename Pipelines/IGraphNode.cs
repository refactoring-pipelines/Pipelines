using System.Collections.Generic;

namespace Pipelines
{
    public interface IGraphNode
    {
        string Name { get; }
        IEnumerable<IGraphNode> Parents { get; }
    }

    public interface IGraphNodeWithOutput : IGraphNode
    {
        IGraphNode Output { get; }
    }
}