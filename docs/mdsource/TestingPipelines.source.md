# Testing Pipelines and Generating Output

toc

When verifying a pipeline graph, you can generate either a GraphViz diagram or an image in PNG or SVG format. This is done using [ApprovalTests](https://github.com/approvals/approvaltests.net).

## GraphViz

If you want to verify a `Pipeline`, you can call `PipelineApprovals.Verify()`:

snippet: graphviz_approval

Which produces the following approved file:

snippet: _approvals/PipelineTests.SplitInput.approved.txt


Usually we open these in Visual Studio Code with a plugin. The advantage of these files is that they diff easily and render nicely.

## PNG/SVG

If you want to create the images, you can do that automatically as well, using the following:

snippet: graphviz_png_approval

which produces the following approved file:

![GraphViz of Pipeline in PNG format](/Refactoring.Pipelines.Test/_approvals/PipelineTests.TestPng.approved.png)