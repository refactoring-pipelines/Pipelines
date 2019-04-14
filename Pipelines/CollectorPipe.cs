﻿using System.Collections.Generic;
using System.Linq;

namespace Pipelines
{
    public class CollectorPipe<T> : IListener<T>
    {
        private readonly Sender<T> _predecessor;
        private readonly List<T> _results = new List<T>();

        public CollectorPipe(Sender<T> predecessor)
        {
            _predecessor = predecessor;
            predecessor.AddListener(this);
        }


        public void OnMessage(T value)
        {
            _results.Add(value);
        }

        public T SingleResult => _results.Single();


        string IGraphNode.Name => "Collector";

        IEnumerable<IGraphNode> IGraphNode.Listeners => Enumerable.Empty<IGraphNode>();

    }
}