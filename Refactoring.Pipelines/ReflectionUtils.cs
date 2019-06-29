using System;
using System.Linq;

namespace Refactoring.Pipelines
{
    public static class ReflectionUtils
    {
        public static string ToReadableString(this Type type)
        {
            if (type.IsGenericType)
            {
                var mainType = type.Name.Substring(0, type.Name.LastIndexOf("`", StringComparison.InvariantCulture));
                var typeParameters = String.Join(", ", type.GetGenericArguments().Select(ToReadableString));
                return $"{mainType}<{typeParameters}>";
            }

            return type.Name;
        }
    }
}