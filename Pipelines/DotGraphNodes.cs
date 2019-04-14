using System;
using System.Collections.Generic;
using System.Text;

namespace Pipelines
{
    public static class DotGraphNodes
    {

        public static StringBuilder AppendNodeAndChildren(ILabeledNode node, Dictionary<ILabeledNode, NodeMetadata> metadata)
        {
            return DotGraph.ProcessTree(node, new StringBuilder(), AppendFunctionPipe, delegate { }, metadata);
        }

        private static void AppendFunctionPipe(ILabeledNode node, Dictionary<ILabeledNode, NodeMetadata> metadata, StringBuilder result)
        {
            var functionPipe = node as IFunctionPipe;
            if (functionPipe == null)
                return;

            var predecessorFunctionPipe = functionPipe.Predecessor as IFunctionPipe;

            string input = DotGraph.CheckNameUnique(predecessorFunctionPipe?.Output ?? functionPipe.Predecessor, metadata).Name;
            string function = DotGraph.CheckNameUnique(node, metadata).Name;
            string output = DotGraph.CheckNameUnique(functionPipe.Output, metadata).Name;
            var collectorNode = functionPipe.Collector;
            if (collectorNode != null)
            {
                var nodeMetadata = DotGraph.CheckNameUnique(collectorNode, metadata);
                output = $"{{{output}, {nodeMetadata.Name}}}";
            }
            result.AppendLine($"{input} -> {function} -> {output}");
        }
    }
}