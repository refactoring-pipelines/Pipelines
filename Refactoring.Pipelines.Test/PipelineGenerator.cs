using System;
using System.Linq;
using System.Text;
using ApprovalUtilities.Utilities;
using FluentAssertions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Refactoring.Pipelines.Test
{
    public class PipelineGenerator : CSharpSyntaxWalker
    {
        private readonly StringBuilder _stringBuilder;

        public PipelineGenerator(StringBuilder stringBuilder) { _stringBuilder = stringBuilder; }

        public override void VisitParameter(ParameterSyntax node)
        {
            _stringBuilder.AppendLine("// Parameter: " + node);

            string Generate(ParameterSyntax syntax)
            {
                return $@"var {syntax.Identifier}Pipe = new InputPipe<{syntax.Type}>(""{syntax.Identifier}"");";
            }

            _stringBuilder.AppendLine(Generate(node));
            _stringBuilder.AppendLine();

            base.VisitParameter(node);
        }

        public override void VisitInvocationExpression(InvocationExpressionSyntax node)
        {
            var arguments = node.ArgumentList.Arguments;
            if (arguments.Count == 0)
            {
                throw new NotImplementedException();
            }

            var identifierNames = arguments.Select(_ => _.Expression)
                .Cast<IdentifierNameSyntax>()
                .Select(_ => _.Identifier.Text);

            this._stringBuilder.Append($"{identifierNames.First()}Pipe");

            if (identifierNames.Count() > 1)
            {
                this._stringBuilder.Append(
                    $".JoinTo({identifierNames.Skip(1).Select(_ => _ + "Pipe").JoinWith(", ")})");
            }

            var parameterList = "(" + identifierNames.JoinWith(", ") + ")";
            var expression = node.Expression;
            this._stringBuilder.Append($".Process({parameterList} => {expression}{parameterList});");

            this._stringBuilder.AppendLine();


            base.VisitInvocationExpression(node);
        }

        public override void VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
        {
            _stringBuilder.AppendLine("// " + node);
            var variableDeclaratorSyntax = node.Declaration.Variables.Single();
            _stringBuilder.Append($"var {variableDeclaratorSyntax.Identifier}Pipe = ");
            base.VisitLocalDeclarationStatement(node);
            _stringBuilder.AppendLine();
        }

        public static string Generate(string input)
        {
            var syntaxTree = CSharpSyntaxTree.ParseText(input);
            syntaxTree.GetDiagnostics().Count().Should().Be(0);
            var rootSyntaxNode = (CompilationUnitSyntax) syntaxTree.GetRoot();
            var memberDeclarationSyntax = rootSyntaxNode.Members.Single();

            var stringBuilder = new StringBuilder();
            new PipelineGenerator(stringBuilder).Visit(memberDeclarationSyntax);
            return stringBuilder.ToString().Trim();
        }
    }
}
