using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Refactoring.Pipelines.ExpressionUtilities;

namespace Refactoring.Pipelines
{
    public static class SenderExtensions
    {
        public static FunctionPipe<T, TOutput> ProcessFunction<T, TOutput>(this Sender<T> @this, Func<T, TOutput> func)
        {
            return new FunctionPipe<T, TOutput>(func, @this);
        }

        public static FunctionPipe<T, TOutput> Process<T, TOutput>(this Sender<T> @this, Expression<Func<T, TOutput>> func)
        {
            var name = func.ExpressionToReadableString();
            return new FunctionPipe<T, TOutput>(name, func.Compile(), @this);
        }


        public static FunctionPipe<T, TOutput> Process<T, TOutput>(this Sender<T> @this, string name, Func<T, TOutput> func)
        {
            return new FunctionPipe<T, TOutput>(name, func, @this);
        }
    }
}
