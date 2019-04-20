namespace Pipelines
{
    public interface IGraphNode
    {
        string Name { get; }
    }

    public interface IGraphNodeWithOutput : IGraphNode
    {
        IGraphNode Output { get; }
    }
}