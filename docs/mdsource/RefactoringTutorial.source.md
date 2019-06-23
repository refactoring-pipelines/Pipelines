# Refactoring To Async Tutorial

## Step by Step

### 1. Call the method in question from a test

Simply call the method you wish to refactor from a test.
Don't think of this as a traditonal unit test. Think of it more as a specialized `main()` method

### 2. Take the 1st thing that fails and create an `InputPipe` of it's parameters

``` cs
 var startingPoint = new InputPipe<InputType>("InputNamme");
 ```
 
 ### 3. Place a ApprovalTests to get insight into the pipeline.
 
 Place this right in the middle of the production code you want to refactor. It is a temporary step.
 
 ``` cs 
  PipelineApprovals.verify(startingPoint);
 ```
 
 With a DotReporter
 
 ``` cs 
 [UseReporter(typeof(DotReporter))]
 ```

### 4. Add a process as a delegate

``` cs
 var methodCallPipe = startingPoint.process(TheMethodCall)
```

### 4. Add a collector, and send input in

``` cs
 var methodCallCollector = methodCallPipe.Collect();
 startingPoint.Send(firstParameter);
 var variable = methodCallCollector.SingleOrDefault;
```

### 5. Repeat

