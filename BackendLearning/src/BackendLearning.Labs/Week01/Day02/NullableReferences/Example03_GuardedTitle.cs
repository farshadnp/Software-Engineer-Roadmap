namespace BackendLearning.Labs.Week01.Day02.NullableReferences;

public static class Example03_GuardedTitle
{
    public static void Run()
    {
        foreach (string? title in new string?[] { null, "", "   ", new string('a', 101) })
        {
            try
            {
                NormalizeTitle(title);
                throw new InvalidOperationException("Invalid title was accepted.");
            }
            catch (NoteValidationException ex)
            {
                Console.WriteLine($"Controlled rejection: {ex.Message}");
            }
        }

        string result = NormalizeTitle("  My note  ");
        if (result != "My note") throw new InvalidOperationException("Trim failed.");
        string boundary = NormalizeTitle("  " + new string('a', 100) + "  ");
        if (boundary.Length != 100) throw new InvalidOperationException("Boundary failed.");
        Console.WriteLine($"Accepted: [{result}]; 100-character boundary accepted.");
    }

    public static string NormalizeTitle(string? title)
    {
        // BREAKPOINT: inspect null, empty and whitespace inputs here.
        if (string.IsNullOrWhiteSpace(title))
            throw new NoteValidationException("Title cannot be empty.");

        // The guard above lets the compiler know title is non-null here.
        string normalizedTitle = title.Trim();
        if (normalizedTitle.Length > 100)
            throw new NoteValidationException("Title cannot exceed 100 characters.");

        return normalizedTitle;
    }
}

public sealed class NoteValidationException(string message) : Exception(message);
