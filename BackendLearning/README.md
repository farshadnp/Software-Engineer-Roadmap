# Backend Learning Labs

Open `BackendLearning.sln` in Visual Studio with .NET 10 SDK support.
Set `BackendLearning.Labs` as the startup project if needed.
Run with Ctrl+F5 for output, or F5 for debugging; choose 1-6.

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
The verification path runs all six examples and fails on unexpected results.
Mentor execution does not count as learner mastery. Record learner observations separately.

## Entity and persistence lessons (examples 4-6)

Open Week01/Day02/EntityAndPersistence in Solution Explorer.

- Example04_RenameInvariant: invalid rename preserves state; valid rename updates both titles.
- Example05_CompositeUniqueness: the composite key is (UserId, NormalizedTitle).
- Example06_CatchAndRethrow: compare swallowing an exception with rethrowing it.
- Note.cs: shared creation/rename rules and custom exception declarations.
- SnapshotNoteRepository.cs: independent stored snapshots for the failure demonstration.

For example 6, set breakpoints on `if (rethrow) throw;` and `return note;`.
Run option 6. The first scenario reaches return after a failed save; the second
propagates the conflict to the caller. Both leave the changed object in memory.
Inspect `note.Title` and `repository.Read(note.Id).Title` in RunScenarioAsync.

These simulations do not test database constraints, EF tracking, or concurrent requests.
A real database needs a unique constraint on the composite key. Infrastructure
classifies a known constraint failure; the API handler chooses HTTP 409.
No HTTP handler is implemented in this console lesson.

Review: why does rethrow prevent apparent success without reverting the in-memory title?
