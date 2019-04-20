using System.Collections.Generic;
using System.Linq;

namespace Pipelines
{
    public abstract class Sender<T> : ISender
    {
        protected readonly List<IListener<T>> Listeners = new List<IListener<T>>();

        public abstract string Name { get; }

        IEnumerable<IGraphNode> ISender.Children => Listeners;

        public void AddListener(IListener<T> listener)
        {
            Listeners.Add(listener);
        }

        protected void _Send(T value)
        {
            foreach (var listener in Listeners) listener.OnMessage(value);
        }

        public IGraphNode Collector => Listeners.OfType<CollectorPipe<T>>().SingleOrDefault();
    }
}