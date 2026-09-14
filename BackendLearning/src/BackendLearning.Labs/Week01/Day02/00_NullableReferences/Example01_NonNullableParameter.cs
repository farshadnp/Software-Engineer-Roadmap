namespace BackendLearning.Labs.Week01.Day02.NullableReferences;

public static class Example01_NonNullableParameter
{
    public static void Run()
    {
        Console.WriteLine("EXAMPLE 1: string is a compiler contract, not a runtime guard.");
        Console.WriteLine($"Valid title length: {ReadLength("Note")}");

        try
        {
            // INTENTIONAL CS8625 compiler warning. No ! operator is needed
            // to pass null at runtime when warnings are not treated as errors.
            ReadLength(null);
            throw new InvalidOperationException("Expected NullReferenceException was not thrown.");
        }
        catch (NullReferenceException)
        {
            Console.WriteLine("Caught: NullReferenceException at title.Length");
        }

        string? nullableTitle = null;
        try
        {
            // ! suppresses the warning. It does not replace null with a string.
            ReadLength(nullableTitle!);
            throw new InvalidOperationException("Expected NullReferenceException was not thrown.");
        }
        catch (NullReferenceException)
        {
            Console.WriteLine("Using !: still NullReferenceException at title.Length");
        }
    }

    private static int ReadLength(string title)
    {
        // BREAKPOINT HERE: inspect title for the valid and the null calls.
        return title.Length;
    }
}
