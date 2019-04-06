using System.Collections.Generic;

namespace Pipelines
{
    public abstract class Sender<T> : INameableNode
    {
        protected readonly List<IListener<T>> _listeners = new List<IListener<T>>();

        public abstract string NodeName { get; }

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