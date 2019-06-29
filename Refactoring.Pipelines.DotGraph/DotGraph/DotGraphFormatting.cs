using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.Pipelines.DotGraph
{
    public static class DotGraphFormatting
    {
        private static readonly Dictionary<Type, Action<IGraphNode, NodeMetadata, StringBuilder>> PipeAppendersByType =
            new Dictionary<Type, Action<IGraphNode, NodeMetadata, StringBuilder>>
            {
                {typeof(CollectorPipe<>), AppendCollectorPipeFormatting},
                {typeof(FunctionPipe<,>), AppendFunctionPipeFormatting},
                {typeof(InputPipe<>), AppendInputPipeFormatting},
                {typeof(JoinedPipes<,>), AppendJoinedPipesFormatting},
                {typeof(AppliedPipes<,>), AppendJoinedPipesFormatting},
                {typeof(ConcattedPipes<>), AppendJoinedPipesFormatting}
            };

        private static void AppendJoinedPipesFormatting(IGraphNode node, NodeMetadata metadata, StringBuilder result)
        {
            var output = ((IGraphNodeWithOutput) node).Output;

            var label = metadata.GetCount(output) == 0 ? "" : $"label={metadata.GetQuotedDisplayName(output)}, ";
            var outputUniqueName = metadata.GetQuotedUniqueName(output);
            AppendFormat(outputUniqueName, $@"{label}color=""#9fbff4""", result);

            var functionLabel = metadata.GetCount(node) == 0 ? "" : $"label={metadata.GetQuotedDisplayName(node)}, ";
            var functionUniqueName = metadata.GetQuotedUniqueName(node);
            AppendFormat(functionUniqueName, $@"{functionLabel}color=pink", result);
        }

        private static void AppendFormat(string name, string format, StringBuilder result)
        {
            result.AppendLine($@"{name} [{format}]");
        }

        public static StringBuilder AppendFormatting(IEnumerable<IGraphNode> nodes, NodeMetadata metadata)
        {
            void ProcessNode(IGraphNode node_, NodeMetadata metadata_, StringBuilder result_)
            {
                var genericTypeDefinition = node_.GetType().GetGenericTypeDefinition();
                if (!PipeAppendersByType.ContainsKey(genericTypeDefinition))
                {
                    throw new NotImplementedException($@"No DotGraph formatting for {node_.GetType().ToReadableString()}");
                }

                PipeAppendersByType[genericTypeDefinition](node_, metadata_, result_);
            }

            var result = new StringBuilder();
            foreach (var node in nodes)
            {
                DotGraph.ProcessTree(node, result, ProcessNode, delegate { }, metadata);
            }

            return result;
        }

        private static void AppendInputPipeFormatting(IGraphNode node, NodeMetadata metadata, StringBuilder result)
        {
            var uniqueName = metadata.GetQuotedUniqueName(node);
            AppendFormat(uniqueName, @"color=green", result);
        }

        private static void AppendFunctionPipeFormatting(IGraphNode node, NodeMetadata metadata, StringBuilder result)
        {
            var output = ((IFunctionPipe) node).Output;

            var label = metadata.GetCount(output) == 0 ? "" : $"label={metadata.GetQuotedDisplayName(output)}, ";
            var outputUniqueName = metadata.GetQuotedUniqueName(output);
            AppendFormat(outputUniqueName, $@"{label}color=""#9fbff4""", result);

            var functionLabel = metadata.GetCount(node) == 0 ? "" : $"label={metadata.GetQuotedDisplayName(node)}, ";
            var functionUniqueName = metadata.GetQuotedUniqueName(node);
            AppendFormat(functionUniqueName, $@"{functionLabel}shape=invhouse", result);
        }

        private static void AppendCollectorPipeFormatting(IGraphNode node, NodeMetadata metadata, StringBuilder result)
        {
            var label = metadata.GetCount(node) == 0 ? "" : "label=Collector, ";
            var uniqueName = metadata.GetQuotedUniqueName(node);
            AppendFormat(uniqueName, $@"{label}color = ""#c361f4""", result);
        }
    }
}
