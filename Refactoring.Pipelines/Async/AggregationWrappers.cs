using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// The code in this file is a cheat, not well tested, and some of it is not actually Async despite the namespace name.

namespace Refactoring.Pipelines.Async
{
    public static class JoinedPipes
    {
        public static JoinedPipes<TOutput1, TOutput2> JoinTo<TOutput1, TOutput2>(
            this ISender<TOutput1> sender1,
            ISender<TOutput2> sender2)
        {
            return new JoinedPipes<TOutput1, TOutput2>(sender1, sender2);
        }
    }

    public static class ConcattedPipes
    {
        public static ConcattedPipes<TOutput> ConcatWith<TOutput>(
            this ISender<IEnumerable<TOutput>> sender1,
            ISender<IEnumerable<TOutput>> sender2)
        {
            return new ConcattedPipes<TOutput>(sender1, sender2);
        }
    }

    public static class ForeachPipe
    {
        public static FunctionPipe<IEnumerable<TInput>, List<TOutput>> ProcessForEach<TInput, TOutput>(
            this ISender<IEnumerable<TInput>> sender,
            Func<TInput, TOutput> func)
        {
            return new FunctionPipe<IEnumerable<TInput>, List<TOutput>>(
                $"Foreach({FunctionPipe<TInput, TOutput>.FunctionNameToReadableString(func)})",
                p => p.Select(func).ToList(),
                sender);
        }
    }

    public static class AppliedPipes
    {
        public static AppliedPipes<TOutput1, TOutput2> ApplyTo<TOutput1, TOutput2>(
            this ISender<TOutput1> sender1,
            ISender<IEnumerable<TOutput2>> sender2)
        {
            return new AppliedPipes<TOutput1, TOutput2>(sender1, sender2);
        }
    }
}
