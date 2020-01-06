using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ApprovalUtilities.Utilities;
using FluentAssertions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Refactoring.Pipelines.Test
{
    class PipelineGenerator : AlwaysFailCSharpSyntaxVisitor<string>
    {
        public override string VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            var result = "";

            var inputPipesGenerator = new InputPipesGenerator();
            result += inputPipesGenerator.Visit(node.ParameterList);

            var statementPipesGenerator = new StatementPipesGenerator();
            result += node.Body.Statements.Select(statementPipesGenerator.Visit).JoinWith("\n");

            return result;
        }

        public class StatementPipesGenerator : AlwaysFailCSharpSyntaxVisitor<string>
        {
            public override string VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
            {
                string Result = "";
                var variableDeclaratorSyntax = node.Declaration.Variables.Single();
                Result += ($"var {variableDeclaratorSyntax.Identifier}Pipe = ");
                Visit(variableDeclaratorSyntax.Initializer.Value);
                return Result;
            }
        }

        public class InputPipesGenerator : AlwaysFailCSharpSyntaxVisitor<string>
        {
            public override string VisitParameterList(ParameterListSyntax node)
            {
                return node.Parameters.Select(Visit).JoinWith("\n") + "\n";
            }

            public override string VisitParameter(ParameterSyntax node)
            {
                return $@"var {node.Identifier}Pipe = new InputPipe<{node.Type}>(""{node.Identifier}"");";
            }
        }


        //    public override void VisitInvocationExpression(InvocationExpressionSyntax node)
        //    {
        //        var arguments = node.ArgumentList.Arguments;
        //        if (arguments.Count == 0)
        //        {
        //            throw new NotImplementedException();
        //        }

        //        var identifierNames = arguments.Select(_ => _.Expression)
        //            .Cast<IdentifierNameSyntax>()
        //            .Select(_ => _.Identifier.Text);

        //        Result += ($"{identifierNames.First()}Pipe");

        //        if (identifierNames.Count() > 1)
        //        {
        //            Result += ($".JoinTo({identifierNames.Skip(1).Select(_ => _ + "Pipe").JoinWith(", ")})");
        //        }

        //        var parameterList = "(" + identifierNames.JoinWith(", ") + ")";
        //        var expression = node.Expression;
        //        Result += ($".Process({parameterList} => {expression}{parameterList});");

        //        this.Result += "\n";


        //        base.VisitInvocationExpression(node);
        //    }


        public static string Generate(string input)
        {
            var syntaxTree = CSharpSyntaxTree.ParseText(input);
            if (syntaxTree.GetDiagnostics().Count() > 0)
            {
                throw new Exception("parse error");
            }

            var method = (MethodDeclarationSyntax) ((CompilationUnitSyntax) syntaxTree.GetRoot()).Members.Single();

            var pipelineGenerator = new PipelineGenerator();
            var result = pipelineGenerator.Visit(method);
            return result;
        }
    }
}
