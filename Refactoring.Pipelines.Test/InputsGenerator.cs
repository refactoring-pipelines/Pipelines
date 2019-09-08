using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApprovalUtilities.Utilities;

namespace Refactoring.Pipelines.Test
{
    public class InputsGenerator
    {
        private readonly int _inputCount;
        private readonly IEnumerable<int> _outputCounts;

        public InputsGenerator(int inputCount, IEnumerable<int> outputCounts)
        {
            _inputCount = inputCount;
            _outputCounts = outputCounts;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            var inputTypeParameters = Enumerable.Range(1, _inputCount).Select(_ => $"TInput{_}").JoinWith(", ");

            result.AppendLine(
                $@"    public class Inputs<{inputTypeParameters}>
    {{
        private readonly IGraphNode _node;
        public Inputs(IGraphNode node) {{ this._node = node; }}");
            result.AppendLine();

            foreach (var outputCount in _outputCounts)
            {
                var outputTypeParameters = Enumerable.Range(1, outputCount).Select(_ => $"TOutput{_}").JoinWith(", ");

                result.AppendLine(
                    $@"        public Inputs{_inputCount}AndOutputs{outputCount}<{inputTypeParameters}, {outputTypeParameters}> AndOutputs<{outputTypeParameters}>()
        {{
            return new Inputs1AndOutputs{outputCount}<{inputTypeParameters}, {outputTypeParameters}>(this._node);
        }}
");
            }

            result.AppendLine($@"    }}");

            return result.ToString();
        }
    }
}
