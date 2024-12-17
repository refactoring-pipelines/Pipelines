# Pipeline Actions

<!-- toc -->
## Contents

  * [Joining pipes](#joining-pipes)
  * [ApplyTo(list)](#applytolist)
  * [ConcatWith(list)](#concatwithlist)
  * [Processing a Lambda](#processing-a-lambda)<!-- endToc -->

## Joining pipes

When you have two inputs that are needed for the next piece of functionality, you need a `JoinedPipe`.

`JoinedPipe`s produce a `Tuple` of two inputs.

Note: If you are using `JoinedPipe` you need to call `Verify()` with the join.

<!-- snippet: joined_pipeline -->
<a id='snippet-joined_pipeline'></a>
```cs
var input1 = new InputPipe<long>("value1");
var input2 = new InputPipe<long>("value2");
var join = input1.JoinTo(input2);
```
<sup><a href='/Refactoring.Pipelines.Test/PipelineTests.cs#L205-L209' title='Snippet source file'>snippet source</a> | <a href='#snippet-joined_pipeline' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

will produce:

![GraphViz of JoinedPipe](/Refactoring.Pipelines.Test/_approvals/PipelineTests.JoinInputsSample.approved.svg)

## ApplyTo(list)

Sometimes you will want a special type of Join which takes one thing and applies it to each element of a separate list.

For example, if you had:

<!-- snippet: ApplyTo_inputs -->
<a id='snippet-ApplyTo_inputs'></a>
```cs
var apply = "#";
var to = new[] {1, 2};
```
<sup><a href='/Refactoring.Pipelines.Test/PipelineTests.cs#L232-L235' title='Snippet source file'>snippet source</a> | <a href='#snippet-ApplyTo_inputs' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

You can combine them to produce the following output:

<!-- snippet: ApplyTo_outputs -->
<a id='snippet-ApplyTo_outputs'></a>
```cs
var result = "[(#, 1), (#, 2)]";
```
<sup><a href='/Refactoring.Pipelines.Test/PipelineTests.cs#L237-L239' title='Snippet source file'>snippet source</a> | <a href='#snippet-ApplyTo_outputs' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

For reference you can do this manually (although it creates a bad visualization):

<!-- snippet: ApplyTo_manual -->
<a id='snippet-ApplyTo_manual'></a>
```cs
prefix.JoinTo(values).Process(t => t.Item2.Select(i => Tuple.Create(t.Item1, i)));
```
<sup><a href='/Refactoring.Pipelines.Test/PipelineTests.cs#L242-L244' title='Snippet source file'>snippet source</a> | <a href='#snippet-ApplyTo_manual' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

However, if you use the `ApplyTo()` method, you will end up with a much better-rendered result.

![GraphViz of AppliedPipe](/Refactoring.Pipelines.Test/_approvals/PipelineTests.ApplyTo.approved.svg)

## ConcatWith(list)

Sometimes you will want a special type of Join which takes two enumerables of the same element type and concatenates them into a list.

For example, if you had:

<!-- snippet: ConcatWith_inputs -->
<a id='snippet-ConcatWith_inputs'></a>
```cs
var concat = new List<int> {1, 2};
var with = new[] {3, 4};
```
<sup><a href='/Refactoring.Pipelines.Test/PipelineTests.cs#L265-L268' title='Snippet source file'>snippet source</a> | <a href='#snippet-ConcatWith_inputs' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

You can combine them to produce the following output:

<!-- snippet: ConcatWith_outputs -->
<a id='snippet-ConcatWith_outputs'></a>
```cs
var result = "[1, 2, 3, 4]";
```
<sup><a href='/Refactoring.Pipelines.Test/PipelineTests.cs#L270-L272' title='Snippet source file'>snippet source</a> | <a href='#snippet-ConcatWith_outputs' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

For reference you can do this manually (although it creates a bad visualization):

<!-- snippet: ConcatWith_manual -->
<a id='snippet-ConcatWith_manual'></a>
```cs
part1.JoinTo(part2).Process(t => t.Item1.Concat(t.Item2).ToList());
```
<sup><a href='/Refactoring.Pipelines.Test/PipelineTests.cs#L275-L277' title='Snippet source file'>snippet source</a> | <a href='#snippet-ConcatWith_manual' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

However, if you use the `ConcatWith()` method, you will end up with a much better-rendered result.

![GraphViz of AppliedPipe](/Refactoring.Pipelines.Test/_approvals/PipelineTests.Concat.approved.svg)

## Processing a Lambda

the `FunctionPipe` uses the name of the function, but if you pass in a lambda it will format that nicely. For example:

<!-- snippet: process_lambda -->
<a id='snippet-process_lambda'></a>
```cs
var input = new InputPipe<int>("input");
input.Process(p => p.ToString());
```
<sup><a href='/Refactoring.Pipelines.Test/PipelineTests.cs#L303-L306' title='Snippet source file'>snippet source</a> | <a href='#snippet-process_lambda' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

will look like:

![GraphViz of Lambda](/Refactoring.Pipelines.Test/_approvals/PipelineTests.Lambda.approved.svg)
