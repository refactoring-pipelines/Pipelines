<!--
GENERATED FILE - DO NOT EDIT
This file was generated by [MarkdownSnippets](https://github.com/SimonCropp/MarkdownSnippets).
Source File: /docs/mdsource/PipelineActions.source.md
To change this file edit the source file and then run MarkdownSnippets.
-->
<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->
**Contents**

- [Joining pipes](#joining-pipes)

<!-- END doctoc generated TOC please keep comment here to allow auto update -->

## Joining pipes

When you have two inputs that are needed for the next piece of functionality, you need a `JoinedPipe`. 

`JoinedPipe`s produce a `Tuple` of two inputs.

Note: If you are using `JoinedPipe` you need to call `Verify()` with the join.

<!-- snippet: joined_pipeline -->
```cs
var input1 = new InputPipe<long>("value1");
var input2 = new InputPipe<long>("value2");
var join = input1.JoinTo(input2);
```
<sup>[snippet source](/Pipelines.Test/PipelineTests.cs#L90-L94)</sup>
<!-- endsnippet -->

will produce:

![GraphViz of Pipeline](/Pipelines.Test/PipelineTests.JoinInputs.approved.dot.svg)