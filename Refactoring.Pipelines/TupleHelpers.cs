using System;
using System.Linq.Expressions;
using Refactoring.Pipelines.ExpressionUtilities;

namespace Refactoring.Pipelines
{
    internal static class TupleHelpers
    {
        public static FunctionPipe<Tuple<A, B>, TOutput> Process<A, B, TOutput>(
            this Sender<Tuple<A, B>> sender,
            Expression<Func<A, B, TOutput>> func)
        {
            return sender.Process(func.ExpressionToReadableString(), t => func.Compile()(t.Item1, t.Item2));
        }

        public static FunctionPipe<Tuple<Tuple<A, B>, C>, Tuple<A, B, C>> Flatten<A, B, C>(
            this Sender<Tuple<Tuple<A, B>, C>> sender)
        {
            return sender.Process("Flatten", t => Tuple.Create(t.Item1.Item1, t.Item1.Item2, t.Item2));
        }
    }
}
