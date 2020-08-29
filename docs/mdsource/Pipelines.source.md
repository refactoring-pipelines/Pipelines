# Pipelines

toc

## Creating Pipelines

### Basic pipelines

Let's say you have the following line of code:

snippet: basic_code_line

You can refactor this to pipelines with the following

snippet:  basic_pipeline

These will produce the same results.

### But Why?!?!

Despite the complexity add of this code, this pattern has some advantages in refactoring to async 
as well has advantages in monitoring. It also has advantages in testing and visualization.
For example the pipeline can render itself as the following dot file (Graphviz)

![GraphViz of Pipeline](/Refactoring.Pipelines.Test/_approvals/PipelineTests.BasicPipelineTest.approved.svg)

## Actions

[Joins, ApplyTo, Concate](/docs/PipelineActions.md)

## Output Generation Testing
When verifying a pipeline graph, you can generate either a GraphViz diagram or an image in PNG or SVG format.

### GraphViz

If you want to verify a `Pipeline`, you can call `PipelineApprovals.Verify()`:

snippet: graphviz_approval

Which produces the following approved file:

snippet: _approvals/PipelineTests.SplitInput.approved.txt


Usually we open these in Visual Studio Code with a plugin. The advantage of these files is that they diff easily and render nicely.

### PNG/SVG

If you want to create the images, you can do that automatically as well, using the following:

snippet: graphviz_png_approval

which produces the following approved file:

![GraphViz of Pipeline in PNG format](/Refactoring.Pipelines.Test/_approvals/PipelineTests.TestPng.approved.png)