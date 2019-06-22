namespace Refactoring.Pipelines
{
    public interface IListener<in T> : IGraphNode
    {
        void OnMessage(T value);
    }
}
