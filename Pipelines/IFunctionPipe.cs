namespace Pipelines
{
    internal interface IFunctionPipe : IGraphNodeWithOutput, ISender
    {
        IGraphNode Predecessor { get; }
    }
}