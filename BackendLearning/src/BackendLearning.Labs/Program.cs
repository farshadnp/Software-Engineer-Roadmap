using BackendLearning.Labs.Week01.Day02.NullableReferences;

// Select the example here, or type its number in the console.
if (args.Contains("--verify"))
{
    Example01_NonNullableParameter.Run();
    Example02_NullEmptyWhitespace.Run();
    Example03_GuardedTitle.Run();
    Console.WriteLine("ALL CHECKS PASSED");
    return;
}

Console.WriteLine("Week 1 / Day 2 - Nullable reference types");
Console.WriteLine("1: string parameter, compiler warning, runtime exception");
Console.WriteLine("2: null versus empty versus whitespace");
Console.WriteLine("3: safe validation and normalization");
Console.Write("Choose 1, 2 or 3: ");
switch (Console.ReadLine())
{
    case "1": Example01_NonNullableParameter.Run(); break;
    case "2": Example02_NullEmptyWhitespace.Run(); break;
    case "3": Example03_GuardedTitle.Run(); break;
    default: Console.WriteLine("Run again and choose 1, 2 or 3."); break;
}

Console.WriteLine("Press Enter to finish.");
Console.ReadLine();
