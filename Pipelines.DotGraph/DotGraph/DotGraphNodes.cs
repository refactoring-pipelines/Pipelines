using System.Collections.Generic;
using System.Text;

namespace Pipelines.DotGraph
{
    public static class DotGraphNodes
    {
        public static StringBuilder AppendNodeAndChildren(IEnumerable<IGraphNode> nodes, NodeMetadata metadata)
        {
            var result = new StringBuilder();
            foreach (var node in nodes)
            {
                DotGraph.ProcessTree(node, result, AppendFunctionalPipe, delegate { }, metadata);
            }

            return result;
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

            var input1 = metadata.GetQuotedUniqueName(GetPredecessorOutput(predecessors.Item1));
            var input2 = metadata.GetQuotedUniqueName(GetPredecessorOutput(predecessors.Item2));
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

        private static IGraphNode GetPredecessorOutput(IGraphNode node)
        {
            if (node is IGraphNodeWithOutput graphNodeWithOutput)
            {
                return graphNodeWithOutput.Output;
            }

            return node;
        }
    }
}
