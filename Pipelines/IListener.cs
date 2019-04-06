namespace Pipelines
{
    public interface IListener<T> : INameableNode
    {
        void OnMessage(T value);
    }
}