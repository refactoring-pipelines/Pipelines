using System.Collections.Generic;

namespace Refactoring.Pipelines.DotGraph
{
    public static class DotGraphRanking
    {
        public static List<string> AppendRankings(IEnumerable<IGraphNode> nodes, NodeMetadata metadata)
        {
            var result = new List<string>();
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
            List<string> result)
        {
            if (listener.GetType().GetGenericTypeDefinition() == typeof(CollectorPipe<>))
            {
                var listenerUniqueName = metadata.GetQuotedUniqueName(listener);
                result.Add($"{{ rank=same; {metadata.GetQuotedUniqueName(node)}, {listenerUniqueName}}}\n");
            }
        }
    }
}
