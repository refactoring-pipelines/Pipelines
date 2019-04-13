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

        private static void AppendFunctionPipe(ILabeledNode node, StringBuilder result)
        {
            var functionPipe = node as IFunctionPipe;
            if (functionPipe == null)
                return;

            var predecessorFunctionPipe = functionPipe.Predecessor as IFunctionPipe;

            string input = DotGraph.Quoted(predecessorFunctionPipe?.OutputName ?? functionPipe.Predecessor.Name);
            string function = DotGraph.Quoted(node.Name);
            string output = DotGraph.Quoted(functionPipe.OutputName);
            var collectorNode = functionPipe.Collector;
            if (collectorNode != null)
            {
                var nodeMetadata = DotGraph.CheckNameUnique(collectorNode);
                output = $"{{{output}, {DotGraph.Quoted(nodeMetadata.Name)}}}";
            }
            result.AppendLine($"{input} -> {function} -> {output}");
        }
    }
}