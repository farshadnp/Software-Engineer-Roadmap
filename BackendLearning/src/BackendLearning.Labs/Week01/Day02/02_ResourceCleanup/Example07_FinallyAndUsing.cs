namespace BackendLearning.Labs.Week01.Day02.ResourceCleanup;

public static class Example07_FinallyAndUsing
{
    public static void Run()
    {
        var events = new List<string>();
        var result = ReturnThroughFinally(events);
        Record(events, $"Caller: {result}");
        Verify(events, "A", "B: finally", "Caller: 10");

        foreach (var fail in new[] { false, true })
        {
            events.Clear();
            Console.WriteLine($"--- using, fail={fail} ---");
            try
            {
                UseResource(events, fail);
                Record(events, "Caller: success");
            }
            catch (InvalidOperationException)
            {
                Record(events, "Caller: caught failure");
            }

            if (fail)
                Verify(events, "Opened", "Work", "Disposed", "Caller: caught failure");
            else
                Verify(events, "Opened", "Work", "After using declaration", "Disposed", "Caller: success");
        }
    }

    private static int ReturnThroughFinally(List<string> events)
    {
        try
        {
            Record(events, "A");
            return 10; // Determine return value, then execute finally before returning.
        }
        finally
        {
            Record(events, "B: finally"); // BREAKPOINT
        }
    }

    private static void UseResource(List<string> events, bool fail)
    {
        // A using declaration disposes at the end of its enclosing scope.
        using var resource = new DemoResource(events);
        Record(events, "Work");
        if (fail) throw new InvalidOperationException("Simulated work failure.");
        Record(events, "After using declaration");
    } // Dispose runs here on normal exit, or while unwinding after the throw.

    private sealed class DemoResource : IDisposable
    {
        private readonly List<string> events;
        public DemoResource(List<string> events)
        {
            this.events = events;
            Record(events, "Opened");
        }

        public void Dispose()
        {
            // BREAKPOINT: observe the caller after cleanup.
            // This demonstration prints only; it does not open a real file or database.
            Record(events, "Disposed");
        }
    }

    private static void Record(List<string> events, string message)
    {
        events.Add(message);
        Console.WriteLine(message);
    }

    private static void Verify(List<string> actual, params string[] expected)
    {
        if (!actual.SequenceEqual(expected))
            throw new Exception("Unexpected execution / cleanup order.");
        Console.WriteLine("PASS: execution and cleanup order.");
    }
}
