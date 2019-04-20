using System;

namespace Pipelines
{
    public interface IJoinedPipes : IGraphNodeWithOutput
    {
        Tuple<IGraphNodeWithOutput, IGraphNodeWithOutput> Predecessors { get; }
        IGraphNode Collector { get; }
    }
}