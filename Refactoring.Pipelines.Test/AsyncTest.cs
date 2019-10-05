using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using ApprovalTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring.Pipelines;

namespace Refactoring.PipelinesAsync.Test
{
    [TestClass]
    public class AsyncTest
    {
        [TestMethod]
        public void ParallelRuns()
        {
            var inputPipe = new InputPipe<List<int>>("inputs");
            var listAddPipe1 = inputPipe.Process(l => AddToList(l, 1));
            var listAddPipe2 = inputPipe.Process(l => AddToList(l, 2));
            var listAddPipe3 = inputPipe.Process(l => AddToList(l, 3));
            var listAddPipe4 = inputPipe.Process(l => AddToList(l, 4));
            var listAddPipe5 = inputPipe.Process(l => AddToList(l, 5));
            var listAddPipe6 = inputPipe.Process(l => AddToList(l, 6));
            var listAddPipe7 = inputPipe.Process(l => AddToList(l, 7));


            var list = new List<int>{};
            inputPipe.Send(list);
            Approvals.VerifyAll(list, "numbers");

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
