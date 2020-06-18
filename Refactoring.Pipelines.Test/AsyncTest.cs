using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ApprovalTests.Reporters;
using ApprovalUtilities.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring.Pipelines.ApprovalTests;
using Refactoring.Pipelines.Async;
using Refactoring.Pipelines.InputsAndOutputs;

namespace Refactoring.PipelinesAsync.Test
{
    [TestClass]
    public class AsyncTest
    {
        private static readonly Random random = new Random();

        [TestMethod]
        public void ParallelRuns()
        {
            var inputPipe = new InputPipe<ConcurrentBag<int>>("inputs");
            var echoPipe = inputPipe.Process(_ => _);
            var listAddPipe1 = echoPipe.Process(l => AddToList(l, 1));
            var listAddPipe2 = echoPipe.Process(l => AddToList(l, 2));
            var listAddPipe3 = echoPipe.Process(l => AddToList(l, 3));
            var listAddPipe4 = echoPipe.Process(l => AddToList(l, 4));
            var listAddPipe5 = echoPipe.Process(l => AddToList(l, 5));
            var listAddPipe6 = echoPipe.Process(l => AddToList(l, 6));
            var listAddPipe7 = echoPipe.Process(l => AddToList(l, 7));

            var joinedPipe = listAddPipe1.JoinTo(listAddPipe2);

            var list1 = new ConcurrentBag<int>();
            var list2 = new ConcurrentBag<int>();
            inputPipe.Send(list1);
            inputPipe.Send(list2);
            Assert.AreNotEqual(list1.ToReadableString(), list2.ToReadableString());
            Assert.AreEqual(list1.OrderBy(_ => _).ToReadableString(), list2.OrderBy(_ => _).ToReadableString());

            PipelineApprovals.Verify(inputPipe);
        }

        [TestMethod]
        public void InputsAndOutputs()
        {
            var inputPipe = new InputPipe<int>("input1");
            var collectorPipe = inputPipe.Collect();
            var subject = inputPipe.GetInputs<int>().AndOutputs<int>();
            Assert.AreEqual(inputPipe, subject.Input1);
            Assert.AreEqual(collectorPipe, subject.Output1);
        }

        private static int AddToList(ConcurrentBag<int> l, int value)
        {
            Thread.Sleep(random.Next(50, 100));
            l.Add(value);
            return value;
        }
    }
}
