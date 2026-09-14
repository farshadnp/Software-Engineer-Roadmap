# 02 - Resource cleanup

Run console option 7. Set breakpoints in the finally block and DemoResource.Dispose.

1. ReturnThroughFinally: A -> B: finally -> Caller: 10.
2. Successful work: Opened -> Work -> After using declaration -> Disposed -> Caller: success.
3. Failed work: Opened -> Work -> Disposed -> Caller: caught failure.

IDisposable is a contract with a Dispose method. Resource owners implement cleanup
there. This demo only records events; a file owner could release a file handle.
The using declaration arranges disposal when its enclosing scope exits, including
return and exception paths. It does not catch the work exception or roll back data.
Cleanup is deterministic during ordinary managed control flow; forced process
termination is not covered. If acquisition fails, there is no acquired object to dispose.

Contrast: using (var resource = ...) { ... } ends the lifetime at the closing brace;
using var resource = ... ends it at the end of the enclosing scope.

Review: why is 'After using declaration' before 'Disposed' in the success case?
