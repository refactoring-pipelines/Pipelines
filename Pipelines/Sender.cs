using System.Collections.Generic;

namespace Pipelines
{
    public abstract class Sender<T> : IGraphNode
    {
        protected readonly List<IListener<T>> Listeners = new List<IListener<T>>();

        public abstract string Name { get; }

        IEnumerable<IGraphNode> IGraphNode.Children => Listeners;

        public void AddListener(IListener<T> listener)
        {
            Listeners.Add(listener);
        }

        protected void _Send(T value)
        {
            foreach (var listener in Listeners) listener.OnMessage(value);
        }
    }
}