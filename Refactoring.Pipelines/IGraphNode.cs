using System.Collections.Generic;

namespace Refactoring.Pipelines
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
