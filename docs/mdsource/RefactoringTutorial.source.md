<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->
**Contents**

- [Refactoring To Async Tutorial](#refactoring-to-async-tutorial)
  - [Prep](#prep)
  - [Step by Step](#step-by-step)
  - [Notes](#notes)
    - [1. Call the method in question from a test](#1-call-the-method-in-question-from-a-test)
    - [2. Take the 1st thing to move to async and create an `InputPipe` of it's parameters directly above it.](#2-take-the-1st-thing-to-move-to-async-and-create-an-inputpipe-of-its-parameters-directly-above-it)
    - [3. Place a ApprovalTests to get insight into the pipeline.](#3-place-a-approvaltests-to-get-insight-into-the-pipeline)
    - [4. Inspect result in VsCode](#4-inspect-result-in-vscode)
    - [5. Add a process as a delegate](#5-add-a-process-as-a-delegate)
    - [6. Add a collector, and send input in](#6-add-a-collector-and-send-input-in)
    - [7. Repeat](#7-repeat)

<!-- END doctoc generated TOC please keep comment here to allow auto update -->

# Refactoring To Async Tutorial

## Prep

* Download the [sample exercise](https://github.com/ondjuric/PipelinesExercise) 
* Install the VsCode and the plugin [Graphviz (dot) language support for Visual Studio Code](https://marketplace.visualstudio.com/items?itemName=joaompinto.vscode-graphviz) by João Pinto 
CTRL-SHIFT-V to preview a `.dot` file as a rendered graph.



## Step by Step

## Notes

 1. All pipeline setup code occurs at the top of the method.  
 2. Then the approvals call  
 3. Then the sending thru the pipeline

### 1. Call the method in question from a test

Simply call the method you wish to refactor from a test.
Don't think of this as a traditonal unit test. Think of it more as a specialized `main()` method

### 2. Take the 1st thing to move to async and create an `InputPipe` of it's parameters directly above it.

``` cs
 var startingPointInput = new InputPipe<InputType>("InputName");
 ```
 
 ### 3. Place a ApprovalTests to get insight into the pipeline.
 
 Place this right in the middle of the production code you want to refactor. It is a temporary step.
 
 ``` cs 
  PipelineApprovals.Verify(startingPointInput);
 ```
 
 With a DotReporter (on the test)
 
 ``` cs 
 [UseReporter(typeof(DotReporter))]
 ```

### 4. Inspect result in VsCode

### 5. Add a process as a delegate

If the code isn't in a method, extract it to one first

``` cs
 var methodCallPipe = startingPoint.Process(TheMethodCall)
```

Do this above the approvals.Verify(). Run it again for feedback

### 6. Add a collector, and send input in

``` cs
 var methodCallCollector = methodCallPipe.Collect();
 startingPoint.Send(firstParameter);
 var variable = methodCallCollector.SingleResult;
```

### 7. Repeat

