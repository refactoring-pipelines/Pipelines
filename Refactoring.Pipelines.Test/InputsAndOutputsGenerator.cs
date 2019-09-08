using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using ApprovalUtilities.Utilities;
using FluentAssertions;

namespace Refactoring.Pipelines.Test
{
    class InputsAndOutputsGenerator
    {
        private readonly int inputCount;
        private readonly int outputCount;

        public InputsAndOutputsGenerator(int inputCount, int outputCount)
        {
            this.inputCount = inputCount;
            this.outputCount = outputCount;
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

            return $@"{GetUsingDirectives()}
namespace Refactoring.Pipelines.InputsAndOutputs
{{
    public class {ClassName}<{CommaSeparated(InputTypeParameters)}, {CommaSeparated(OutputTypeParameters)}>
    {{
        private readonly InputsAndOutputs _inputsAndOutputs;

{members.JoinWith("\n")}
    }}
}}
";
        }

        private string ClassName
        {
            get
            {
                return $@"Inputs{inputCount}AndOutputs{outputCount}";
            }
        }

        private string SendMethod
        {
            get
            {
                string ParameterDeclaration(int _) =>
                    $"TInput{_} value{_}";

                string SendStatement(int _) =>
                    $"            this.Input{_}.Send(value{_});";

                return $@"        public void Send({CommaSeparated(InputRange.Select(ParameterDeclaration))})
        {{
{InputRange.Select(SendStatement).JoinWith("\n")}
        }}
";
            }
        }

        private IEnumerable<int> InputRange =>
            Enumerable.Range(1, this.inputCount);

        private IEnumerable<int> OutputRange =>
            Enumerable.Range(1, this.outputCount);

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

        private static string CommaSeparated(IEnumerable<string> enumerable) { return enumerable.JoinWith(", "); }

        private string AsTupleMethod
        {
            get
            {
                return $@"        public Tuple<{InputPipes}, {CollectorPipes}> AsTuple()
        {{
            return Tuple.Create({CommaSeparated(InputAccessorNames)}, {CommaSeparated(OutputAccessorNames)});
        }}
";
            }
        }

        private string Constructor
        {
            get
            {
                return $@"        public {ClassName}(IGraphNode node)
        {{
            this._inputsAndOutputs = new InputsAndOutputs(node);
            Debug.Assert(_inputsAndOutputs.Inputs.Count == {inputCount});
            Debug.Assert(_inputsAndOutputs.Outputs.Count == {outputCount});
        }}
";
            }
        }

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

        private static string GetOutputAccessor(int index)
        {
            return GetAccessor(index, "CollectorPipe", "Output");
        }

        private string AllInputsAccessor
        {
            get
            {
                return $@"        public Tuple<{InputPipes}> Inputs
        {{
            get
            {{
                return Tuple.Create({CommaSeparated(InputAccessorNames)});
            }}
        }}
";
            }
        }

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

        private static string GetInputAccessor(int index)
        {
            return GetAccessor(index, "InputPipe", "Input");
        }

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

        private string GetUsingDirectives()
        {
            return @"using System;
using System.Diagnostics;
";
        }
    }
}
