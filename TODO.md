# End of last session 
Experimented with Tuples / Join / Labels

# Next
- kata w/ pipelines
	- fizzbuzz
	- tennis / bowling
	- game of life
- unroll tuples: `Tuple<Tuple<,>,>` -> `Tuple<,,>`

# Experiments:
	- try VS Git UI
	- safe guarding
		- visualize the Verify API
		- create subproject for interfaces
		- write a test for what level the Verify objects can take
	* Open a external Mindmup board 

# Ideas
- tuples as (a, b, c)
- label edges, including edge to nothing
- code converter (Roslyn or Mono.Cecil)
- Propagate Exceptions through a pipeline
- GetInputs<>.AndOutputs<>() when finding an end-point that's not of a type we expect could have said "looking for an InputPipe<> but found an unconnected pipe of type InputPipe<>" (would have been async)

- Async
	- test sometimes fails, missing a value (flaky)
	- TEST: pipeline that writes to side effect
	- Make async, see it break (order has changed)
	- Refactor to use comp. instead of inheritance. Maybe a sending mechanism.
	- Tests for JoinedWith, ConcatWith, ProcessForEach, ApplyTo
- extract base class for Joined/Applied/Concatted pipes
- var pipeline = result.GetInputsAndOutputs();
	- move to own project
- Repeat Arlo's exercise
- sequencing for implicit dependencies through state
	```
		var a = A();
		var b = B(a); 
		var c = C(a); // is it important that C comes *after* B?
		var d = D(b, c);
	```
- Learn about Apache Beam
- Join/Apply when one side never provides an input - does the system stall?
- multiple input pipe convenience functions
- Convenience functions for Tuples on Process & InputPipes
- blog the PB&J example in code vs. pipelines to show differences and advantages
	- these are equivalent executable programs
- Properties
-  Tuple { ... } 
- progress reporting hooks
- add `Task SendAsync()` that executes the entire pipeline asynchronously (on both sync and async pipelines)
- C# tuple without Join():
```
   (peanutButterPipe, jellyPipe).ProcessFunction(CreateSandwich)
```
- refactoring: split "pipeline" from "graph"
- refactoring: implement pipelines as pipelines

# Safeguarding / automation
- ensure imported .svg really exist at that name
- verify .svg are up to date in CI
- generate NuGet packages in CI
- Run same tests against both Sync and Async APIs
- Create CI for PipelinesExercise (use GitHub Actions to learn about them)
- ensure the library code invoked in async pipelines is thread-safe
  - tried HSR Parallel Checker (a free VS Extension) that promises it detects thread-unsafe code, however did not detect any problems on the solution (before the thread-safe fix was applied)
  - PostSharp Threading - costs money, need to investigate if it's useful
- ensure/help the users write thread-safe code when using async pipelines
- dependabot config file 
- automate deployment in CI pipeline

# Retro
- start with 
	- questions/things I didn't understand
	- what happened today
