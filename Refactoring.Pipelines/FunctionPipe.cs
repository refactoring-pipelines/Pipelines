using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Refactoring.Pipelines.ReflectionUtilities;

namespace Refactoring.Pipelines
{
    public class FunctionPipe<TInput, TOutput> : Sender<TOutput>, IListener<TInput>, IGraphNodeWithOutput
    {
        private readonly Func<TInput, TOutput> _func;
        private readonly ISender<TInput> _predecessor;

        public FunctionPipe(Func<TInput, TOutput> func, ISender<TInput> predecessor) : this(
            FunctionNameToReadableString(func),
            func,
            predecessor)
        {
        }

        public FunctionPipe(string name, Func<TInput, TOutput> func, ISender<TInput> predecessor)
        {
            Name = name;
            _func = func;
            _predecessor = predecessor;
            predecessor.AddListener(this);
        }

        IGraphNode IGraphNodeWithOutput.Output =>
            new OutputNode(this, OutputType.ToReadableString());

        IEnumerable<IGraphNode> ISender.Children =>
            Listeners;

        public void OnMessage(TInput input)
        {
            var result = _func(input);
            _Send(result);
        }

        public override string Name { get; }

        public override IEnumerable<IGraphNode> Parents =>
            new[] {_predecessor};

        public static string FunctionNameToReadableString(Func<TInput, TOutput> func)
        {
            return $@"{func.Method.DeclaringType.ToReadableString()}.{func.Method.Name}()";
        }
    }

    public class FunctionPipe<TInput1, TInput2, TOutput> : Sender<TOutput>, IListener<TInput1, TInput2>, IGraphNodeWithOutput
    {
        private readonly ForwardingListener<TInput1> _listener1;
        private readonly ForwardingListener<TInput2> _listener2;
        private readonly Func<TInput1, TInput2, TOutput> _func;
        private readonly ISender<TInput1> _sender1;
        private readonly ISender<TInput2> _sender2;
        private readonly ConcurrentQueue<TInput1> _values1 = new ConcurrentQueue<TInput1>();
        private readonly ConcurrentQueue<TInput2> _values2 = new ConcurrentQueue<TInput2>();

        public FunctionPipe(Func<TInput1, TInput2, TOutput> func, ISender<TInput1> sender1, ISender<TInput2> sender2) : this(
            FunctionNameToReadableString(func),
            func,
            sender1, 
            sender2)
        {
        }

        public FunctionPipe(string name, Func<TInput1, TInput2, TOutput> func, ISender<TInput1> sender1, ISender<TInput2> sender2)
        {
            _listener1 = new ForwardingListener<TInput1>(this, OnMessage1);
            _listener2 = new ForwardingListener<TInput2>(this, OnMessage2);
            Name = name;
            _func = func;
            _sender1 = sender1;
            _sender2 = sender2;
            sender1.AddListener(_listener1);
            sender2.AddListener(_listener2);
        }

        public override IEnumerable<IGraphNode> Parents =>
            new IGraphNode[] {_sender1, _sender2};

        IGraphNode IGraphNodeWithOutput.Output =>
            new OutputNode(this, OutputType.ToReadableString());

        public void OnMessage1(TInput1 value)
        {
            _values1.Enqueue(value);
            _SendIfReady();
        }

        public void OnMessage2(TInput2 value)
        {
            _values2.Enqueue(value);
            _SendIfReady();
        }

        private void _SendIfReady()
        {
            if (_values1.Any() && _values2.Any())
            {
                _values1.TryDequeue(out TInput1 value1);
                _values2.TryDequeue(out TInput2 value2);
                _Send(_func(value1, value2));
            }
        }

        IEnumerable<IGraphNode> ISender.Children =>
            Listeners;

        public override string Name { get; }

        public static string FunctionNameToReadableString(Func<TInput1, TInput2, TOutput> func)
        {
            return $@"{func.Method.DeclaringType.ToReadableString()}.{func.Method.Name}()";
        }
    }
}
