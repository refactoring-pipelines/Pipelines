<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->
**Contents**

- [Joining pipes](#joining-pipes)
- [ApplyTo(list)](#applytolist)

<!-- END doctoc generated TOC please keep comment here to allow auto update -->

## Joining pipes

When you have two inputs that are needed for the next piece of functionality, you need a `JoinedPipe`. 

`JoinedPipe`s produce a `Tuple` of two inputs.

Note: If you are using `JoinedPipe` you need to call `Verify()` with the join.

snippet: joined_pipeline

will produce:

![GraphViz of JoinedPipe](/Pipelines.Test/PipelineTests.JoinInputs.approved.dot.svg)

## ApplyTo(list) 

Sometimes you will want a special type of Join which takes one thing and applies it to each element of a separate list. 

For example, if you had:

snippet: ApplyTo_inputs

You can combine them to produce the following output:

snippet: ApplyTo_outputs

For reference you can do this manually (although it creates a bad visualization):

snippet: ApplyTo_manual

However, if you use the `ApplyTo()` method, you will end up with a much better-rendered result. 

![GraphViz of AppliedPipe](/Pipelines.Test/PipelineTests.ApplyTo.approved.dot.svg)

