using ApprovalTests.Reporters;
using Refactoring.Pipelines.Test;

//[assembly: UseReporter(typeof(DotReporter))]
[assembly: UseReporter(typeof(MyMsTestReporter))]
[assembly: FrontLoadedReporter(typeof(MyFrontLoadedReporter))]
