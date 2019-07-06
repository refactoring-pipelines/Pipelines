using ApprovalTests.Reporters;
using ApprovalTests.Reporters.TestFrameworks;
using Refactoring.Pipelines.Approvals;
using Refactoring.Pipelines.Test;

//[assembly: UseReporter(typeof(DotReporter))]
[assembly: UseReporter(typeof(MyMsTestReporter))]
[assembly: FrontLoadedReporter(typeof(MyFrontLoadedReporter))]
