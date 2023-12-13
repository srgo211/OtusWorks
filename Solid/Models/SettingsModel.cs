namespace Solid.Models;

internal class SettingsModel : ISettingsModel
{
    public SettingsModel(int attemptsCount, int minNumber, int maxNumber)
    {
        AttemptsCount = attemptsCount;
        MinNumber = minNumber;
        MaxNumber = maxNumber;
    }
    public int AttemptsCount { get; set; }
    public int MinNumber { get; set; }
    public int MaxNumber { get; set; }
    public int AproveNumber { get; set; }
}
