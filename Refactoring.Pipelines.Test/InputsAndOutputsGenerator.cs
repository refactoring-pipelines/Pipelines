using System.Collections.Generic;
using System.Linq;
using ApprovalUtilities.Utilities;

namespace Refactoring.Pipelines.Test
{
    internal class InputsAndOutputsGenerator
    {
        private readonly int inputCount;
        private readonly int outputCount;

        public InputsAndOutputsGenerator(int inputCount, int outputCount)
        {
            this.inputCount = inputCount;
            this.outputCount = outputCount;
        }

        private string ClassName =>
            $@"Inputs{inputCount}AndOutputs{outputCount}";

        private string SendMethod
        {
            get
            {
                string ParameterDeclaration(int _) { return $"TInput{_} value{_}"; }

                string SendStatement(int _) { return $"            this.Input{_}.Send(value{_});"; }

                return $@"        public void Send({CommaSeparated(InputRange.Select(ParameterDeclaration))})
        {{
{InputRange.Select(SendStatement).JoinWith("\n")}
        }}
";
            }
        }

        private IEnumerable<int> InputRange =>
            Enumerable.Range(1, inputCount);

        private IEnumerable<int> OutputRange =>
            Enumerable.Range(1, outputCount);

        private IEnumerable<string> OutputTypeParameters
        {
            get
            {
                return OutputRange.Select(_ => $"TOutput{_}");
            }
        }

        private IEnumerable<string> InputTypeParameters
        {
            get
            {
                return InputRange.Select(_ => $"TInput{_}");
            }
        }

        private string AsTupleMethod
        {
            get
            {
                if (7 < InputRange.Count() + OutputRange.Count())
                {
                    return "        // AsTuple() not valid for more than 7 parameters\n";
                }

                return $@"        public Tuple<{InputPipes}, {CollectorPipes}> AsTuple()
        {{
            return Tuple.Create({CommaSeparated(InputAccessorNames)}, {CommaSeparated(OutputAccessorNames)});
        }}
";
            }
        }

        private string Constructor =>
            $@"        public {ClassName}(IGraphNode node)
        {{
            this._inputsAndOutputs = new InputsAndOutputs(node);
            Assert(_inputsAndOutputs.Inputs, {inputCount}, ""input(s)"");
            Assert(_inputsAndOutputs.Outputs, {outputCount}, ""output(s)"");
        }}

        static private void Assert(List<IGraphNode> nodes, int expectedCount, string name)
        {{
            if (nodes.Count != expectedCount)
            {{
                var names = nodes.JoinStringsWith(_ => _.Name, "", "");
                throw new Exception($""{{expectedCount}} {{name}} expected, but got [{{names}}]"");
            }}
        }}
";

        private string AllOutputsAccessor
        {
            get
            {
                var outputs = CommaSeparated(OutputAccessorNames);

                return $@"        public Tuple<{CollectorPipes}> Outputs
        {{
            get
            {{
                return Tuple.Create({outputs});
            }}
        }}
";
            }
        }

        private IEnumerable<string> OutputAccessorNames
        {
            get
            {
                return OutputRange.Select(_ => $"Output{_}");
            }
        }

        private string CollectorPipes
        {
            get
            {
                return CommaSeparated(OutputRange.Select(_ => $"CollectorPipe<TOutput{_}>"));
            }
        }

        private string AllInputsAccessor =>
            $@"        public Tuple<{InputPipes}> Inputs
        {{
            get
            {{
                return Tuple.Create({CommaSeparated(InputAccessorNames)});
            }}
        }}
";

        private IEnumerable<string> InputAccessorNames
        {
            get
            {
                return InputRange.Select(_ => $"Input{_}");
            }
        }

        private string InputPipes
        {
            get
            {
                return CommaSeparated(InputRange.Select(_ => $"InputPipe<TInput{_}>"));
            }
        }

        public override string ToString()
        {
            var members = new List<string>();

            members.Add(Constructor);
            members.AddRange(InputRange.Select(GetInputAccessor));
            members.Add(AllInputsAccessor);
            members.AddRange(OutputRange.Select(GetOutputAccessor));
            members.Add(AllOutputsAccessor);
            members.Add(AsTupleMethod);
            members.Add(SendMethod);

            return $@"namespace Refactoring.Pipelines.InputsAndOutputs
{{
    public class {ClassName}<{CommaSeparated(InputTypeParameters)}, {CommaSeparated(OutputTypeParameters)}>
    {{
        private readonly InputsAndOutputs _inputsAndOutputs;

{members.JoinWith("\n")}
    }}
}}
";
        }

        private static string CommaSeparated(IEnumerable<string> enumerable) { return enumerable.JoinWith(", "); }

        private static string GetOutputAccessor(int index) { return GetAccessor(index, "CollectorPipe", "Output"); }

        private static string GetInputAccessor(int index) { return GetAccessor(index, "InputPipe", "Input"); }

        private static string GetAccessor(int index, string type, string inputOrOutput)
        {
            return $@"        public {type}<T{inputOrOutput}{index}> {inputOrOutput}{index}
        {{
            get
            {{
                return ({type}<T{inputOrOutput}{index}>) this._inputsAndOutputs.{inputOrOutput}s[{index - 1}];
            }}
        }}
";
        }
    }
}
