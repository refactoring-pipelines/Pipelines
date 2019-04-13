using System;
using System.Collections.Generic;
using System.Text;

namespace Pipelines
{
    public static class DotGraphFormatting
    {
        static void AppendFormat(string name, string format, StringBuilder result)
        {
            result.AppendLine($@"{DotGraph.Quoted(name)} [{format}]");
        }

        static readonly Dictionary<Type, Action<ILabeledNode, StringBuilder>> PipeAppendersByType =
            new Dictionary<Type, Action<ILabeledNode, StringBuilder>>
            {
                { typeof(CollectorPipe<>), AppendCollectorPipeFormatting },
                { typeof(FunctionPipe<,>), AppendFunctionPipeFormatting },
                { typeof(InputPipe<>), AppendInputPipeFormatting },
            };

        public static StringBuilder AppendFormatting(ILabeledNode node, Dictionary<ILabeledNode, NodeMetadata> metadata)
        {
            Action<ILabeledNode, StringBuilder> processNode = (node_, result_) => PipeAppendersByType[node_.GetType().GetGenericTypeDefinition()](node_, result_);
            return DotGraph.ProcessTree(node, new StringBuilder(), processNode, delegate { }, metadata);
        }

        private static void AppendInputPipeFormatting(ILabeledNode node, StringBuilder result)
        {
            AppendFormat(node.Name, @"color=green", result);
        }

        private static void AppendFunctionPipeFormatting(ILabeledNode node, StringBuilder result)
        {
            AppendFormat((node.Name), @"shape=invhouse", result);
            AppendFormat(((IFunctionPipe)node).OutputName, @"color=""#9fbff4""", result);
        }

        private static void AppendCollectorPipeFormatting(ILabeledNode node, StringBuilder result)
        {
            var nodeMetadata = DotGraph.CheckNameUnique(node);
            string label = nodeMetadata.count == 0 ? "" : "label=Collector, ";
            AppendFormat(nodeMetadata.Name, $@"{label}color = ""#c361f4""", result);
        }
    }
}