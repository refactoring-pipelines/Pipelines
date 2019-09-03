using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Refactoring.Pipelines.ExpressionUtilities;

namespace Refactoring.Pipelines
{
    public abstract class Sender<T> : ISender<T>
    {
        protected readonly List<IListener<T>> Listeners = new List<IListener<T>>();

        public Type OutputType =>
            typeof(T);

        public abstract string Name { get; }

        IEnumerable<IGraphNode> ISender.Children =>
            Listeners;

        public IGraphNode Collector =>
            Listeners.OfType<CollectorPipe<T>>().SingleOrDefault();

        public void AddListener(IListener<T> listener) { Listeners.Add(listener); }

        public abstract IEnumerable<IGraphNode> Parents { get; }

        protected void _Send(T value)
        {
            foreach (var listener in Listeners)
            {
                listener.OnMessage(value);
            }
        }

        public FunctionPipe<T, TOutput> ProcessFunction<TOutput>(Func<T, TOutput> func)
        {
            return new FunctionPipe<T, TOutput>(func, this);
        }

        public FunctionPipe<T, TOutput> Process<TOutput>(Expression<Func<T, TOutput>> func)
        {
            var name = func.ExpressionToReadableString();
            return new FunctionPipe<T, TOutput>(name, func.Compile(), this);
        }



        public FunctionPipe<T, TOutput> Process<TOutput>(string name, Func<T, TOutput> func)
        {
            return new FunctionPipe<T, TOutput>(name, func, this);
        }
    }
}

namespace Refactoring.Pipelines.ExpressionUtilities
{
}