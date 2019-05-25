<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->
**Contents**

- [Joining pipes](#joining-pipes)

<!-- END doctoc generated TOC please keep comment here to allow auto update -->

## Joining pipes

When you have two inputs that are needed for the next piece of functionality, you need a `JoinedPipe`. 

`JoinedPipe`s produce a `Tuple` of two inputs.

Note: If you are using `JoinedPipe` you need to call `Verify()` with the join.

snippet: joined_pipeline

will produce:

![GraphViz of Pipeline](/Pipelines.Test/PipelineTests.JoinInputs.approved.dot.svg)
