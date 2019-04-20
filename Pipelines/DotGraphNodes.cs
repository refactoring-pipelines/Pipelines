using System.Text;

namespace Pipelines
{
    public static class DotGraphNodes
    {
        public static StringBuilder AppendNodeAndChildren(IGraphNode node, NodeMetadata metadata)
        {
            return DotGraph.ProcessTree(node, new StringBuilder(), AppendFunctionalPipe, delegate { }, metadata);
        }

        private static void AppendFunctionalPipe(IGraphNode node, NodeMetadata metadata, StringBuilder result)
        {
            switch (node)
            {
                case IFunctionPipe functionPipe:
                    AppendFunctionPipe(functionPipe, metadata, result);
                    break;
                case IJoinedPipes joinedPipes:
                    AppendJoinedPipe(joinedPipes, metadata, result);
                    break;
            }
        }

        private static void AppendFunctionPipe(IFunctionPipe functionPipe, NodeMetadata metadata, StringBuilder result)
        {
            var predecessorFunctionPipe = functionPipe.Predecessor as IFunctionPipe;

            var input = metadata.GetQuotedUniqueName(predecessorFunctionPipe?.Output ?? functionPipe.Predecessor);
            var function = metadata.GetQuotedUniqueName(functionPipe);
            var output = metadata.GetQuotedUniqueName(functionPipe.Output);
            var collectorNode = functionPipe.Collector;
            if (collectorNode != null)
            {
                var collectorUniqueName = metadata.GetQuotedUniqueName(collectorNode);
                output = $"{{{output}, {collectorUniqueName}}}";
            }

            result.AppendLine($"{input} -> {function} -> {output}");
        }

        private static void AppendJoinedPipe(IJoinedPipes joinedPipes, NodeMetadata metadata, StringBuilder result)
        {
            var predecessors = joinedPipes.Predecessors;

            var input1 = metadata.GetQuotedUniqueName(predecessors.Item1.Output);
            var input2 = metadata.GetQuotedUniqueName(predecessors.Item2.Output);
            var function = metadata.GetQuotedUniqueName(joinedPipes);
            var output = metadata.GetQuotedUniqueName(joinedPipes.Output);
            var collectorNode = joinedPipes.Collector;
            if (collectorNode != null)
            {
                var collectorUniqueName = metadata.GetQuotedUniqueName(collectorNode);
                output = $"{{{output}, {collectorUniqueName}}}";
            }

            result.AppendLine($"{{{input1}, {input2}}} -> {function} -> {output}");
        }
    }
}