using ApprovalTests.Core;
using ApprovalTests.Reporters;
using ApprovalTests.Reporters.ContinuousIntegration;
using ApprovalTests.Reporters.TestFrameworks;

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
