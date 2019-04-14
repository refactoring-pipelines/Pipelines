using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pipelines
{
    public class NodeMetadata
    {
        public int count;
        public string Name
        {
            get
            {
                return DotGraph.Quoted(count == 0 ? Node.Name : Node.Name + ' ' + count);
            }
        }
        public ILabeledNode Node;
    }

    public static class DotGraph
    {
        public static string Quoted(string value)
        {
            return $@"""{value}""";
        }


        public static string FromPipeline<T>(InputPipe<T> root)
        {
            var metadata = new Dictionary<ILabeledNode, NodeMetadata>();

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


        public static StringBuilder ProcessTree(ILabeledNode node, StringBuilder result, Action<ILabeledNode, Dictionary<ILabeledNode, NodeMetadata>, StringBuilder> processNode, Action<ILabeledNode, ILabeledNode, Dictionary<ILabeledNode, NodeMetadata>, StringBuilder> processChild, Dictionary<ILabeledNode, NodeMetadata> metadata)
        {
            processNode(node, metadata, result);

            foreach (var listener in node.Listeners)
            {
                processChild(node, listener, metadata, result);
                ProcessTree(listener, result, processNode, processChild, metadata);
            }
            return result;
        }

        internal static NodeMetadata CheckNameUnique(ILabeledNode node, Dictionary<ILabeledNode, NodeMetadata> metadata)
        {
            if (metadata.TryGetValue(node, out var existing))
            {
                return existing;
            }

            bool any = metadata.Values.Any(_ => _.Node.Name == node.Name);
            if (any)
            {
                IEnumerable<NodeMetadata> nmedataWithSameNodeNames = metadata.Values.Where(_ => _.Node.Name == node.Name);
                var maxCount = nmedataWithSameNodeNames.Max(_ => _.count);
                maxCount++;
                var newMetadata = new NodeMetadata
                {
                    count = maxCount,
                    Node = node,
                };
                metadata.Add(node, newMetadata);
                return newMetadata;
            }
            else
            {
                var newMetadata = new NodeMetadata
                {
                    count = 0,
                    Node = node,
                };
                metadata.Add(node, newMetadata);
                return newMetadata;
            }
        }
    }
}