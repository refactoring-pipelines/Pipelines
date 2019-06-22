namespace Pipelines
{
    internal interface IForwardingListener : IGraphNode
    {
        IGraphNode Owner { get; }
    }
}
