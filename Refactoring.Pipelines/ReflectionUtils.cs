using System;
using System.Linq;

namespace Refactoring.Pipelines.ReflectionUtilities
{
    public static class ReflectionUtils
    {
        public static string ToReadableString(this Type type)
        {
            if (type.IsGenericType)
            {
                var mainType = type.Name.Substring(0, type.Name.LastIndexOf("`", StringComparison.InvariantCulture));
                var typeParameters = string.Join(", ", type.GetGenericArguments().Select(ToReadableString));
                return $"{mainType}<{typeParameters}>";
            }

            return type.Name;
        }
    }
}
