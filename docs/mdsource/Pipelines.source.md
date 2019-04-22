## Creating Pipelines

### Basic pipelines

snippet:  basic_pipeline

will produce the same results as 

snippet: basic_code_line

Dispite the complexity add of this code, this pattern has some advantages in refactoring to async 
as well has advantages in monitoring. It also has advantages in testing and visualization.
For example the pipeline can reder itself as the following dot file (Graphviz)

![GraphViz of Pipeline](/Pipelines.Test/PipelineTests.BasicPipelineTest.approved.dot.svg)