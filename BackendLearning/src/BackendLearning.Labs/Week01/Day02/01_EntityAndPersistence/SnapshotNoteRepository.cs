namespace BackendLearning.Labs.Week01.Day02.EntityAndPersistence;

// Teaching double only: no EF, SQL, transactions or real concurrency.
// Immutable snapshots prevent accidental persistence through shared references.
public sealed record StoredNote(Guid Id, int UserId, string Title, string NormalizedTitle);

public sealed class SnapshotNoteRepository
{
    private readonly Dictionary<Guid, StoredNote> rows = new();

    public Task SaveChangesAsync(Note note, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        if (rows.Values.Any(row => row.Id != note.Id && row.UserId == note.UserId
            && row.NormalizedTitle == note.NormalizedTitle))
        {
            // Real infrastructure must identify the specific provider constraint.
            return Task.FromException(new NoteConflictException("Title already exists for this user."));
        }

        rows[note.Id] = new(note.Id, note.UserId, note.Title, note.NormalizedTitle);
        return Task.CompletedTask;
    }

    public StoredNote Read(Guid id) => rows[id];
}
