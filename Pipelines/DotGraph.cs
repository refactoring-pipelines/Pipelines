using System;
using System.Text;

namespace Pipelines
{
    public static class DotGraph
    {
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


        public static StringBuilder ProcessTree(IGraphNode node, StringBuilder result,
            Action<IGraphNode, NodeMetadata, StringBuilder> processNode,
            Action<IGraphNode, IGraphNode, NodeMetadata, StringBuilder> processChild, NodeMetadata metadata)
        {
            if (metadata.IsNodeDataProcessed(node, processNode)) { return result; }
            metadata.SetNodeDataProcessed(node, processNode);

            processNode(node, metadata, result);

            if (node is ISender sender)
            {
                foreach (var listener in sender.Children)
                {
                    processChild(node, listener.CheckForwarding(), metadata, result);
                    ProcessTree(listener.CheckForwarding(), result, processNode, processChild, metadata);
                }
            }

            return result;
        }
    }
}