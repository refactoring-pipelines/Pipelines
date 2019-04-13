using System.Text;

namespace Pipelines
{
    public static class DotGraphRanking
    {
         public static StringBuilder AppendRankings(ILabeledNode node)
        {
            return DotGraph.ProcessTree(node, new StringBuilder(), delegate { }, ProcessChildRanking);

        }

        private static void ProcessChildRanking(ILabeledNode node, ILabeledNode listener, StringBuilder result)
        {
            if (listener.GetType().GetGenericTypeDefinition() == typeof(CollectorPipe<>))
                result.AppendLine($@"{{ rank=same; {DotGraph.Quoted(node.Name)}, {DotGraph.Quoted(listener.Name)}}}");
        }

    }
}