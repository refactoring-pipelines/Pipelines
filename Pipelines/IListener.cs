namespace Pipelines
{
    public interface IListener<T> : ILabeledNode
    {
        void OnMessage(T value);
    }
}