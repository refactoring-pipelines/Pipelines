using ApprovalTests.Reporters;

namespace Pipelines.Test
{
    internal class DotReporter : GenericDiffReporter
    {
        public DotReporter() : base(new DiffInfo(@"C:\Users\jbazuzi\AppData\Local\Programs\Microsoft VS Code\Code.exe",
            "-r {0}", () => new[] {"dot"}))
        {
        }
    }
}