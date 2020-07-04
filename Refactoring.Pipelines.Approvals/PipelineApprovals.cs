using ApprovalTests;
using ApprovalTests.Writers;
using DiffEngine;
using EmptyFiles;
using GraphVizNet;

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
        public static void VerifyAsPng(IGraphNode input)
        {
            var dotGraph = DotGraph.DotGraph.FromPipeline(input);
            var graphViz = new GraphViz();
            graphViz.Config.TreatWarningsAsErrors = true;

            var output = graphViz.LayoutAndRenderDotGraph(dotGraph.ToString(), "png");

            Approvals.VerifyBinaryFile(output, "." + "png");
        }

        public static void VerifyAsSvg(InputPipe<string> input)
        {
            var dotGraph = DotGraph.DotGraph.FromPipeline(input);
            var graphViz = new GraphViz();
            graphViz.Config.TreatWarningsAsErrors = true;

            var output = graphViz.LayoutAndRenderDotGraph(dotGraph.ToString(), "svg");

            Approvals.VerifyBinaryFile(output, "." + "svg");
        }
    }
}
