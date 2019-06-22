namespace Refactoring.Pipelines
{
    public interface IFunctionPipe : IGraphNodeWithOutput, ISender
    {
        IGraphNode Predecessor { get; }
    }
}
