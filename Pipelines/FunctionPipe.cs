using System;
using System.Collections.Generic;
using System.Linq;

namespace Pipelines
{
    public class FunctionPipe<TInput, TOutput> : Sender<TOutput>, IListener<TInput>, IFunctionPipe
    {
        private readonly Func<TInput, TOutput> _func;
        private readonly Sender<TInput> _predecessor;

        public FunctionPipe(Func<TInput, TOutput> func, Sender<TInput> predecessor)
        {
            _func = func;
            this._predecessor = predecessor;
            predecessor.AddListener(this);
        }

        IGraphNode IFunctionPipe.Predecessor => _predecessor;
        IGraphNode IFunctionPipe.Collector => Listeners.OfType<CollectorPipe<TOutput>>().SingleOrDefault();
        IGraphNode IFunctionPipe.Output => new OutputNode(this, _func.Method.ReturnType.Name);

        public void OnMessage(TInput input)
        {
            var result = _func(input);
            _Send(result);
        }

        public override string Name => $@"{_func.Method.DeclaringType.Name}.{_func.Method.Name}()";

        IEnumerable<IGraphNode> IGraphNode.Children => Listeners;

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
        private readonly IFunctionPipe _functionPipe;
        private readonly string _name;

        public OutputNode(IFunctionPipe functionPipe, string name)
        {
            this._functionPipe = functionPipe;
            this._name = name;
        }

        string IGraphNode.Name => _name;

        IEnumerable<IGraphNode> IGraphNode.Children => Enumerable.Empty<IGraphNode>();

        public override bool Equals(object other)
        {
            var that = other as OutputNode;
            return that != null && _functionPipe == that._functionPipe;
        }


        public override int GetHashCode()
        {
            return 0;
        }
    }
}