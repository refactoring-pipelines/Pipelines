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
            CheckNameUnique(node);
            if (node is IFunctionPipe functionPipe)
            {
                CheckNameUnique(functionPipe.Output);
            }
            foreach (var child in node.Children)
            {
                ProcessTree(child);
            }
        }

        public string GetQuotedUniqueName(IGraphNode node)
        {
            return DotGraph.Quoted(_countsByNode[node] == 0 ? node.Name : node.Name + ' ' + _countsByNode[node]);
        }

        public int GetCount(IGraphNode node)
        {
            return _countsByNode[node];
        }

        private void CheckNameUnique(IGraphNode node)
        {
            if (_countsByNode.TryGetValue(node, out var existing))
            {
                return;
            }

            var metadataWithSameNodeNames = _countsByNode.Where(nodeAndCount => nodeAndCount.Key.Name == node.Name);

            int count;
            if (metadataWithSameNodeNames.Any())
            {
                count = metadataWithSameNodeNames.Max(nodeAndCount => nodeAndCount.Value) + 1;
            }
            else
            {
                count = 0;
            }

            _countsByNode.Add(node, count);
        }
    }
}