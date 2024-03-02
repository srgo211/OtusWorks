namespace Lesson23ParallelFileReader;

public class log
{
    public static void Info(string text, ConsoleColor color = ConsoleColor.White)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ResetColor();
    }
    public static async Task InfoAsync(string text, ConsoleColor color = ConsoleColor.White)
    {
        Console.ForegroundColor = color;
        await Console.Out.WriteLineAsync(text);
        Console.ResetColor();        
    }
}
