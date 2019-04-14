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
            var metadata = new NodeMetadata(root);

            return $@"
digraph G {{ node [style=filled, shape=rec]

# Nodes
{DotGraphNodes.AppendNodeAndChildren(root, metadata)}

# Formatting
{DotGraphFormatting.AppendFormatting(root, metadata)}
{DotGraphRanking.AppendRankings(root, metadata)}

}}
".Trim();
        }


        public static StringBuilder ProcessTree(IGraphNode node, StringBuilder result, Action<IGraphNode, NodeMetadata, StringBuilder> processNode, Action<IGraphNode, IGraphNode, NodeMetadata, StringBuilder> processChild, NodeMetadata metadata)
        {
            processNode(node, metadata, result);

            foreach (var listener in node.Children)
            {
                processChild(node, listener, metadata, result);
                ProcessTree(listener, result, processNode, processChild, metadata);
            }
            return result;
        }
    }
}