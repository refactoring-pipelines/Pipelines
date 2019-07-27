using System;

namespace Refactoring.Pipelines
{
    static class TupleHelpers
    {
        public static FunctionPipe<Tuple<A, B>, TOutput> Process<A, B, TOutput>(
            this Sender<Tuple<A, B>> sender,
            Func<A, B, TOutput> func)
        {
            return sender.ProcessFunction(t => func(t.Item1, t.Item2));
        }

        public static FunctionPipe<Tuple<Tuple<A, B>, C>, Tuple<A, B, C>> Flatten<A, B, C>(this Sender<Tuple<Tuple<A, B>, C>> sender)
        {
            return sender.ProcessFunction(t => Tuple.Create(t.Item1.Item1, t.Item1.Item2, t.Item2));
        }
    }
}