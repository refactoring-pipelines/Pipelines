using System.Text;

namespace Pipelines
{
    public static class DotGraphRanking
    {
        public static StringBuilder AppendRankings(IGraphNode node, NodeMetadata metadata)
        {
            return DotGraph.ProcessTree(node, new StringBuilder(), delegate { }, ProcessChildRanking, metadata);
        }

        private static void ProcessChildRanking(IGraphNode node, IGraphNode listener, NodeMetadata metadata,
            StringBuilder result)
        {
            if (listener.GetType().GetGenericTypeDefinition() == typeof(CollectorPipe<>))
            {
                var listenerUniqueName = metadata.GetQuotedUniqueName(listener);
                result.AppendLine($@"{{ rank=same; {metadata.GetQuotedDisplayName(node)}, {listenerUniqueName}}}");
            }
        }
    }
}