using System.Text;

namespace Pipelines
{
    public static class DotGraphNodes
    {
        public static StringBuilder AppendNodeAndChildren(IGraphNode node, NodeMetadata metadata)
        {
            return DotGraph.ProcessTree(node, new StringBuilder(), AppendFunctionPipe, delegate { }, metadata);
        }

        private static void AppendFunctionPipe(IGraphNode node, NodeMetadata metadata, StringBuilder result)
        {
            var functionPipe = node as IFunctionPipe;
            if (functionPipe == null)
                return;

            var predecessorFunctionPipe = functionPipe.Predecessor as IFunctionPipe;

            var input = metadata.GetQuotedUniqueName(predecessorFunctionPipe?.Output ?? functionPipe.Predecessor);
            var function = metadata.GetQuotedUniqueName(node);
            var output = metadata.GetQuotedUniqueName(functionPipe.Output);
            var collectorNode = functionPipe.Collector;
            if (collectorNode != null)
            {
                var collectorUniqueName = metadata.GetQuotedUniqueName(collectorNode);
                output = $"{{{output}, {collectorUniqueName}}}";
            }

            result.AppendLine($"{input} -> {function} -> {output}");
        }
    }
}