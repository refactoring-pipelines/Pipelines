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
            var result = new StringBuilder();
            Append(root, result);

            return $@"
digraph G {{ node [style=filled, shape=rec]

{result}
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
                { typeof(CollectorPipe<>), AppendCollectorPipe },
                { typeof(FunctionPipe<,>), AppendFunctionPipe },
                { typeof(InputPipe<>), AppendInputPipe },
            };

        private static void Append(ILabeledNode node, StringBuilder result)
        {
            // these shouldn't be necessary, but they help make it more obvious when something else is wrong
            result.AppendLine(Quoted(node.IncomingName));
            result.AppendLine(Quoted(node.OutgoingName));

            PipeAppendersByType[node.GetType().GetGenericTypeDefinition()](node, result);

            foreach (var listener in node.Listeners)
            {
                if (listener.GetType().GetGenericTypeDefinition() == typeof(CollectorPipe<>))
                    result.AppendLine($@"{{ rank=same; {Quoted(node.OutgoingName)}, {Quoted(listener.IncomingName)}}}");

                result.AppendLine(Quoted(node.OutgoingName) + " -> " + Quoted(listener.IncomingName));

                Append(listener, result);
            }
        }

        private static void AppendInputPipe(ILabeledNode node, StringBuilder result)
        {
            AppendFormat(node.IncomingName, @"color=green", result);
        }

        private static void AppendFunctionPipe(ILabeledNode node, StringBuilder result)
        {
            result.AppendLine(Quoted(node.IncomingName) + " -> " + Quoted(node.OutgoingName));
            AppendFormat((node.IncomingName), @"shape=invhouse", result);
            AppendFormat((node.OutgoingName), @"color=""#9fbff4""", result);
        }

        private static void AppendCollectorPipe(ILabeledNode node, StringBuilder result)
        {
            AppendFormat(node.IncomingName, @"label=Collector, color=""#c361f4""", result);
        }
    }
}