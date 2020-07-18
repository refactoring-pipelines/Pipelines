# Pipeline Actions

toc

## Joining pipes

When you have two inputs that are needed for the next piece of functionality, you need a `JoinedPipe`.

`JoinedPipe`s produce a `Tuple` of two inputs.

Note: If you are using `JoinedPipe` you need to call `Verify()` with the join.

snippet: joined_pipeline

will produce:

![GraphViz of JoinedPipe](/Refactoring.Pipelines.Test/_approvals/PipelineTests.JoinInputsSample.approved.svg)

## ApplyTo(list)

Sometimes you will want a special type of Join which takes one thing and applies it to each element of a separate list.

For example, if you had:

snippet: ApplyTo_inputs

You can combine them to produce the following output:

snippet: ApplyTo_outputs

For reference you can do this manually (although it creates a bad visualization):

snippet: ApplyTo_manual

However, if you use the `ApplyTo()` method, you will end up with a much better-rendered result.

![GraphViz of AppliedPipe](/Refactoring.Pipelines.Test/_approvals/PipelineTests.ApplyTo.approved.svg)

## ConcatWith(list)

Sometimes you will want a special type of Join which takes two enumerables of the same element type and concatenates them into a list.

For example, if you had:

snippet: ConcatWith_inputs

You can combine them to produce the following output:

snippet: ConcatWith_outputs

For reference you can do this manually (although it creates a bad visualization):

snippet: ConcatWith_manual

However, if you use the `ConcatWith()` method, you will end up with a much better-rendered result.

![GraphViz of AppliedPipe](/Refactoring.Pipelines.Test/_approvals/PipelineTests.Concat.approved.svg)

## Processing a Lambda

the `FunctionPipe` uses the name of the function, but if you pass in a lambda it will format that nicely. For example:

snippet: process_lambda

will look like:

![GraphViz of Lambda](/Refactoring.Pipelines.Test/PipelineTests.Lambda.approved.dot.svg)