using ApprovalTests.Writers;

namespace Pipelines.Approvals
{
    public class PipelineApprovals
    {
        public static void Verify(IGraphNode input)
        {
            ApprovalTests.Approvals.Verify(WriterFactory.CreateTextWriter(DotGraph.DotGraph.FromPipeline(input), "dot"));
        }
    }
}