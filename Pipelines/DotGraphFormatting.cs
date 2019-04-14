using System;
using System.Collections.Generic;
using System.Text;

namespace Pipelines
{
    public static class DotGraphFormatting
    {
        static void AppendFormat(string name, string format, StringBuilder result)
        {
            result.AppendLine($@"{name} [{format}]");
        }

        static readonly Dictionary<Type, Action<ILabeledNode, NodeMetadataDictionary, StringBuilder>> PipeAppendersByType =
            new Dictionary<Type, Action<ILabeledNode, NodeMetadataDictionary, StringBuilder>>
            {
                { typeof(CollectorPipe<>), AppendCollectorPipeFormatting },
                { typeof(FunctionPipe<,>), AppendFunctionPipeFormatting },
                { typeof(InputPipe<>), AppendInputPipeFormatting },
            };

        public static StringBuilder AppendFormatting(ILabeledNode node, NodeMetadataDictionary metadata)
        {
            Action<ILabeledNode, NodeMetadataDictionary, StringBuilder> processNode = (node_, metadata_, result_) => 
                PipeAppendersByType[node_.GetType().GetGenericTypeDefinition()](node_, metadata_, result_);
            return DotGraph.ProcessTree(node, new StringBuilder(), processNode, delegate { }, metadata);
        }

        private static void AppendInputPipeFormatting(ILabeledNode node, NodeMetadataDictionary metadata, StringBuilder result)
        {
            var uniqueName = metadata.GetQuotedUniqueName(node);
            AppendFormat(uniqueName, @"color=green", result);
        }

        private static void AppendFunctionPipeFormatting(ILabeledNode node, NodeMetadataDictionary metadata, StringBuilder result)
        {
            ILabeledNode output = ((IFunctionPipe)node).Output;

            string label = metadata.GetCount(output) == 0 ? "" : $"label={DotGraph.Quoted(output.Name)}, ";
            var outputUniqueName = metadata.GetQuotedUniqueName(output);
            AppendFormat(outputUniqueName, $@"{label}color=""#9fbff4""", result);

            string functionLabel = metadata.GetCount(node) == 0 ? "" : $"label={DotGraph.Quoted(node.Name)}, ";
            var functionUniqueName = metadata.GetQuotedUniqueName(node);
            AppendFormat(functionUniqueName, $@"{functionLabel}shape=invhouse", result);
        }

        private static void AppendCollectorPipeFormatting(ILabeledNode node, NodeMetadataDictionary metadata, StringBuilder result)
        {
            string label = metadata.GetCount(node) == 0 ? "" : "label=Collector, ";
            var uniqueName = metadata.GetQuotedUniqueName(node);
            AppendFormat(uniqueName, $@"{label}color = ""#c361f4""", result);
        }
    }
}