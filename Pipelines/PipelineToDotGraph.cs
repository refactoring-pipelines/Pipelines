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

        private static void Append(ILabeledNode node, StringBuilder result)
        {
            // these shouldn't be necessary, but they help make it more obvious when something else is wrong
            result.AppendLine(Quoted(node.IncomingName));
            result.AppendLine(Quoted(node.OutgoingName));

            if (node.GetType().Name == typeof(CollectorPipe<>).Name)
            {
                AppendFormat(node.IncomingName, @"label=Collector, color=""#c361f4""", result);
            }
            else if (node.GetType().Name == typeof(FunctionPipe<,>).Name)
            {
                result.AppendLine(Quoted(node.IncomingName) + " -> " + Quoted(node.OutgoingName));
                AppendFormat((node.IncomingName), @"shape=invhouse", result);
                AppendFormat((node.OutgoingName), @"color=""#9fbff4""", result);
            }
            else if (node.GetType().Name == typeof(InputPipe<>).Name)
            {
                AppendFormat(node.IncomingName, @"color=green", result);
            }
            else
            {
                throw new ArgumentOutOfRangeException(node.GetType().Name);
            }

            foreach (var listener in node.Listeners)
            {
                if (listener.GetType().Name == typeof(CollectorPipe<>).Name)
                    result.AppendLine($@"{{ rank=same; {Quoted(node.OutgoingName)}, {Quoted(listener.IncomingName)}}}");

                result.AppendLine(Quoted(node.OutgoingName) + " -> " + Quoted(listener.IncomingName));

                Append(listener, result);
            }
        }
    }
}