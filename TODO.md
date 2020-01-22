
- update approvals
- Roslyn code converter
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
- Exceptions
- Learn about Apache Beam
- Join/Apply when one side never provides an input - does the system stall?
- multiple input pipe convenience functions
- Convenience functions for Tuples on Process & InputPipes
- verify file exists in DotReporter
- blog the PB&J example in code vs. pipelines to show differences and advantages
	- these are equivalent executable programs

- Properties
-  Tuple { ... } 
- progress reporting hooks
- Automate generating .SVG for docs - https://github.com/timothy-shields/graphviz

# Safeguarding / automation
- run_markdown as part of CI
- ensure imported .svg really exist at that name
- verify .svg are up to date in CI
- generate NuGet packages in CI
- https://aka.ms/deprecateIconUrl
