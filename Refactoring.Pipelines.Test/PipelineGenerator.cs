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
        public string Result;

        public override void VisitParameter(ParameterSyntax node)
        {
            Result += "// Parameter: " + node + "\n";

            string Generate(ParameterSyntax syntax)
            {
                return $@"var {syntax.Identifier}Pipe = new InputPipe<{syntax.Type}>(""{syntax.Identifier}"");";
            }

            Result += Generate(node) + "\n";
            Result += "\n";

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

            Result += ($"{identifierNames.First()}Pipe");

            if (identifierNames.Count() > 1)
            {
                Result += ($".JoinTo({identifierNames.Skip(1).Select(_ => _ + "Pipe").JoinWith(", ")})");
            }

            var parameterList = "(" + identifierNames.JoinWith(", ") + ")";
            var expression = node.Expression;
            Result += ($".Process({parameterList} => {expression}{parameterList});");

            this.Result += "\n";


            base.VisitInvocationExpression(node);
        }

        public override void VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
        {
            Result += "// " + node + "\n";
            var variableDeclaratorSyntax = node.Declaration.Variables.Single();
            Result += ($"var {variableDeclaratorSyntax.Identifier}Pipe = ");
            base.VisitLocalDeclarationStatement(node);
            Result += "\n";
        }

        public static string Generate(string input)
        {
            var syntaxTree = CSharpSyntaxTree.ParseText(input);
            if (syntaxTree.GetDiagnostics().Count() > 0)
            {
                throw new Exception("parse error");
            }

            var rootSyntaxNode = (CompilationUnitSyntax) syntaxTree.GetRoot();

            var pipelineGenerator = new PipelineGenerator();
            pipelineGenerator.Visit(rootSyntaxNode);
            return pipelineGenerator.Result.Trim();
        }
    }
}
