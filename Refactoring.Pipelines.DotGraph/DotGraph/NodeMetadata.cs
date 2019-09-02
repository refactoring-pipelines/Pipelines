using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Refactoring.Pipelines.DotGraph
{
    public class NodeMetadata
    {
        private readonly Dictionary<IGraphNode, int> _countsByNode = new Dictionary<IGraphNode, int>();

        private readonly HashSet<Tuple<IGraphNode, Action<IGraphNode, NodeMetadata, List<string>>>>
            _isNodeDataProcessed = new HashSet<Tuple<IGraphNode, Action<IGraphNode, NodeMetadata, List<string>>>>();

        public NodeMetadata(IEnumerable<IGraphNode> roots)
        {
            foreach (var root in roots)
            {
                ProcessTree(root);
            }
        }

        private void ProcessTree(IGraphNode node)
        {
            if (_countsByNode.ContainsKey(node))
            {
                return;
            }

            SetCountForNode(node);

            if (node is IGraphNodeWithOutput withOutput)
            {
                SetCountForNode(withOutput.Output);
            }

            if (node is ISender sender)
            {
                foreach (var child in sender.Children)
                {
                    ProcessTree(child.CheckForwarding());
                }
            }
        }

        private void SetCountForNode(IGraphNode node) { _countsByNode[node] = GetDisambiguatingCount(node); }

        public string GetQuotedUniqueName(IGraphNode node)
        {
            if (!_countsByNode.ContainsKey(node))
            {
                throw new CannotFindNodeException(node);
            }

            return Quoted(_countsByNode[node] == 0 ? node.Name : node.Name + ' ' + _countsByNode[node]);
        }

        public int GetCount(IGraphNode node) { return _countsByNode[node]; }

        private int GetDisambiguatingCount(IGraphNode node)
        {
            var nodesWithSameNamesAndCounts =
                _countsByNode.Where(nodeAndCount => nodeAndCount.Key.Name == node.Name).ToList();

            int count;
            if (nodesWithSameNamesAndCounts.Any())
            {
                count = nodesWithSameNamesAndCounts.Max(nodeAndCount => nodeAndCount.Value) + 1;
            }
            else
            {
                count = 0;
            }

            return count;
        }

        public string GetQuotedDisplayName(IGraphNode node) { return Quoted(node.Name); }

        private static string Quoted(string value) { return $@"""{value}"""; }

        public bool IsNodeDataProcessed(IGraphNode node, Action<IGraphNode, NodeMetadata, List<string>> processChild)
        {
            return _isNodeDataProcessed.Contains(Tuple.Create(node, processChild));
        }

        public void SetNodeDataProcessed(IGraphNode node, Action<IGraphNode, NodeMetadata, List<string>> processChild)
        {
            _isNodeDataProcessed.Add(Tuple.Create(node, processChild));
        }

        public class CannotFindNodeException : Exception
        {
            public CannotFindNodeException(IGraphNode node) : base(FormatHelpMessage(node)) { }

            private static string FormatHelpMessage(IGraphNode node)
            {
                return $@"
Cannot find node.

    Type: '{node.GetType()}'
    Name: '{node.Name}'

Most likely you need to Verify() at a node that is a descendent of all inputs.

For example, if you are using a JoinedPipes, verify the join node.".Trim();
            }
        }
    }
}
