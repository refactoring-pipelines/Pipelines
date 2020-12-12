- [ ] Create new C# test project. Add Pipeline Approvals NuGet packages.

- [ ] Sketch out scenario in whiteboard or equivalent.

- [ ] Create test that gets a pipeline:

``` cpp
[TestMethod]
public void TestMethod1()
{
      PipelineApprovals.Verify(Template.DoSomethingViaPipeline());
 }

public class Template
{
    public static Inputs1AndOutputs1<TInput, TOutput> DoSomethingViaPipeline()
    {
        InputPipe<TInput> input = new InputPipe<TInput>("Your Input");
            var outputPipe = input.ProcessFunction(DoEverything);
            var collectorPipe = outputPipe.Collect();
            return collectorPipe.GetInputs<TInput>().AndOutputs<TOutput>();
        }
        public static TOutput DoEverything(TInput input)
       {
            throw new System.NotImplementedException();
        }
    }
}
```

- [ ] Add Steps (no implementation)

- [ ] Fill implementation

  - [ ] Test each step

