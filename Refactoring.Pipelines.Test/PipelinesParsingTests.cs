using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ApprovalTests;
using FluentAssertions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Refactoring.Pipelines.Test
{
    [TestClass]
    public class AlwaysFailCSharpSyntaxVisitorTest
    {
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void EveryMethodIsOverriden()
        {
            var baseMethods = GetVisitMethods(typeof(AlwaysFailCSharpSyntaxVisitor<>)).Select(_ => _.Name);
            var thisMethods = GetVisitMethods(typeof(CSharpSyntaxVisitor<>)).Select(_ => _.Name);
            baseMethods.Should().BeEquivalentTo(thisMethods);
        }

        private IEnumerable<MethodInfo> GetVisitMethods(Type type)
        {
            return type.Methods().Where(_ => _.Name.StartsWith("Visit") && _.Name != "Visit");
        }
    }

    [TestClass]
    public class PipelinesParsingTests
    {
        [TestMethod]
        public void Parameters()
        {
            var result = PipelineGenerator.Generate(
                @"
Sandwich FindBestSandwich(ZipCode zipCode) { /* ... */ }
");
            Approvals.Verify(result);
        }

        [TestMethod]
        public void Invocation()
        {
            var result = PipelineGenerator.Generate(
                @"
                void _() 
                {
                    var peanutButters = PeanutButterShop.GetAvailable(zipCode); 
                }
");
            Approvals.Verify(result);
        }

        [TestMethod]
        public void Joined()
        {
            var result = PipelineGenerator.Generate(
                @"
                void _(int value1, int value2)
                {
                    var result = F(value1, value2);
                }
");
            Approvals.Verify(result);
        }

        [TestMethod, Ignore]
        public void MyTestMethod()
        {
            var input = @"
                Sandwich FindBestSandwich(ZipCode zipCode)
                {
                    var peanutButters = PeanutButterShop.GetAvailable(zipCode);
                    var jellies = JellyShop.GetAvailable(zipCode);
                    var bestPeanutButter = peanutButters.BestPeanutButter;
                    var bestJelly = jellies.BestJelly;
                    var bestSandwich = Sandwich.Create(bestPeanutButter, bestJelly);
                    return bestSandwich;
                }
";
            var result = PipelineGenerator.Generate(input);
            Approvals.Verify(result);
        }

        // force this assembly to load
        static readonly Type _ = typeof(Microsoft.CodeAnalysis.CSharp.Formatting.CSharpFormattingOptions);
    }
}
