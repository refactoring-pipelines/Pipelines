using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ApprovalTests;
using ApprovalTests.Writers;
using GraphVizWrapper;
using GraphVizWrapper.Commands;
using GraphVizWrapper.Queries;

namespace Refactoring.Pipelines.ApprovalsWithGraphViz
{
    //make it work
    public class PipelineApprovalsWithGraphViz
    {
        public static void VerifyAsPng(IGraphNode input)
        {
            var dotGraph = DotGraph.DotGraph.FromPipeline(input);
            var getStartProcessQuery = new GetStartProcessQuery();
            var getProcessStartInfoQuery = new GetProcessStartInfoQuery();
            var registerLayoutPluginCommand = new RegisterLayoutPluginCommand(getProcessStartInfoQuery, getStartProcessQuery);

            // GraphGeneration can be injected via the IGraphGeneration interface

            var wrapper = new GraphGeneration(getStartProcessQuery,
                getProcessStartInfoQuery,
                registerLayoutPluginCommand);
            wrapper.GraphvizPath = @"C:\source\Pipelines\packages\Graphviz.2.38.0.2";

            byte[] output = wrapper.GenerateGraph(dotGraph.ToString(), Enums.GraphReturnType.Png);
            Approvals.VerifyBinaryFile(output, ".png");
        }
    }
}
