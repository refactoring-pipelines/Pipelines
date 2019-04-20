- ApplyTo
- Concat
- Multiple Inputs
- Nuget packages
	- Pipes
	- Approvals.Pipes (may contain graph)
- docs
- Async
- sequencing for implicit dependencies through state
	var a = A();
	var b = B(a); 
	var c = C(a); // is it important that C comes *after* B?
	var d = D(b, c);