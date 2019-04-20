using System;
using System.Collections.Generic;
using System.Linq;

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
            _countsByNode[node] = GetDisambiguatingCount(node);

            if (node is IFunctionPipe functionPipe)
                _countsByNode[functionPipe.Output] = GetDisambiguatingCount(functionPipe.Output);
            if (node is IJoinedPipes joinedPipes)
                _countsByNode[joinedPipes.Output] = GetDisambiguatingCount(joinedPipes.Output);

            foreach (var child in node.Children) ProcessTree(child.CheckForwarding());
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

        readonly HashSet<IGraphNode> _isNodeDataProcessed = new HashSet<IGraphNode>();

        public bool IsNodeDataProcessed(IGraphNode node)
        {
            return _isNodeDataProcessed.Contains(node);
        }

        public void SetNodeDataProcessed(IGraphNode node)
        {
            _isNodeDataProcessed.Add(node);
        }
    }
}