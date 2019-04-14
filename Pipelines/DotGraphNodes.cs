using System;
using System.Collections.Generic;
using System.Text;

namespace Pipelines
{
    public static class DotGraphNodes
    {

        public static StringBuilder AppendNodeAndChildren(ILabeledNode node, NodeMetadataDictionary metadata)
        {
            return DotGraph.ProcessTree(node, new StringBuilder(), AppendFunctionPipe, delegate { }, metadata);
        }

        private static void AppendFunctionPipe(ILabeledNode node, NodeMetadataDictionary metadata, StringBuilder result)
        {
            var functionPipe = node as IFunctionPipe;
            if (functionPipe == null)
                return;

            var predecessorFunctionPipe = functionPipe.Predecessor as IFunctionPipe;

            string input = metadata.CheckNameUnique(predecessorFunctionPipe?.Output ?? functionPipe.Predecessor).QuotedUniqueName;
            string function = metadata.CheckNameUnique(node).QuotedUniqueName;
            string output = metadata.CheckNameUnique(functionPipe.Output).QuotedUniqueName;
            var collectorNode = functionPipe.Collector;
            if (collectorNode != null)
            {
                var nodeMetadata = metadata.CheckNameUnique(collectorNode);
                output = $"{{{output}, {nodeMetadata.QuotedUniqueName}}}";
            }
            result.AppendLine($"{input} -> {function} -> {output}");
        }
    }
}