namespace Solid.Serviсes;

internal class SettingsService : ISettingsServise
{    
    public SettingsService(int attemptsCount, int minNumber, int maxNumber)
    {
        AttemptsCount = attemptsCount;
        MinNumber = minNumber;  
        MaxNumber = maxNumber;
    }

    public int AttemptsCount { get; set; }
    public int MinNumber { get; set; }
    public int MaxNumber { get; set; }
}
