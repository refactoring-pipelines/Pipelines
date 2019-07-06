using System;

namespace Refactoring.Pipelines
{
    static class TupleHelpers
    {
        public static FunctionPipe<Tuple<A, B>, TOutput> Process<A, B, TOutput>(
            this Sender<Tuple<A, B>> sender,
            Func<A, B, TOutput> func)
        {
            return sender.Process(t => func(t.Item1, t.Item2));
        }
    }
}