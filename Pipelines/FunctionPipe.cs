using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pipelines
{
    public class FunctionPipe<TInput, TOutput> : Sender<TOutput>, IListener<TInput>
    {
        private readonly Func<TInput, TOutput> _func;

        public FunctionPipe(Func<TInput, TOutput> func, Sender<TInput> predecessor)
        {
            _func = func;
            predecessor.AddListener(this);
        }

        public override string NodeName => $@"""{_func.Method.DeclaringType.Name}.{_func.Method.Name}() -> {typeof(TOutput).Name}""";

        public void OnMessage(TInput input)
        {
            var result = _func(input);
            _Send(result);
        }

        public CollectorPipe<TOutput> Collect()
        {
            return new CollectorPipe<TOutput>(this);
        }

        IEnumerable<ILabeledNode>  ILabeledNode.Listeners => this._listeners;
    }
}