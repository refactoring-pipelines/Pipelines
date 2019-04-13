using System;
using System.Collections.Generic;
using System.Text;

namespace Pipelines
{
    public static class DotGraphNodes
    {

        public static StringBuilder AppendNodeAndChildren(ILabeledNode node)
        {
            Action<ILabeledNode, ILabeledNode, StringBuilder> processChild = (node_, child_, result_) => result_.AppendLine(DotGraph.Quoted(node_.OutgoingName) + " -> " + DotGraph.Quoted(child_.IncomingName));
            return DotGraph.ProcessTree(node, new StringBuilder(), AppendFunctionPipe, processChild);

        }

        private static void AppendFunctionPipe(ILabeledNode node, StringBuilder result)
        {
            result.AppendLine(DotGraph.Quoted(node.IncomingName) + " -> " + DotGraph.Quoted(node.OutgoingName));
        }

    }
}