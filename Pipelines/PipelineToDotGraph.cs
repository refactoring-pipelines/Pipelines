using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pipelines
{
    public class NodeMetadata
    {
        public int count;

        public string GetQuotedUniqueName()
        {
            return DotGraph.Quoted(count == 0 ? Node.Name : Node.Name + ' ' + count);
        }

        public ILabeledNode Node;
    }

    public class NodeMetadataDictionary
    {
        public readonly Dictionary<ILabeledNode, NodeMetadata> _values = new Dictionary<ILabeledNode, NodeMetadata>();

        public NodeMetadataDictionary(ILabeledNode root)
        {
            ProcessTree(root);
        }

        private void ProcessTree(ILabeledNode node)
        {
            CheckNameUnique(node);
            if (node is IFunctionPipe functionPipe)
            {
                CheckNameUnique(functionPipe.Output);
            }
            foreach (var child in node.Listeners)
            {
                ProcessTree(child);
            }
        }

        public string GetQuotedUniqueName(ILabeledNode node)
        {
            return _values[node].GetQuotedUniqueName();
        }

        public int GetCount(ILabeledNode node)
        {
            return _values[node].count;
        }

        private NodeMetadata CheckNameUnique(ILabeledNode node)
        {
            if (_values.TryGetValue(node, out var existing))
            {
                return existing;
            }

            IEnumerable<NodeMetadata> metadataWithSameNodeNames = _values.Values.Where(_ => _.Node.Name == node.Name);
            int count;
            if (metadataWithSameNodeNames.Any())
            {
                count = metadataWithSameNodeNames.Max(_ => _.count) + 1;
            }
            else
            {
                count = 0;
            }

            var newMetadata = new NodeMetadata
            {
                count = count,
                Node = node,
            };
            _values.Add(node, newMetadata);
            return newMetadata;
        }
    }

    public static class DotGraph
    {
        public static string Quoted(string value)
        {
            return $@"""{value}""";
        }


        public static string FromPipeline<T>(InputPipe<T> root)
        {
            var metadata = new NodeMetadataDictionary(root);

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


        public static StringBuilder ProcessTree(ILabeledNode node, StringBuilder result, Action<ILabeledNode, NodeMetadataDictionary, StringBuilder> processNode, Action<ILabeledNode, ILabeledNode, NodeMetadataDictionary, StringBuilder> processChild, NodeMetadataDictionary metadata)
        {
            processNode(node, metadata, result);

            foreach (var listener in node.Listeners)
            {
                processChild(node, listener, metadata, result);
                ProcessTree(listener, result, processNode, processChild, metadata);
            }
            return result;
        }
    }
}