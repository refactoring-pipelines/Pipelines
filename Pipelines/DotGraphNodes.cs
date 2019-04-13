using System;
using System.Collections.Generic;
using System.Text;

namespace Pipelines
{
    public static class DotGraphNodes
    {

        public static StringBuilder AppendNodeAndChildren(ILabeledNode node)
        {
            return DotGraph.ProcessTree(node, new StringBuilder(), AppendFunctionPipe, delegate { });
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
            string collector = collectorNode == null ? "" :  ", " + DotGraph.Quoted(collectorNode.Name);
            result.AppendLine($"{input} -> {function} -> {{{output}{collector}}}");
        }
    }
}