# Pipelines

<!-- toc -->
## Contents

  * [Creating Pipelines](#creating-pipelines)
    * [Basic pipelines](#basic-pipelines)
    * [But Why?!?!](#but-why)
  * [Actions](#actions)
  * [Output Generation Testing](#output-generation-testing)<!-- endToc -->

## Creating Pipelines

### Basic pipelines

Let's say you have the following line of code:

<!-- snippet: basic_code_line -->
<a id='snippet-basic_code_line'></a>
```cs
var result = long.Parse(age);
```
<sup><a href='#snippet-basic_code_line' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

You can refactor this to pipelines with the following

<!-- snippet: basic_pipeline -->
<a id='snippet-basic_pipeline'></a>
```cs
var inputPipe = new InputPipe<string>("age");
var parsePipe = inputPipe.ProcessFunction(long.Parse);
var collector = parsePipe.Collect();

inputPipe.Send("42");
var result = collector.SingleResult;
```
<sup><a href='#snippet-basic_pipeline' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

These will produce the same results.

### But Why?!?!

Despite the complexity add of this code, this pattern has some advantages in refactoring to async 
as well has advantages in monitoring. It also has advantages in testing and visualization.
For example the pipeline can render itself as the following dot file (Graphviz)

![GraphViz of Pipeline](/Refactoring.Pipelines.Test/_approvals/PipelineTests.BasicPipelineTest.approved.svg)

## Actions

[Joins, ApplyTo, Concate](/docs/PipelineActions.md)

## Output Generation Testing

See [Testing Pipelines and Generating Output](/docs/TestingPipelines.md).
