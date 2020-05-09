using ApprovalTests;
using ApprovalTests.Writers;
using DiffEngine;
using EmptyFiles;

namespace Refactoring.Pipelines.ApprovalTests
{
    public class PipelineApprovals
    {
        static PipelineApprovals()
        {
            Extensions.AddTextExtension("dot");
            DiffTools.AddToolBasedOn(DiffTool.VisualStudioCode, "Vs Code for Visgraph",arguments: (temp, target) => $"-r \"{temp}\"", binaryExtensions:new[]{".dot"});
        }
        public static void Verify(IGraphNode input)
        {
            var dotGraph = DotGraph.DotGraph.FromPipeline(input);
            Approvals.Verify(WriterFactory.CreateTextWriter(dotGraph.ToString(), "dot"));
        }
    }
}
