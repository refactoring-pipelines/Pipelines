namespace Pipelines
{
    public interface IListener<T>
    {
        void OnMessage(T value);
    }
}