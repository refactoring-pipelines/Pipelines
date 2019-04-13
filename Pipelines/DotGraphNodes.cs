using System;
using System.Collections.Generic;
using System.Text;

namespace Pipelines
{
    public static class DotGraphNodes
    {

        public static StringBuilder AppendNodeAndChildren(ILabeledNode node)
        {
            //Action<ILabeledNode, ILabeledNode, StringBuilder> processChild = (node_, child_, result_) => result_.AppendLine(DotGraph.Quoted(node_.OutgoingName) + " -> " + DotGraph.Quoted(child_.IncomingName));
            return DotGraph.ProcessTree(node, new StringBuilder(), AppendFunctionPipe, delegate { });

        }

        private static void AppendFunctionPipe(ILabeledNode node, StringBuilder result)
        {
            var functionPipe = node as IFunctionPipe;
            if (functionPipe == null)
                return;

            string input = DotGraph.Quoted(functionPipe.Predecessor.OutgoingName);
            string function = DotGraph.Quoted(node.IncomingName);
            string output = DotGraph.Quoted(node.OutgoingName);
            var collectorNode = functionPipe.Collector;
            string collector = collectorNode == null ? "" :  ", " + DotGraph.Quoted(collectorNode.OutgoingName);
            result.AppendLine($"{input} -> {function} -> {{{output}{collector}}}");
        }
    }
}