using System;
using System.IO;
using ApprovalTests.Reporters;

namespace Pipelines.Test
{
    internal class DotReporter : GenericDiffReporter
    {
        public DotReporter() : base(new DiffInfo(VsCodeExePath,
            "-r {0}", () => new[] {"dot"}))
        {
        }

        private static string VsCodeExePath => Path.Join(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            @"Programs\Microsoft VS Code\Code.exe");
    }
}