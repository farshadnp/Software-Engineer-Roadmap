# Backend Learning Labs

Open `BackendLearning.sln` in Visual Studio with .NET 10 SDK support.
Set `BackendLearning.Labs` as the startup project if needed.
Run with Ctrl+F5 for output, or F5 for debugging; choose 1, 2 or 3.

These are mentor-written examples, not copied source code from the book.
Week01/Day02 contains C# prerequisites used throughout the backend roadmap.
Future examples will follow WeekXX/DayXX/Topic/ExampleNN_Name.cs.

## Start with Example01_NonNullableParameter.cs

1. Set a breakpoint at `return title.Length;`.
2. Run example 1. The first call receives "Note". Inspect `title` and step over.
3. The second call receives null although the parameter is `string`.
4. Observe CS8625 in the build warnings: this project deliberately allows warnings.
5. When `title.Length` executes with null, NullReferenceException is thrown.
6. The example catches the exception so the teaching application can continue.
7. The third call uses `!`; the compiler warning disappears but the runtime failure remains.

To stop at the throw even though the exception is caught, open Exception Settings
and enable break on thrown System.NullReferenceException.

## Other examples

- Example02: compare null, empty, whitespace and internal spaces.
- Example03: put a runtime guard before Trim and enforce length after Trim.

Review question: why does changing `string` to `string?` on ReadLength
not fix its runtime behavior by itself? Which check actually protects it?

## Verification

From this directory:

```powershell
dotnet run --project src/BackendLearning.Labs -- --verify
```

The intentional CS8625 warning is part of example 1, not a production convention.
The verification path runs all three examples and fails on unexpected results.
Mentor execution does not count as learner mastery. Record learner observations separately.
