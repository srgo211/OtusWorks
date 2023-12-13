using System;

namespace Solid.Serviсes;

internal class SettingsServiceRandom : ISettingsServiсe
{
    public ISettingsModel GetSettingsServiсe()
    {
        const int minNum = 1;
        Random rnd = new Random();
        int attemptsCount = rnd.Next(minNum, 6); 
        int maxNumber     = rnd.Next(minNum+1, 11);
        var settings      = new SettingsModel(attemptsCount, minNum, maxNumber);

        settings.AproveNumber = NumberGeneratorService.GenerateRandomNumber(minNum, maxNumber);

        return settings;
    }
}
