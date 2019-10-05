using ApprovalTests.Maintenance;
using ApprovalTests.Namers;
using ApprovalTests.Reporters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[assembly: UseApprovalSubdirectory("_approvals")]
//[assembly: UseReporter(typeof(MsTestReporter))]
[assembly: UseReporter(typeof(DiffReporter))]

namespace Refactoring.Pipelines.Test
{
    [TestClass]
    public class ApprovalMaintenance_
    {
        [TestMethod]
        public void VerifyNoAbandonedFiles() { ApprovalMaintenance.VerifyNoAbandonedFiles(); }
    }
}
