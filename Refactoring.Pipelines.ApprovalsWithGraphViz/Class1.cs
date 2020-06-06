using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
            var graphViz = GetGraphVizGenerator();

            byte[] output = graphViz.GenerateGraph(dotGraph.ToString(), Enums.GraphReturnType.Png);
            
            Approvals.VerifyBinaryFile(output, ".png");
        }

        private static GraphGeneration GetGraphVizGenerator()
        {
            var getStartProcessQuery = new GetStartProcessQuery();
            var getProcessStartInfoQuery = new GetProcessStartInfoQuery();
            var registerLayoutPluginCommand = new RegisterLayoutPluginCommand(getProcessStartInfoQuery, getStartProcessQuery);
            var wrapper = new GraphGeneration(getStartProcessQuery, getProcessStartInfoQuery, registerLayoutPluginCommand);

            wrapper.GraphvizPath = Path.Combine(GetNuGetPackagesPath(), "Graphviz.2.38.0.2");
            return wrapper;
        }

        private static string GetNuGetPackagesPath()
        {
            var graphVizAssemblyLocation = typeof(GraphVizWrapper.GraphGeneration).Assembly.Location;
            var packagesFolder = Path.GetDirectoryName(graphVizAssemblyLocation) + @"\..\..\..\..\packages";
            return Path.GetFullPath(packagesFolder);
        }
    }
}
