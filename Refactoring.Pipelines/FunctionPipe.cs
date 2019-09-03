using System;
using System.Collections.Generic;
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
}
