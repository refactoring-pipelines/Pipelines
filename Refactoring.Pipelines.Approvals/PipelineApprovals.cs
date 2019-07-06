using ApprovalTests.Writers;

namespace Refactoring.Pipelines.Approvals
{
    public class PipelineApprovals
    {
        public static void Verify(IGraphNode input)
        {
            ApprovalTests.Approvals.Verify(
                WriterFactory.CreateTextWriter(DotGraph.DotGraph.FromPipeline(input), "dot"));
        }
    }
}
