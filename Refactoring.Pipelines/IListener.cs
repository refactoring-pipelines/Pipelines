namespace Refactoring.Pipelines
{
    public interface IListener<in T> : IGraphNode
    {
        void OnMessage(T value);
    }

    public interface IListener<in T1, in T2> : IGraphNode
    {
        void OnMessage1(T1 value);
        void OnMessage2(T2 value);
    }
}
