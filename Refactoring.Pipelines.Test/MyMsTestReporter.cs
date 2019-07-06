using System.IO;
using ApprovalTests.Core;
using ApprovalTests.Reporters;
using ApprovalTests.Reporters.ContinuousIntegration;
using ApprovalTests.Reporters.TestFrameworks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Refactoring.Pipelines.Test
{
    public class MyMsTestReporter : AssertReporter
    {
        public static readonly MyMsTestReporter INSTANCE = new MyMsTestReporter();

        public MyMsTestReporter() : base(
            "Microsoft.VisualStudio.TestTools.UnitTesting.Assert, Microsoft.VisualStudio.TestPlatform.TestFramework",
            "AreEqual",
            "Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute")
        {
            GenericDiffReporter.TEXT_FILE_TYPES.Add(".dot");
        }

        public override void Report(string approved, string received)
        {
            var approvedContent = File.Exists(approved) ? File.ReadAllText(approved) : "";
            var receivedContent = File.ReadAllText(received);

            Assert.AreEqual(
                PrintStringWithLengthAndVisibleNewlines(approvedContent),
                PrintStringWithLengthAndVisibleNewlines(receivedContent));

            //base.Report(approved, received);
        }

        public static string PrintStringWithLengthAndVisibleNewlines(string content)
        {
            return $@"Length: {content.Length}, {content.Replace("\n", "\\n").Replace("\r", "\\r")}";
        }
    }

    public class MyAppVeyorReporter : IEnvironmentAwareReporter
    {
        public static readonly MyAppVeyorReporter INSTANCE = new MyAppVeyorReporter();


        public bool IsWorkingInThisEnvironment(string forFile)
        {
            return AppVeyorReporter.INSTANCE.IsWorkingInThisEnvironment(forFile);
        }

        public void Report(string approved, string received) { MyMsTestReporter.INSTANCE.Report(approved, received); }
    }

    public class MyFrontLoadedReporter : FirstWorkingReporter
    {
        public static readonly MyFrontLoadedReporter INSTANCE = new MyFrontLoadedReporter();

        public MyFrontLoadedReporter() : base(NCrunchReporter.INSTANCE, MyAppVeyorReporter.INSTANCE) { }
    }
}
