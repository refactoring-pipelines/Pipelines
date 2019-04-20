namespace Pipelines
{
    interface IForwardingListener : IGraphNode
    {
        IGraphNode Owner { get; }
    }
}