using System.IO;
using ApprovalTests;
using GraphVizWrapper;
using GraphVizWrapper.Commands;
using GraphVizWrapper.Queries;

namespace Refactoring.Pipelines.ApprovalsWithGraphViz
{
    public class PipelineApprovalsWithGraphViz
    {
        public static string GraphVizLocation { get; set; }

        public static void VerifyAsPng(IGraphNode input)
        {
            var dotGraph = DotGraph.DotGraph.FromPipeline(input);
            var graphViz = GetGraphVizGenerator();

            var output = graphViz.GenerateGraph(dotGraph.ToString(), Enums.GraphReturnType.Png);

            Approvals.VerifyBinaryFile(output, ".png");
        }

        private static GraphGeneration GetGraphVizGenerator()
        {
            var registerLayoutPluginCommand = new RegisterLayoutPluginCommand(
                new GetProcessStartInfoQuery(),
                new GetStartProcessQuery());
            var wrapper = new GraphGeneration(
                new GetStartProcessQuery(),
                new GetProcessStartInfoQuery(),
                registerLayoutPluginCommand);

            wrapper.GraphvizPath = GraphVizLocation ?? Path.Combine(GetNuGetPackagesPath(), "Graphviz.2.38.0.2");
            return wrapper;
        }

        private static string GetNuGetPackagesPath()
        {
            var graphVizAssemblyLocation = typeof(GraphGeneration).Assembly.Location;
            var directoryName = Path.GetDirectoryName(graphVizAssemblyLocation);
            while (!Directory.Exists(Path.Combine(directoryName, "packages")))
            {
                directoryName = Directory.GetParent(directoryName).FullName;
            }

            var packagesFolder = Path.Combine(directoryName, "packages");
            return Path.GetFullPath(packagesFolder);
        }
    }
}
