using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Refactoring.Pipelines.DotGraph
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
                case IGraphNodeWithOutput functionPipe:
                    AppendFunctionPipe(functionPipe, metadata, result);
                    break;
            }
        }

        private static void AppendFunctionPipe(IGraphNodeWithOutput functionPipe, NodeMetadata metadata, StringBuilder result)
        {
            var inputs = functionPipe.Parents.Select(GetPredecessorOutput).Select(metadata.GetQuotedUniqueName).ToArray();

            var function = metadata.GetQuotedUniqueName(functionPipe);
            var output = metadata.GetQuotedUniqueName(functionPipe.Output);
            var collectorNode = functionPipe.Collector;
            if (collectorNode != null)
            {
                var collectorUniqueName = metadata.GetQuotedUniqueName(collectorNode);
                output = $"{{{output}, {collectorUniqueName}}}";
            }

            if (inputs.Count() == 1)
            {
                result.Append($"{inputs.Single()} -> {function} -> {output}\n");
            }
            else
            {
                result.Append($"{{{string.Join(", ", inputs)}}} -> {function} -> {output}\n");
            }
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
