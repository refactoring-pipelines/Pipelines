using System.Linq;
using ApprovalUtilities.Utilities;

namespace Refactoring.Pipelines.Test
{
    public class InputsExtensionsGenerator
    {
        private readonly int _inputCount;
        public InputsExtensionsGenerator(int inputCount) { _inputCount = inputCount; }

        public override string ToString()
        {
            var inputTypeParameters = Enumerable.Range(1, _inputCount).Select(_ => $"TInput{_}").JoinWith(", ");

            return $@"
namespace Refactoring.Pipelines.InputsAndOutputs
{{
    public static class Inputs{_inputCount}Extensions
    {{
        public static Inputs<{inputTypeParameters}> GetInputs<{inputTypeParameters}>(this IGraphNode node)
        {{
            return new Inputs<{inputTypeParameters}>(node);
        }}
    }}
}}
";
        }
    }
}
