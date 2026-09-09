using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

await using var connection = new SqliteConnection("Data Source=:memory:");
await connection.OpenAsync();

var options = new DbContextOptionsBuilder<DemoDbContext>()
    .UseSqlite(connection)
    .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
    .EnableSensitiveDataLogging()
    .Options;

await using var db = new DemoDbContext(options);
await db.Database.EnsureCreatedAsync();

var note = new Note { Title = "EF generated values demo" };
var originalReference = note;

db.Notes.Add(note);

Console.WriteLine($"BEFORE: Id={note.Id}, CreatedAt={note.CreatedAt:O}, State={db.Entry(note).State}");

int affected = await db.SaveChangesAsync();

Console.WriteLine($"AFTER:  Id={note.Id}, CreatedAt={note.CreatedAt:O}, State={db.Entry(note).State}");
Console.WriteLine($"SAME REFERENCE: {ReferenceEquals(originalReference, note)}; AFFECTED={affected}");

public sealed class Note
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public DateTime CreatedAt { get; private set; }
}

public sealed class DemoDbContext(DbContextOptions<DemoDbContext> options)
    : DbContext(options)
{
    public DbSet<Note> Notes => Set<Note>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Note>()
            .Property(note => note.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();
    }
}
