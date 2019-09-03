using System.Linq.Expressions;

namespace Refactoring.Pipelines.ExpressionUtilities
{
    static class NameUtilities
    {
        public static string ExpressionToReadableString<T>(this Expression<T> func)
        {
            return func.ToString().EverythingAfter("=> ");
        }

    }
}
