namespace BackendLearning.Labs.Week01.Day02.EntityAndPersistence;

public static class Example04_RenameInvariant
{
    public static void Run()
    {
        var note = Note.Create(10, "Fereydoon");
        try
        {
            note.Rename("   ");
            throw new InvalidOperationException("Expected validation failure.");
        }
        catch (NoteValidationException)
        {
            Check.That(note.Title == "Fereydoon" && note.NormalizedTitle == "FEREYDOON",
                "Invalid rename preserves both values.");
        }

        note.Rename(" Farzad ");
        Check.That(note.Title == "Farzad" && note.NormalizedTitle == "FARZAD",
            "Valid rename updates both values; no database is involved.");
    }
}

internal static class Check
{
    public static void That(bool condition, string description)
    {
        if (!condition) throw new InvalidOperationException(description);
        Console.WriteLine("PASS: " + description);
    }
}
