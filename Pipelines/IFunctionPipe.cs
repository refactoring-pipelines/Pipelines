namespace Pipelines
{
    internal interface IFunctionPipe : IGraphNodeWithOutput
    {
        IGraphNode Predecessor { get; }
        IGraphNode Collector { get; }
    }
}