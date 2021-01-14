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

        public static FunctionPipe<T1, T2, TOutput> ProcessFunction<T1, T2, TOutput>(this Sender<T1> @this, Func<T1, T2, TOutput> func, Sender<T2> sender2)
        {
            AssertNotLambda(func);
            return new FunctionPipe<T1, T2, TOutput>(func, @this, sender2);
        }

        public static void AssertNotLambda<T, TOutput>(Func<T, TOutput> func)
        {
            bool IsLambda(Func<T, TOutput> func)
            {
                var invalidChars = new[] {'<', '>'};
                return func.Method.Name.Any(invalidChars.Contains);
            }

            if (IsLambda(func))
            {
                throw new Exception("Called ProcessFunction() with a lambda. Use Process() instead.");
            }
        }

        public static void AssertNotLambda<T1, T2, TOutput>(Func<T1, T2, TOutput> func)
        {
            bool IsLambda(Func<T1, T2, TOutput> func)
            {
                var invalidChars = new[] {'<', '>'};
                return func.Method.Name.Any(invalidChars.Contains);
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

        public static FunctionPipe<T1, T2, TOutput> Process<T1, T2, TOutput>(
            this Sender<T1> @this,
            Expression<Func<T1, T2, TOutput>> func,
            Sender<T2> sender2)
        {
            var name = func.ExpressionToReadableString();
            return new FunctionPipe<T1, T2, TOutput>(name, func.Compile(), @this, sender2);
        }


        public static FunctionPipe<T, TOutput> Process<T, TOutput>(
            this Sender<T> @this,
            string name,
            Func<T, TOutput> func)
        {
            return new FunctionPipe<T, TOutput>(name, func, @this);
        }

        public static FunctionPipe<T1, T2, TOutput> Process<T1, T2, TOutput>(
            this Sender<T1> @this,
            string name,
            Func<T1, T2, TOutput> func,
            Sender<T2> sender2)
        {
            return new FunctionPipe<T1, T2, TOutput>(name, func, @this, sender2);
        }
    }
}
