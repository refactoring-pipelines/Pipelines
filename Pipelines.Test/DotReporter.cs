using ApprovalTests.Reporters;

namespace Pipelines.Test
{
    internal class DotReporter : GenericDiffReporter
    {
        public DotReporter() : base(new DiffInfo(VsCodeExePath,
            "-r {0}", () => new[] {"dot"}))
        {
        }

        private static string VsCodeExePath => @"C:\Users\jbazuzi\AppData\Local\Programs\Microsoft VS Code\Code.exe";
    }
}