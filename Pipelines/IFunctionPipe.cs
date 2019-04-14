namespace Pipelines
{
    internal interface IFunctionPipe : IGraphNode
    {
        IGraphNode Predecessor { get; }
        IGraphNode Collector { get; }
        IGraphNode Output { get; }
    }
}