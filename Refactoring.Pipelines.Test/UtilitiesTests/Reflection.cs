using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring.Pipelines.ReflectionUtilities;

namespace Refactoring.Pipelines.Test.UtilitiesTests
{
    [TestClass]
    public class Reflection
    {
        [TestMethod]
        public void ToReadableString()
        {
            typeof(int).ToReadableString().Should().Be("Int32");
            typeof(AClass).ToReadableString().Should().Be("AClass");
            Tuple.Create(1, new AClass()).GetType().ToReadableString().Should().Be("Tuple<Int32, AClass>");
        }

        private class AClass
        {
        }
    }
}
