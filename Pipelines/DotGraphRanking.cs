using System.Collections.Generic;
using System.Text;

namespace Pipelines
{
    public static class DotGraphRanking
    {
        public static StringBuilder AppendRankings(ILabeledNode node, Dictionary<ILabeledNode, NodeMetadata> metadata)
        {
            return DotGraph.ProcessTree(node, new StringBuilder(), delegate { }, ProcessChildRanking, metadata);

        }

        private static void ProcessChildRanking(ILabeledNode node, ILabeledNode listener, StringBuilder result)
        {
            if (listener.GetType().GetGenericTypeDefinition() == typeof(CollectorPipe<>))
            {
                var nodeMetadata = DotGraph.CheckNameUnique(listener);
                result.AppendLine($@"{{ rank=same; {DotGraph.Quoted(node.Name)}, {DotGraph.Quoted(nodeMetadata.Name)}}}");
            }
        }
    }
}
