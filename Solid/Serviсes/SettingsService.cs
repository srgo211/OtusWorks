

namespace Solid.Serviсes;

internal class SettingsService : ISettingsServiсe
{
    public ISettingsModel GetSettingsServiсe()
    {
        int attemptsCount = 3; int minNumber = 1; int maxNumber = 11;
        var settings = new SettingsModel(attemptsCount, minNumber, maxNumber);

        settings.AproveNumber = NumberGeneratorService.GenerateRandomNumber(minNumber, maxNumber);

        return settings;
    }
}
