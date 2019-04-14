using System.Collections.Generic;

namespace Pipelines
{
    public abstract class Sender<T> : IGraphNode
    {
        protected readonly List<IListener<T>> _listeners = new List<IListener<T>>();

        public abstract string Name { get; }

        IEnumerable<IGraphNode> IGraphNode.Children => _listeners;

        public void AddListener(IListener<T> listener)
        {
            this._listeners.Add(listener);
        }

        protected void _Send(T value)
        {
            foreach (var listener in _listeners)
            {
                listener.OnMessage(value);
            }
        }
    }
}