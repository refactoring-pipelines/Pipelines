using System;
using System.IO;
using ApprovalTests.Reporters;

namespace Refactoring.Pipelines.Approvals
{
    public class DotReporter : GenericDiffReporter
    {
        public static readonly DotReporter INSTANCE = new DotReporter();

        public DotReporter() : base(new DiffInfo(VsCodeExePath, "-r {0}", () => new[] {"dot"})) { }

        private static string VsCodeExePath =>
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                @"Programs\Microsoft VS Code\Code.exe");
    }
}
