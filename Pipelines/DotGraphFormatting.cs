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
            AppendFormat(metadata.CheckNameUnique(node).QuotedUniqueName, @"color=green", result);
        }

        private static void AppendFunctionPipeFormatting(ILabeledNode node, NodeMetadataDictionary metadata, StringBuilder result)
        {
            ILabeledNode output = ((IFunctionPipe)node).Output;
            var nodeMetadata = metadata.CheckNameUnique(output);
            NodeMetadata functionNodeMetadata = metadata.CheckNameUnique(node);

            string label = nodeMetadata.count == 0 ? "" : $"label={DotGraph.Quoted(output.Name)}, ";
            AppendFormat(nodeMetadata.QuotedUniqueName, $@"{label}color=""#9fbff4""", result);

            string functionLabel = functionNodeMetadata.count == 0 ? "" : $"label={DotGraph.Quoted(node.Name)}, ";
            AppendFormat(functionNodeMetadata.QuotedUniqueName, $@"{functionLabel}shape=invhouse", result);
        }

        private static void AppendCollectorPipeFormatting(ILabeledNode node, NodeMetadataDictionary metadata, StringBuilder result)
        {
            var nodeMetadata = metadata.CheckNameUnique(node);
            string label = nodeMetadata.count == 0 ? "" : "label=Collector, ";
            AppendFormat(nodeMetadata.QuotedUniqueName, $@"{label}color = ""#c361f4""", result);
        }
    }
}