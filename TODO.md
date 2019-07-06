- Verify(ForEach)
- Async
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
- Convience functions for Tuples on Process & InputPipes
- extract base class for Joined/Applied/Concatted pipes
- verify file exists in DotReporter
- multiple input pipe convience functions
- handle lambdas
- var pipeline = result.GetInputsAndOutputs();

- Properties
-  Tuple { ... } 
- DotReporter doesn't open
- progress reporting hooks

