using System;
using System.Collections.Generic;
using System.Text;

namespace Pipelines
{
    public static class DotGraph
    {
        static string Quoted(string value)
        {
            return $@"""{value}""";
        }

        public static string FromPipeline<T>(InputPipe<T> root)
        {
            return $@"
digraph G {{ node [style=filled, shape=rec]

{AppendNodeAndChildren(root)}
{AppendFormatting(root)}
{AppendRankings(root)}

}}
".Trim();
        }

        static void AppendFormat(string name, string format, StringBuilder result)
        {
            result.AppendLine($@"{Quoted(name)} [{format}]");
        }

        static readonly Dictionary<Type, Action<ILabeledNode, StringBuilder>> PipeAppendersByType =
            new Dictionary<Type, Action<ILabeledNode, StringBuilder>>
            {
                { typeof(CollectorPipe<>), AppendCollectorPipeFormatting },
                { typeof(FunctionPipe<,>), AppendFunctionPipeFormatting },
                { typeof(InputPipe<>), AppendInputPipeFormatting },
            };

        private static StringBuilder AppendNodeAndChildren(ILabeledNode node)
        {
            Action< ILabeledNode , ILabeledNode, StringBuilder> processChild = (node_, child_, result_) => result_.AppendLine(Quoted(node_.OutgoingName) + " -> " + Quoted(child_.IncomingName));
            return ProcessTree(node, new StringBuilder(), AppendFunctionPipe, processChild);

        }

        private static StringBuilder AppendFormatting(ILabeledNode node)
        {
            Action<ILabeledNode, StringBuilder> processNode = (node_, result_) => PipeAppendersByType[node_.GetType().GetGenericTypeDefinition()](node_, result_);
            return ProcessTree(node, new StringBuilder(), processNode, delegate { });
        }

        private static StringBuilder ProcessTree(ILabeledNode node, StringBuilder result, Action<ILabeledNode, StringBuilder> processNode, Action<ILabeledNode, ILabeledNode, StringBuilder> processChild)
        {
            processNode(node, result);

            foreach (var listener in node.Listeners)
            {
                processChild(node, listener, result);
                ProcessTree(listener, result, processNode, processChild);
            }
            return result;
        }

        private static StringBuilder AppendRankings(ILabeledNode node)
        {
            return ProcessTree(node, new StringBuilder(), delegate { }, ProcessChildRanking);

        }

        private static void ProcessChildRanking(ILabeledNode node, ILabeledNode listener, StringBuilder result)
        {
            if (listener.GetType().GetGenericTypeDefinition() == typeof(CollectorPipe<>))
                result.AppendLine($@"{{ rank=same; {Quoted(node.OutgoingName)}, {Quoted(listener.IncomingName)}}}");
        }

        private static void AppendFunctionPipe(ILabeledNode node, StringBuilder result)
        {
            result.AppendLine(Quoted(node.IncomingName) + " -> " + Quoted(node.OutgoingName));
        }

        private static void AppendInputPipeFormatting(ILabeledNode node, StringBuilder result)
        {
            AppendFormat(node.IncomingName, @"color=green", result);
        }


        private static void AppendFunctionPipeFormatting(ILabeledNode node, StringBuilder result)
        {
            AppendFormat((node.IncomingName), @"shape=invhouse", result);
            AppendFormat((node.OutgoingName), @"color=""#9fbff4""", result);
        }

        private static void AppendCollectorPipeFormatting(ILabeledNode node, StringBuilder result)
        {
            AppendFormat(node.IncomingName, @"label=Collector, color=""#c361f4""", result);
        }
    }
}