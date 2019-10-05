using ApprovalTests.Maintenance;
using ApprovalTests.Namers;
using ApprovalTests.Reporters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[assembly: UseApprovalSubdirectory("_approvals")]
//[assembly: UseReporter(typeof(MsTestReporter))]
[assembly: UseReporter(typeof(DiffReporter))]

[TestClass]
public class ApprovalMaintenanceChecks
{
    [TestMethod]
    public void VerifyNoAbandonedFiles()
    {
        //ApprovalMaintenance.CleanUpAbandonedFiles();
        ApprovalMaintenance.VerifyNoAbandonedFiles();
    }
}
