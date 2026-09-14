namespace BackendLearning.Labs.Week01.Day02.EntityAndPersistence;

public sealed class Note
{
    public Guid Id { get; } = Guid.NewGuid();
    public int UserId { get; }
    public string Title { get; private set; } = "";
    public string NormalizedTitle { get; private set; } = "";

    private Note(int userId, string? title)
    {
        UserId = userId;
        Rename(title);
    }

    public static Note Create(int userId, string? title) => new(userId, title);

    public void Rename(string? title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new NoteValidationException("Title cannot be empty.");

        var validTitle = title.Trim();
        if (validTitle.Length > 100)
            throw new NoteValidationException("Title cannot exceed 100 characters.");

        var normalizedTitle = validTitle.ToUpperInvariant();
        // BREAKPOINT: validation is complete before either assignment.
        Title = validTitle;
        NormalizedTitle = normalizedTitle;
    }
}

public sealed class NoteValidationException(string message) : Exception(message);
public sealed class NoteConflictException(string message) : Exception(message);
