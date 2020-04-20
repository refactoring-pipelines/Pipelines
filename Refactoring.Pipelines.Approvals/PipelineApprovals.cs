using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using ApprovalTests;
using ApprovalTests.Core;
using ApprovalTests.Writers;
using DiffEngine;
using EmptyFiles;

namespace Refactoring.Pipelines.ApprovalTests
{
    public class PipelineApprovals
    {
        static PipelineApprovals()
        {
            Extensions.AddTextExtension("dot");
            var exePaths =new string[]
            {
                Environment.ExpandEnvironmentVariables(@"%LocalAppData%\Programs\Microsoft VS Code\code.exe"),
                Environment.ExpandEnvironmentVariables(@"%LocalAppData%\Programs\Microsoft VS Code\code.exe"),
            };
            var exePath = exePaths.FirstOrDefault(File.Exists);
            if (exePath !=null)
            {
                DiffTools.AddCustomTool(DiffTool.VisualStudioCode,
                    buildArguments: (tempFile, targetFile) => { return $"-r \"{tempFile}\""; });
            }
        }

        public static void Verify(IGraphNode input)
        {
            var dotGraph = DotGraph.DotGraph.FromPipeline(input);
            Approvals.Verify(WriterFactory.CreateTextWriter(dotGraph.ToString(), "dot"));
        }
    }
}


using ApprovalTests.Reporters;

namespace Refactoring.Pipelines.ApprovalTests
{
    public class DotReporter : IEnvironmentAwareReporter
    {
        public static readonly DotReporter INSTANCE = new DotReporter();

        public DotReporter()
        {
            Extensions.AddTextExtension("dot");
        }

        public void Report(string approved, string received)
        {
            var exePath = FindExePath();
            if (exePath != null)
            {
                Process.Start(exePath, $"-r \"{received}\"");
            }
        }

        private static string FindExePath()
        {
            var exePaths = new[]
            {
                Environment.ExpandEnvironmentVariables(@"%LocalAppData%\Programs\Microsoft VS Code\code.exe"),
                Environment.ExpandEnvironmentVariables(@"%ProgramFiles%\Microsoft VS Code\bin\Code.cmd"),
            };
            return exePaths.FirstOrDefault(File.Exists);
        }

        public bool IsWorkingInThisEnvironment(string forFile)
        {
            return Path.GetExtension(forFile) == ".dot" && FindExePath() != null;
        }
    }
}
