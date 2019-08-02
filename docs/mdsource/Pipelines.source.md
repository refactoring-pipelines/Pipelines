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

![GraphViz of Pipeline](/Refactoring.Pipelines.Test/PipelineTests.BasicPipelineTest.approved.dot.svg)

## Actions

[Joins, ApplyTo, Concate](/docs/PipelineActions.md)