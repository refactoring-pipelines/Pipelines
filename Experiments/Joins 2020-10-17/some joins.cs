var joined = input1.JoinTo(input2)
joined.Process((a, b) => a + b);
joined.Process((a, b) => a - b);

input1.ApplyTo(input2).Process((a, b) => a + b);
Process(input1, input2, (a, b) => a + b)

input1.JoinTo(input2).JoinTo(input3).JoinTo(input4).Process((a, b, c, d) => a + b + c + d)
input1.JoinWith(input2, input3, input4).Process((a, b, c, d) => a + b + c + d)

Join(input1, input2, input3, input4).Process((a, b, c, d) => a + b + c + d)   // <--- llewellyn
Concat(input1, input2, input3, input4).Process(a => a.Length)
Process(input1, input2, input3, input4, (a, b, c, d) => a + b + c + d)

Join(input1, input2, input3, input4).Process(Add)
Process(input1, input2, input3, input4, Add)

    FizzBuzz(i) ?? Fizz(i) ?? Buzz(i) ?? TheNumber(i)
    (Fizz(i) + Buzz(i)) || i

Foo() || throw "Foo failed"

Process((a, b) => a + b, input1, input2)
input1.Process((a, b) => a + b, input2);

        [TestMethod]
        public void TestFourWayJoin()
        {
            var input1 = new InputPipe<int>("input1");
            var input2 = new InputPipe<int>("input2");
            var input3 = new InputPipe<int>("input3");
            var input4 = new InputPipe<int>("input4");

            var joinedPipes = input1.JoinTo(input2)
                .JoinTo(input3)
                .JoinTo(input4);
            var collector = joinedPipes
                .Process((a, b) => a.Item1.Item1 + a.Item1.Item2 + a.Item2 + b)
                .Collect();
            var collector2 = joinedPipes
                .Process((a, b) => a.Item1.Item1 * a.Item1.Item2 * a.Item2 * b)
                .Collect();

            PipelineApprovals.Verify(collector);
        }

