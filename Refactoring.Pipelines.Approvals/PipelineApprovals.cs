using ApprovalTests.Writers;

namespace Refactoring.Pipelines.Approvals
{
    public class PipelineApprovals
    {
        public static void Verify(IGraphNode input)
        {
            var dotGraph = DotGraph.DotGraph.GetDotGraph(input);
            ApprovalTests.Approvals.Verify(
                WriterFactory.CreateTextWriter(dotGraph.ToString(), "dot"));
        }
    }
}
