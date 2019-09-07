using ApprovalTests;
using ApprovalTests.Writers;

namespace Refactoring.Pipelines.ApprovalTests
{
    public class PipelineApprovals
    {
        public static void Verify(IGraphNode input)
        {
            var dotGraph = DotGraph.DotGraph.FromPipeline(input);
            Approvals.Verify(WriterFactory.CreateTextWriter(dotGraph.ToString(), "dot"));
        }
    }
}
