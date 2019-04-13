using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public void OnMessage(TInput input)
        {
            var result = _func(input);
            _Send(result);
        }

        public CollectorPipe<TOutput> Collect()
        {
            return new CollectorPipe<TOutput>(this);
        }

        public FunctionPipe<TOutput, TNext> Process<TNext>(Func<TOutput, TNext> func)
        {
            return new FunctionPipe<TOutput, TNext>(func, this);
        }

        public override string Name => $@"{_func.Method.DeclaringType.Name}.{_func.Method.Name}()";

        IEnumerable<ILabeledNode> ILabeledNode.Listeners => this._listeners;

        ILabeledNode IFunctionPipe.Predecessor => this.predecessor;
        ILabeledNode IFunctionPipe.Collector => this._listeners.OfType<CollectorPipe<TOutput>>().SingleOrDefault();
        ILabeledNode IFunctionPipe.Output => new OutputNode(this, _func.Method.ReturnType.Name);
    }

    class OutputNode : ILabeledNode
    {
        private IFunctionPipe functionPipe;
        private string name;

        public OutputNode(IFunctionPipe functionPipe, string name)
        {
            this.functionPipe = functionPipe;
            this.name = name;
        }

        string ILabeledNode.Name => name;

        IEnumerable<ILabeledNode> ILabeledNode.Listeners => Enumerable.Empty<ILabeledNode>();

        public override bool Equals(object other)
        {
            var that = other as OutputNode;
            return that != null && this.functionPipe == that.functionPipe;
        }

        

        public override int GetHashCode()
        {
            return 0;
        }
    }
}