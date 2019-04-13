using System;
using System.Text;

namespace Pipelines
{
    public static class DotGraph
    {
        public static string Quoted(string value)
        {
            return $@"""{value}""";
        }

        public static string FromPipeline<T>(InputPipe<T> root)
        {
            return $@"
digraph G {{ node [style=filled, shape=rec]

{DotGraphNodes.AppendNodeAndChildren(root)}
{DotGraphFormatting.AppendFormatting(root)}
{DotGraphRanking.AppendRankings(root)}

}}
".Trim();
        }


        public static StringBuilder ProcessTree(ILabeledNode node, StringBuilder result, Action<ILabeledNode, StringBuilder> processNode, Action<ILabeledNode, ILabeledNode, StringBuilder> processChild)
        {
            processNode(node, result);

            foreach (var listener in node.Listeners)
            {
                processChild(node, listener, result);
                ProcessTree(listener, result, processNode, processChild);
            }
            return result;
        }
    }
}