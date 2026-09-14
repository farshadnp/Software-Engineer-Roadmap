namespace BackendLearning.Labs.Week01.Day02.NullableReferences;

public static class Example02_NullEmptyWhitespace
{
    public static void Run()
    {
        string?[] inputs = [null, "", "   ", "  My   Note  "];
        int?[] expectedLengths = [null, 0, 0, 9];

        for (int i = 0; i < inputs.Length; i++)
        {
            string? title = inputs[i];
            if (title is null)
            {
                Console.WriteLine("null: no string instance; Length/Trim would throw.");
                continue;
            }

            string trimmed = title.Trim();
            Console.WriteLine($"Input=[{title}], Length={title.Length}, Trimmed=[{trimmed}], TrimmedLength={trimmed.Length}");
            if (trimmed.Length != expectedLengths[i])
                throw new InvalidOperationException("Unexpected trimmed length.");
        }
    }
}
