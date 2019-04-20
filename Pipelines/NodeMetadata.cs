using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pipelines
{
    public class NodeMetadata
    {
        private readonly Dictionary<IGraphNode, int> _countsByNode = new Dictionary<IGraphNode, int>();

        public NodeMetadata(IGraphNode root)
        {
            ProcessTree(root);
        }

        private void ProcessTree(IGraphNode node)
        {
            if (_countsByNode.ContainsKey(node))
            {
                return;
            }

            SetCountForNode(node);

            if (node is IGraphNodeWithOutput withOutput)
                SetCountForNode(withOutput.Output);

            if (node is ISender sender)
            {
                foreach (var child in sender.Children)
                {
                    ProcessTree(child.CheckForwarding());
                }
            }
        }

        private void SetCountForNode(IGraphNode node)
        {
            _countsByNode[node] = GetDisambiguatingCount(node);
        }

        public string GetQuotedUniqueName(IGraphNode node)
        {
            return Quoted(_countsByNode[node] == 0 ? node.Name : node.Name + ' ' + _countsByNode[node]);
        }

        public int GetCount(IGraphNode node)
        {
            return _countsByNode[node];
        }

        private int GetDisambiguatingCount(IGraphNode node)
        {
            var nodesWithSameNamesAndCounts = _countsByNode.Where(nodeAndCount => nodeAndCount.Key.Name == node.Name);

            int count;
            if (nodesWithSameNamesAndCounts.Any())
                count = nodesWithSameNamesAndCounts.Max(nodeAndCount => nodeAndCount.Value) + 1;
            else
                count = 0;

            return count;
        }

        public string GetQuotedDisplayName(IGraphNode node)
        {
            return Quoted(node.Name);
        }

        private static string Quoted(string value)
        {
            return $@"""{value}""";
        }

        readonly HashSet<Tuple<IGraphNode, Action<IGraphNode, NodeMetadata, StringBuilder>>> _isNodeDataProcessed = new HashSet<Tuple<IGraphNode, Action<IGraphNode, NodeMetadata, StringBuilder>>>();

        public bool IsNodeDataProcessed(IGraphNode node, Action<IGraphNode, NodeMetadata, StringBuilder> processChild)
        {
            return _isNodeDataProcessed.Contains(Tuple.Create(node, processChild));
        }

        public void SetNodeDataProcessed(IGraphNode node, Action<IGraphNode, NodeMetadata, StringBuilder> processChild)
        {
            _isNodeDataProcessed.Add(Tuple.Create(node, processChild));
        }
    }
}