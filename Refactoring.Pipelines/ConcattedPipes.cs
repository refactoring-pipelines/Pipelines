﻿using System.Collections.Generic;
using System.Linq;
using Refactoring.Pipelines.ReflectionUtilities;

namespace Refactoring.Pipelines
{
    public static class ConcattedPipes
    {
        public static ConcattedPipes<TOutput> ConcatWith<TOutput>(
            this ISender<IEnumerable<TOutput>> sender1,
            ISender<IEnumerable<TOutput>> sender2)
        {
            return new ConcattedPipes<TOutput>(sender1, sender2);
        }
    }

    public class ConcattedPipes<T> : Sender<List<T>>, IGraphNodeWithOutput
    {
        private readonly ForwardingListener<IEnumerable<T>> _listener1;
        private readonly ForwardingListener<IEnumerable<T>> _listener2;
        private readonly ISender<IEnumerable<T>> _sender1;
        private readonly ISender<IEnumerable<T>> _sender2;
        private readonly Queue<IEnumerable<T>> _values1 = new Queue<IEnumerable<T>>();
        private readonly Queue<IEnumerable<T>> _values2 = new Queue<IEnumerable<T>>();

        private ConcattedPipes()
        {
            _listener1 = new ForwardingListener<IEnumerable<T>>(this, OnMessage1);
            _listener2 = new ForwardingListener<IEnumerable<T>>(this, OnMessage2);
        }

        public ConcattedPipes(ISender<IEnumerable<T>> sender1, ISender<IEnumerable<T>> sender2) : this()
        {
            _sender1 = sender1;
            _sender2 = sender2;
            sender1.AddListener(_listener1);
            sender2.AddListener(_listener2);
        }

        public override string Name =>
            "ConcatWith";

        public override IEnumerable<IGraphNode> Parents =>
            new IGraphNode[] {_sender1, _sender2};

        IGraphNode IGraphNodeWithOutput.Output =>
            new OutputNode(this, OutputType.ToReadableString());

        private void OnMessage1(IEnumerable<T> value)
        {
            _values1.Enqueue(value);
            _SendIfReady();
        }

        private void OnMessage2(IEnumerable<T> value)
        {
            _values2.Enqueue(value);
            _SendIfReady();
        }

        private void _SendIfReady()
        {
            if (_values1.Any() && _values2.Any())
            {
                var values1 = _values1.Dequeue();
                var values2 = _values2.Dequeue();
                var result = values1.Concat(values2).ToList();
                _Send(result);
            }
        }
    }
}
