using System;
using System.Threading.Tasks;

namespace Refactoring.Pipelines.Async
{
    public class FunctionPipe<TInput, TOutput> : Pipelines.FunctionPipe<TInput, TOutput>
    {
        public FunctionPipe(Func<TInput, TOutput> func, ISender<TInput> predecessor) : base(func, predecessor) { }

        public FunctionPipe(string name, Func<TInput, TOutput> func, ISender<TInput> predecessor) : base(
            name,
            func,
            predecessor)
        {
        }

        protected override void _Send(TOutput value)
        {
            Parallel.ForEach(Listeners, listener => { listener.OnMessage(value); });
        }
    }
}
