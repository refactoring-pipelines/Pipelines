using System;
using System.Collections.Generic;
using System.Linq;

namespace Refactoring.Pipelines
{
    public class InputPipe<T> : Sender<T>
    {
        private readonly string _label;

        public InputPipe(string label) { _label = label; }

        public override string Name =>
            $@"{PrettyTypeName(typeof(T))} {_label}";

        public static string PrettyTypeName(Type type)
        {
            if (type.IsGenericType)
            {
                return string.Format(
                    "{0}<{1}>",
                    type.Name.Substring(0, type.Name.LastIndexOf("`", StringComparison.InvariantCulture)),
                    string.Join(", ", type.GetGenericArguments().Select(PrettyTypeName)));
            }

            return type.Name;
        }


        public override IEnumerable<IGraphNode> Parents =>
            Enumerable.Empty<IGraphNode>();

        public void Send(T value) { _Send(value); }
    }
}
