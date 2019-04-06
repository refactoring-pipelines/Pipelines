using System.Collections.Generic;

namespace Pipelines
{
    public class CollectorPipe<T> : IListener<T>
    {
        List<T> _results = new List<T>();

        public CollectorPipe(Sender<T> predecessor)
        {
            predecessor.AddListener(this);
        }

        public void OnMessage(T value)
        {
            this._results.Add(value);
        }
    }
}