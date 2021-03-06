# Refactoring To Async Tutorial

<!-- toc -->
## Contents

  * [Prep](#prep)
  * [Step by Step](#step-by-step)
  * [Notes](#notes)
    * [Template to copy into your code to guide you through the refactoring](#template-to-copy-into-your-code-to-guide-you-through-the-refactoring)
    * [1. Call the method in question from a test](#1-call-the-method-in-question-from-a-test)
    * [2. Take the 1st thing to move to async and create an `InputPipe` of it's parameters directly above it.](#2-take-the-1st-thing-to-move-to-async-and-create-an-inputpipe-of-its-parameters-directly-above-it)
    * [3. Place a ApprovalTests to get insight into the pipeline.](#3-place-a-approvaltests-to-get-insight-into-the-pipeline)
    * [4. Inspect result in VsCode](#4-inspect-result-in-vscode)
    * [5. Add a process as a delegate](#5-add-a-process-as-a-delegate)
    * [6. Add a collector and send input in](#6-add-a-collector-and-send-input-in)
    * [7. Process and Collect the next step in the pipeline](#7-process-and-collect-the-next-step-in-the-pipeline)
    * [8. Delete any newly-dead code](#8-delete-any-newly-dead-code)
    * [9. Repeat until all code is converted](#9-repeat-until-all-code-is-converted)
    * [10. Use `GetInputs<>` to collect all the inputs and outputs in a single object:](#10-use-getinputs-to-collect-all-the-inputs-and-outputs-in-a-single-object)
    * [10. Extract a `CreatePipe()` function](#10-extract-a-createpipe-function)
    * [11. Move the `PipelineApprovals.Verify()` call into a unit test](#11-move-the-pipelineapprovalsverify-call-into-a-unit-test)
  * [Handling multiple parameters](#handling-multiple-parameters)<!-- endToc -->


## Prep

* Download the [sample exercise](https://github.com/refactoring-pipelines/PipelinesExercise) 
* Install the VsCode and the plugin [Graphviz (dot) language support for Visual Studio Code](https://marketplace.visualstudio.com/items?itemName=joaompinto.vscode-graphviz) by João Pinto
CTRL-SHIFT-V to preview a `.dot` file as a rendered graph.


## Step by Step

## Notes

Pipeline-based functions have the following stucture:

 1. All pipeline setup
 2. Then `PipelineApprovals.Verify()`
 3. Then send input through the pipeline and extract the result.

### Template to copy into your code to guide you through the refactoring

```cs
// Set up Pipeline objects
// `PipelineApprovals.Verify()`
// Send input through pipeline
// Original code
```
### 1. Call the method in question from a test

Call the method you wish to refactor from a test. Don't think of this as a traditional unit test. Think of it more as a specialized `main()` method

### 2. Take the 1st thing to move to async and create an `InputPipe` of it's parameters directly above it.

``` cs
var inputNamePipe = new InputPipe<InputType>("InputName");
```

### 3. Place a ApprovalTests to get insight into the pipeline.

Place this right in the middle of the production code you want to refactor. It is a temporary step.

``` cs
PipelineApprovals.Verify(inputNamePipe);
```

With a DotReporter (on the test)

``` cs
[UseReporter(typeof(DotReporter))]
```

### 4. Inspect result in VsCode

### 5. Add a process as a delegate

If the code isn't in a method, use a lambda instead

``` cs
 var methodCallPipe = startingPoint.ProcessFunction(TheMethodCall);
 var methodCallPipe = startingPoint.Process(x => x * 2);
```

Do this above the `PipelineApprovals.Verify()`. Run it again for feedback.

### 6. Add a collector and send input in

``` cs
 var methodCallCollector = methodCallPipe.Collect();
 inputNamePipe.Send(firstParameter);
 var variable = methodCallCollector.SingleResult;
```

### 7. Process and Collect the next step in the pipeline

### 8. Delete any newly-dead code

Previously you were using `.Collect()` to pull out values from intermediate steps, but as they become unnecessary you can delete them. ReSharper is good for finding dead code.

### 9. Repeat until all code is converted

### 10. Use `GetInputs<>` to collect all the inputs and outputs in a single object:

``` cs
var inputsAndOutputs = bestSandwichCollector.GetInputs<ZipCode>().AndOutputs<Sandwich>().AsTuple();
inputsAndOutputs.Send(zipCode);
inputsAndOutputs.Outputs...
```
### 10. Extract a `CreatePipe()` function

### 11. Move the `PipelineApprovals.Verify()` call into a unit test

``` cs
var pipe = SimpleCalls.CreatePipe();
PipelineApprovals.Verify(pipe.Input1);
```

## Handling multiple parameters

Every function has a single input and a single output. To use multiple input parameters, you'll have to join them into `Tuple`s. If this requires new inputs, you'll need multiple `InputPipe`s.
