using System.Collections.Generic;
using System.Linq;

namespace Pipelines
{
    public class NodeMetadata
    {
        public readonly Dictionary<IGraphNode, int> _values = new Dictionary<IGraphNode, int>();

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
            foreach (var child in node.Listeners)
            {
                ProcessTree(child);
            }
        }

        public string GetQuotedUniqueName(IGraphNode node)
        {
            return DotGraph.Quoted(_values[node] == 0 ? node.Name : node.Name + ' ' + _values[node]);
        }

        public int GetCount(IGraphNode node)
        {
            return _values[node];
        }

        private void CheckNameUnique(IGraphNode node)
        {
            if (_values.TryGetValue(node, out var existing))
            {
                return;
            }

            var metadataWithSameNodeNames = _values.Where(nodeAndCount => nodeAndCount.Key.Name == node.Name);

            int count;
            if (metadataWithSameNodeNames.Any())
            {
                count = metadataWithSameNodeNames.Max(nodeAndCount => nodeAndCount.Value) + 1;
            }
            else
            {
                count = 0;
            }

            _values.Add(node, count);
        }
    }
}