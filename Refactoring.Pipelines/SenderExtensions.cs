using System;
using System.Linq;
using System.Linq.Expressions;
using Refactoring.Pipelines.ExpressionUtilities;

namespace Refactoring.Pipelines
{
    public static class SenderExtensions
    {
        public static FunctionPipe<T, TOutput> ProcessFunction<T, TOutput>(this Sender<T> @this, Func<T, TOutput> func)
        {
            AssertNotLambda(func);
            return new FunctionPipe<T, TOutput>(func, @this);
        }

        public static void AssertNotLambda<T, TOutput>(Func<T, TOutput> func)
        {
            bool IsLambda(Func<T, TOutput> func2)
            {
                var invalidChars = new[] {'<', '>'};
                return func2.Method.Name.Any(invalidChars.Contains);
            }

            if (IsLambda(func))
            {
                throw new Exception("Called ProcessFunction() with a lambda. Use Process() instead.");
            }
        }

        public static FunctionPipe<T, TOutput> Process<T, TOutput>(
            this Sender<T> @this,
            Expression<Func<T, TOutput>> func)
        {
            var name = func.ExpressionToReadableString();
            return new FunctionPipe<T, TOutput>(name, func.Compile(), @this);
        }


        public static FunctionPipe<T, TOutput> Process<T, TOutput>(
            this Sender<T> @this,
            string name,
            Func<T, TOutput> func)
        {
            return new FunctionPipe<T, TOutput>(name, func, @this);
        }
    }
}
