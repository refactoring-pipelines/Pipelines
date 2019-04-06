using System;
using System.Linq;
using System.Text;

namespace Pipelines
{
    public class FunctionPipe<TInput, TOutput> : Sender<TOutput>, IListener<TInput>
    {
        private readonly Func<TInput, TOutput> _func;
        private readonly Sender<TInput> _predecessor;

        public FunctionPipe(Func<TInput, TOutput> func, Sender<TInput> predecessor)
        {
            _func = func;
            _predecessor = predecessor;
            predecessor.AddListener(this);
        }

        public override string NodeName => $@"""{_func.Method.DeclaringType.Name}.{_func.Method.Name}()""";

        public void OnMessage(TInput input)
        {
            var result = _func(input);
            _Send(result);
        }

        public CollectorPipe<TOutput> Collect()
        {
            return new CollectorPipe<TOutput>(this);
        }

        string GetOutputNames()
        {
            return "{" + OutputName + PrintCollector() + "}";
        }

        private string PrintCollector()
        {
            var collector = this._listeners.OfType<CollectorPipe<TOutput>>().SingleOrDefault();
            return collector == null ? "" : ", " + collector.NodeName;
        }

        public override string ToString()
        {
            return $@"
{_predecessor.NodeName} -> {NodeName} -> {GetOutputNames()}
{PrintFormatting()}
";

        }

        private string PrintFormatting()
        {
            var result = new StringBuilder();
            var collector = this._listeners.OfType<CollectorPipe<TOutput>>().SingleOrDefault();
            result.AppendLine(collector == null ? "" : collector.PrintFormatting());

            result.AppendLine($@"{OutputName} [color=""#9fbff4""]");
            result.AppendLine($@"{NodeName} [shape=invhouse]");
            return result.ToString();

        }

        private static string OutputName => typeof(TOutput).Name;
    }

}