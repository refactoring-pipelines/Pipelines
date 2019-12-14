using System.Reflection;
using Refactoring.Pipelines.ReflectionUtilities;

public interface IVisualizer
{
    bool IsValidFor(object instance);
    string Visualize(object instance);
}

public class MethodNameVisualizer : IVisualizer
{
    public static string FunctionNameToReadableString(MethodInfo methodInfo)
    {
        return $@"{methodInfo.DeclaringType.ToReadableString()}.{methodInfo.Name}()";
    }

    public bool IsValidFor(object instance) { return instance is MethodInfo; }

    public string Visualize(object instance)
    {
        return FunctionNameToReadableString(instance as MethodInfo);
    }
}