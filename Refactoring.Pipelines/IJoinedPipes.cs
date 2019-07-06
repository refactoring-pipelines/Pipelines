using System;

namespace Refactoring.Pipelines
{
    public interface IJoinedPipes : IGraphNodeWithOutput, ISender
    {
        Tuple<IGraphNode, IGraphNode> Predecessors { get; }
    }
}
