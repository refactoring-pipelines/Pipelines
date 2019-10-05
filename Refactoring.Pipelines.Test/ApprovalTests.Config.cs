using ApprovalTests.Namers;
using ApprovalTests.Reporters;
using ApprovalTests.Reporters.TestFrameworks;

[assembly: UseApprovalSubdirectory("_approvals")]
//[assembly: UseReporter(typeof(MsTestReporter))]
[assembly: UseReporter(typeof(DiffReporter))]