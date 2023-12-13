namespace Solid.Serviсes;

internal class NotificationService : INotificationService
{
    public void InfoToLog(string text) => Info(text, ConsoleColor.Green);
    public void WarringToLog(string text) => Info(text, ConsoleColor.Yellow);
    public void ErrorToLog(string text) => Info(text, ConsoleColor.Red);

    private void Info(string text, ConsoleColor foregroundColor)
    {
        if(String.IsNullOrWhiteSpace(text)) return;

        Console.ForegroundColor = foregroundColor;
        Console.WriteLine(text);
        Console.ResetColor();
    }
}
