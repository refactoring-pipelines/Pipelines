using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ApprovalTests;
using ApprovalUtilities.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring.Pipelines.Async;

namespace Refactoring.PipelinesAsync.Test
{
    [TestClass]
    public class AsyncTest
    {
        [TestMethod]
        public void ParallelRuns()
        {
            var inputPipe = new InputPipe<List<int>>("inputs");
            var echoPipe = inputPipe /*.Process(_ =>_)*/;
            var listAddPipe1 = echoPipe.Process(l => AddToList(l, 1));
            var listAddPipe2 = echoPipe.Process(l => AddToList(l, 2));
            var listAddPipe3 = echoPipe.Process(l => AddToList(l, 3));
            var listAddPipe4 = echoPipe.Process(l => AddToList(l, 4));
            var listAddPipe5 = echoPipe.Process(l => AddToList(l, 5));
            var listAddPipe6 = echoPipe.Process(l => AddToList(l, 6));
            var listAddPipe7 = echoPipe.Process(l => AddToList(l, 7));


            var list1 = new List<int> { };
            var list2 = new List<int> { };
            inputPipe.Send(list1);
            inputPipe.Send(list2);
            Assert.AreNotEqual(list1.ToReadableString(), list2.ToReadableString());
            Assert.AreEqual(list1.OrderBy(_ => _).ToReadableString(), list2.OrderBy(_ => _).ToReadableString());
        }

        private static readonly Random random = new Random();

        private static int AddToList(List<int> l, int value)
        {
            Thread.Sleep(random.Next(50, 100));
            l.Add(value);
            return value;
        }
    }
}
