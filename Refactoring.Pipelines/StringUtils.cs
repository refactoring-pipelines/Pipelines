namespace Refactoring.Pipelines
{
    public static class StringUtils
    {
        public static string EverythingAfter(this string @this, string s)
        {
            return @this.Substring(@this.IndexOf(s) + s.Length);
        }
    }
}
