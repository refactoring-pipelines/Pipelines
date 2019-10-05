namespace Refactoring.Pipelines
{
    public interface IForwardingListener : IGraphNode
    {
        IGraphNode Owner { get; }
    }
}
