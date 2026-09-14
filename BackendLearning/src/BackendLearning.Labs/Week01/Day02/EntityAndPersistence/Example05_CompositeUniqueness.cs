namespace BackendLearning.Labs.Week01.Day02.EntityAndPersistence;

public static class Example05_CompositeUniqueness
{
    public static void Run()
    {
        var keys = new HashSet<(int UserId, string NormalizedTitle)>();
        var first = Note.Create(10, " Shopping ");
        var otherUser = Note.Create(20, "shopping");
        var duplicate = Note.Create(10, "SHOPPING");
        Check.That(keys.Add((first.UserId, first.NormalizedTitle)), "First title accepted.");
        Check.That(keys.Add((otherUser.UserId, otherUser.NormalizedTitle)), "Other user accepted.");
        Check.That(!keys.Add((duplicate.UserId, duplicate.NormalizedTitle)), "Same user and normalized title rejected.");
        Console.WriteLine("This HashSet illustrates the key only. Production needs a database unique constraint.");
        Console.WriteLine("RowVersion detects concurrent updates to an existing row; it does not enforce title uniqueness.");
    }
}
