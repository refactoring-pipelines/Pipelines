using System;
using System.Collections.Generic;
using System.Linq;

namespace Pipelines
{
    public class FunctionPipe<TInput, TOutput> : Sender<TOutput>, IListener<TInput>, IFunctionPipe
    {
        private readonly Func<TInput, TOutput> _func;
        private readonly Sender<TInput> predecessor;

        public FunctionPipe(Func<TInput, TOutput> func, Sender<TInput> predecessor)
        {
            _func = func;
            this.predecessor = predecessor;
            predecessor.AddListener(this);
        }

        IGraphNode IFunctionPipe.Predecessor => predecessor;
        IGraphNode IFunctionPipe.Collector => _listeners.OfType<CollectorPipe<TOutput>>().SingleOrDefault();
        IGraphNode IFunctionPipe.Output => new OutputNode(this, _func.Method.ReturnType.Name);

        public void OnMessage(TInput input)
        {
            var result = _func(input);
            _Send(result);
        }

        public override string Name => $@"{_func.Method.DeclaringType.Name}.{_func.Method.Name}()";

        IEnumerable<IGraphNode> IGraphNode.Children => _listeners;

        public CollectorPipe<TOutput> Collect()
        {
            return new CollectorPipe<TOutput>(this);
        }

        public FunctionPipe<TOutput, TNext> Process<TNext>(Func<TOutput, TNext> func)
        {
            return new FunctionPipe<TOutput, TNext>(func, this);
        }
    }

    internal class OutputNode : IGraphNode
    {
        private readonly IFunctionPipe functionPipe;
        private readonly string name;

        public OutputNode(IFunctionPipe functionPipe, string name)
        {
            this.functionPipe = functionPipe;
            this.name = name;
        }

        string IGraphNode.Name => name;

        IEnumerable<IGraphNode> IGraphNode.Children => Enumerable.Empty<IGraphNode>();

        public override bool Equals(object other)
        {
            var that = other as OutputNode;
            return that != null && functionPipe == that.functionPipe;
        }


        public override int GetHashCode()
        {
            return 0;
        }
    }
}