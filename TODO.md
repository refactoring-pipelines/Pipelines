- Async
- sequencing for implicit dependencies through state
	var a = A();
	var b = B(a); 
	var c = C(a); // is it important that C comes *after* B?
	var d = D(b, c);
- Exceptions
- Learn about Apache Beam
- Join/Apply when one side never provides an input - does the system stall?
- `List` of things display better names (List`1 vs. List<int>)
- extract base class for Joined/Applied/Concatted pipes
- verify file exists in DotReporter