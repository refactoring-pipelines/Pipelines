using System.Collections.Generic;
using System.Text;

namespace Pipelines
{
    public static class DotGraph
    {
        private static readonly Dictionary<string, string> formatByType = new Dictionary<string, string>
        {
            {"InputPipe`1", @"color=green"},
            {"FunctionPipe`2", @"shape=invhouse"},
            {"CollectorPipe`1", @"label=""Collector"", color=""#c361f4"""}
        };

        private static void AppendFormat(ILabeledNode node, StringBuilder result)
        {
            var format =
                formatByType.GetValueOrDefault(node.GetType().Name) ?? "";
            result.AppendLine($@"{node.Name} [{format}]");
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

        private static void Append(ILabeledNode node, StringBuilder result)
        {
            AppendFormat(node, result);

            foreach (var listener in node.Listeners)
            {
                Append(listener, result);
            }

            foreach (var listener in node.Listeners)
            {
                result.AppendLine(node.Name + " -> " + listener.Name);
                if (listener.GetType().Name == "CollectorPipe`1")
                    result.AppendLine($@"{{ rank=same; {node.Name}, {listener.Name}}}");
            }

            result.AppendLine();
        }
    }
}