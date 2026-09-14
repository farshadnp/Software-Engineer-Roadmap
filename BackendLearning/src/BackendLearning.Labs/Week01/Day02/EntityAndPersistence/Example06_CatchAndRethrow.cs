namespace BackendLearning.Labs.Week01.Day02.EntityAndPersistence;

public static class Example06_CatchAndRethrow
{
    public static async Task RunAsync()
    {
        await RunScenarioAsync(rethrow: false);
        await RunScenarioAsync(rethrow: true);
    }

    private static async Task RunScenarioAsync(bool rethrow)
    {
        var repository = new SnapshotNoteRepository();
        var note = Note.Create(10, "Fereydoon");
        await repository.SaveChangesAsync(note);
        await repository.SaveChangesAsync(Note.Create(10, "Farzad"));

        var returnedNormally = false;
        var callerCaughtConflict = false;
        try
        {
            var result = await RenameAsync(note, repository, rethrow);
            returnedNormally = true;
            Console.WriteLine($"Caller received apparent success: {result.Title}");
        }
        catch (NoteConflictException)
        {
            callerCaughtConflict = true;
            Console.WriteLine("Caller received conflict; an API handler could map this to 409.");
        }

        Check.That(returnedNormally == !rethrow && callerCaughtConflict == rethrow,
            $"Control flow is correct for rethrow={rethrow}.");
        Check.That(note.Title == "Farzad" && repository.Read(note.Id).Title == "Fereydoon",
            "Memory changed; persisted snapshot stayed unchanged. Exception did not undo Rename.");
    }

    private static async Task<Note> RenameAsync(
        Note note, SnapshotNoteRepository repository, bool rethrow)
    {
        note.Rename("Farzad");
        try
        {
            await repository.SaveChangesAsync(note);
        }
        catch (NoteConflictException)
        {
            Console.WriteLine("Service caught the conflict.");
            // BREAKPOINT: compare continuing with throwing.
            if (rethrow) throw;
        }

        // BREAKPOINT: only reached when catch swallows the exception.
        return note;
    }
}
