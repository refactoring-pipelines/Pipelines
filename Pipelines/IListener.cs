namespace Pipelines
{
    public interface IListener<T> : IGraphNode
    {
        void OnMessage(T value);
    }
}