namespace Refactoring.Pipelines
{
    //[UseReporter(typeof(DotReporter))]
    //[TestClass]
    //public class InputsAndOutputsTests
    //{
    //    [TestMethod]
    //    public void SingleBranchPipe()
    //    {
    //        var input = new InputPipe<int>("input");
    //        var middle = input.Process(p => p + 1);
    //        var end = middle.Process(p => p.ToString()).Collect();

    //        //var inputsAndOutputs = middle.GetInputsAndOutputs<int, string>();
    //        var inputsAndOutputs = middle.GetInputsAndOutputs();

    //        Assert.AreEqual(input, inputsAndOutputs.GetInput<int>());
    //        Assert.AreEqual(end, inputsAndOutputs.GetOutput<string>());
    //        inputsAndOutputs.Send<int>(1);
    //        Assert.AreEqual("2", inputsAndOutputs.GetSingleResult<string>());
    //    }

    //    [TestMethod]
    //    public void MultipleBranchesPipe()
    //    {
    //        var input1 = new InputPipe<int>("input1");
    //        var input2 = new InputPipe<int>("input2");
    //        var joinedPipes = input1.JoinTo(input2);
    //        var sumCollector = joinedPipes.Process((a, b) => a + b).Collect();
    //        var productCollector = joinedPipes.Process((a, b) => a * b).Collect();
    //        //var inputsAndOutputs = joinedPipes.Get2InputsAnd2Outputs<int, int, int, int>();
    //        //var inputsAndOutputs = joinedPipes.GetInputsAndOutputs<Tuple<int, int>, Tuple<int, int>>();
    //        //var inputsAndOutputs = joinedPipes.GetInputs<int, int>().AndOutputs<int, int>>();


    //        Assert.AreEqual(new[] {input1, input2}, inputsAndOutputs.GetInputs());
    //        Assert.AreEqual((input1, input2), inputsAndOutputs.GetInputs<int, int>());
    //        Assert.AreEqual(new[] {sumCollector, productCollector}, inputsAndOutputs.GetOutputs());
    //        Assert.AreEqual((sumCollector, productCollector ), inputsAndOutputs.GetOutputs<int, int>());

    //        inputsAndOutputs.Send<int, int>(3, 4);
    //        int sum = inputsAndOutputs.GetOutputAsCollector<int>(0).SingleResult;
    //        Assert.AreEqual(7, sum);
    //        int product = inputsAndOutputs.GetOutputAsCollector<int>(1).SingleResult;
    //        Assert.AreEqual(12, product);
    //    }

    //}

    //internal static class ___
    //{
    //    public static FunctionPipe<TInput, TOutput> WithCollector<TInput, TOutput>(
    //        this FunctionPipe<TInput, TOutput> @this)
    //    {
    //        @this.Collect();
    //        return @this;
    //    }

    //    public static InputsWithoutOutputs GetInputs<T1, T2>() { return new InputsWithoutOutputs<T1, T2>(); }

    //    //public static InputsAndOutputs GetInputsAndOutputs(this IGraphNode node)
    //    //{
    //    //    var result = new InputsAndOutputs();
    //    //    result.AddInput(node.Parents.Single());
    //    //    result.AddOutput(((ISender) ((ISender) node).Children.Single()).Collector);
    //    //    return result;
    //    //}
    //}

    //public class 

    //public class InputsAndOutputs
    //{
    //    readonly private List<IGraphNode> _inputs = new List<IGraphNode>();
    //    readonly private List<IGraphNode> _outputs = new List<IGraphNode>();
    //    public void AddInput(IGraphNode node) { this._inputs.Add(node); }
    //    public void AddOutput(IGraphNode node) { this._outputs.Add(node); }

    //    public InputPipe<T> GetInput<T>() { return (InputPipe<T>) _inputs.Single(); }
    //    public Tuple<InputPipe<T1>, InputPipe<T2>> GetInput<T1, T2>() { return 
    //        Tuple.Create ((InputPipe<T1>) _inputs.Single(),
    //        (InputPipe<T2>) _inputs.Single());

    //    }
    //    public IGraphNode[] GetInputs() { return _inputs.ToArray(); }


    //    public void Send<T>(T value) { GetInput<T>().Send(value); }

    //    public IListener<T> GetOutput<T>() { return (IListener<T>) _outputs.Single(); }

    //    public T GetSingleResult<T>() { return ((CollectorPipe<T>) GetOutput<T>()).SingleResult; }

    //    public IGraphNode[] GetOutputs() { return _outputs.ToArray(); }
    //}
}
