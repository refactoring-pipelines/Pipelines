- [ ] create new project, with test and pipeline approvals

- [ ] Sketch out scenario

- [ ] Create test that gets a pipeline

``` cpp
public void TestMethod1()
{
      PipelineApprovals.Verify(Template.DoSomethingViaPipeline()));
 }

public class Template
{
    public static Inputs1AndOutputs1<Input, Output> DoSomethingViaPipeline()
    {
        InputPipe<Input> input = new InputPipe<Input>("Your Input");
            var outputPipe = input.ProcessFunction(DoEverything);
            var collectorPipe = outputPipe.Collect();
            return collectorPipe.GetInputs<Input>().AndOutputs<Output>();
        }
        public static Output DoEverything(Input arg)
       {
            throw new System.NotImplementedException();
        }
    }



```

- [ ] Add Steps (no implementation)

- [ ] Fill implementation

  - [ ] Test steps

