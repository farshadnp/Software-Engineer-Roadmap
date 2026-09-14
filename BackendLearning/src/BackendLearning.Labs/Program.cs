using BackendLearning.Labs.Week01.Day02.NullableReferences;
using BackendLearning.Labs.Week01.Day02.EntityAndPersistence;
using BackendLearning.Labs.Week01.Day02.ResourceCleanup;

// Select the example here, or type its number in the console.
if (args.Contains("--verify"))
{
    Example01_NonNullableParameter.Run();
    Example02_NullEmptyWhitespace.Run();
    Example03_GuardedTitle.Run();
    Example04_RenameInvariant.Run();
    Example05_CompositeUniqueness.Run();
    await Example06_CatchAndRethrow.RunAsync();
    Example07_FinallyAndUsing.Run();
    Console.WriteLine("ALL CHECKS PASSED");
    return;
}

Console.WriteLine("Week 1 / Day 2 - C# backend foundations");
Console.WriteLine("1: string parameter, compiler warning, runtime exception");
Console.WriteLine("2: null versus empty versus whitespace");
Console.WriteLine("3: safe validation and normalization");
Console.WriteLine("4: rename and entity invariants");
Console.WriteLine("5: uniqueness per user (simulation)");
Console.WriteLine("6: failed save, swallowed exception and rethrow");
Console.WriteLine("7: finally, return and using / Dispose");
Console.Write("Choose 1-7: ");
switch (Console.ReadLine())
{
    case "1": Example01_NonNullableParameter.Run(); break;
    case "2": Example02_NullEmptyWhitespace.Run(); break;
    case "3": Example03_GuardedTitle.Run(); break;
    case "4": Example04_RenameInvariant.Run(); break;
    case "5": Example05_CompositeUniqueness.Run(); break;
    case "6": await Example06_CatchAndRethrow.RunAsync(); break;
    case "7": Example07_FinallyAndUsing.Run(); break;
    default: Console.WriteLine("Run again and choose 1-7."); break;
}

Console.WriteLine("Press Enter to finish.");
Console.ReadLine();
