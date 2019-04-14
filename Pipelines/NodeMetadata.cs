using System.Collections.Generic;
using System.Linq;

namespace Pipelines
{
    public class NodeMetadata
    {
        public readonly Dictionary<ILabeledNode, int> _values = new Dictionary<ILabeledNode, int>();

        public NodeMetadata(ILabeledNode root)
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
            return DotGraph.Quoted(_values[node] == 0 ? node.Name : node.Name + ' ' + _values[node]);
        }

        public int GetCount(ILabeledNode node)
        {
            return _values[node];
        }

        private void CheckNameUnique(ILabeledNode node)
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