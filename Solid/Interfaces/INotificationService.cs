namespace Solid.Interfaces;

public interface INotificationService
{
    void InfoToLog(string text);
    void WarringToLog(string text);
    void ErrorToLog(string text);
}