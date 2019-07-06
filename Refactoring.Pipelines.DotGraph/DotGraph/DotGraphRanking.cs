using System.Collections.Generic;
using System.Text;

namespace Refactoring.Pipelines.DotGraph
{
    public static class DotGraphRanking
    {
        public static StringBuilder AppendRankings(IEnumerable<IGraphNode> nodes, NodeMetadata metadata)
        {
            var result = new StringBuilder();
            foreach (var node in nodes)
            {
                DotGraph.ProcessTree(node, result, delegate { }, ProcessChildRanking, metadata);
            }

            return result;
        }

        private static void ProcessChildRanking(
            IGraphNode node,
            IGraphNode listener,
            NodeMetadata metadata,
            StringBuilder result)
        {
            if (listener.GetType().GetGenericTypeDefinition() == typeof(CollectorPipe<>))
            {
                var listenerUniqueName = metadata.GetQuotedUniqueName(listener);
                result.Append($"{{ rank=same; {metadata.GetQuotedUniqueName(node)}, {listenerUniqueName}}}\n");
            }
        }
    }
}
