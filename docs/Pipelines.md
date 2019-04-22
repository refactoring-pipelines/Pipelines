<!--
This file was generate by MarkdownSnippets.
Source File: /docs/mdsource/Pipelines.source.md
To change this file edit the source file and then re-run the generation using either the dotnet global tool (https://github.com/SimonCropp/MarkdownSnippets#markdownsnippetstool) or using the api (https://github.com/SimonCropp/MarkdownSnippets#running-as-a-unit-test).
-->
## Creating Pipelines

### Basic pipelines

Let's say you have the following line of code:

<!-- snippet: basic_code_line -->
```cs
var _result = long.Parse(age);
```
<sup>[snippet source](/Pipelines.Test/PipelineTests.cs#L19-L21)</sup>
<!-- endsnippet -->

You can refactor this to pipelines with the following

<!-- snippet: basic_pipeline -->
```cs
var inputPipe = new InputPipe<string>("age");
var parsePipe = inputPipe.Process(long.Parse);
var collector = parsePipe.Collect();

inputPipe.Send("42");
var result = collector.SingleResult;
```
<sup>[snippet source](/Pipelines.Test/PipelineTests.cs#L25-L32)</sup>
<!-- endsnippet -->

These will produce the same results.

### But Why?!?!

Dispite the complexity add of this code, this pattern has some advantages in refactoring to async 
as well has advantages in monitoring. It also has advantages in testing and visualization.
For example the pipeline can reder itself as the following dot file (Graphviz)

![GraphViz of Pipeline](/Pipelines.Test/PipelineTests.BasicPipelineTest.approved.dot.svg)
