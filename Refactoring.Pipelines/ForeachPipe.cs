using System;
using System.Collections.Generic;
using System.Linq;

namespace Refactoring.Pipelines
{
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

    public static class CastPipe
    {
        public static FunctionPipe<TInput, TOutput> Cast<TInput, TOutput>(
            this ISender<TInput> sender) where TOutput : TInput 
        {
            return new FunctionPipe<TInput, TOutput>(
                $"Cast<{typeof(TOutput).Name}>",
                p => (TOutput)p,
                sender);
        }
    }
}
