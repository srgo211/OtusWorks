

using System.Text.Json;

namespace Solid.Serviсes;

internal class SettingsServiceFromFile : ISettingsServiсe
{
    public ISettingsModel GetSettingsServiсe()
    {
        // Считываем JSON из файла
        string jsonString = File.ReadAllText("AppSettings.json");

        // Десериализуем JSON в объект
        SettingsModel? settings = JsonSerializer.Deserialize<SettingsModel>(jsonString);

        settings.AproveNumber = NumberGeneratorService.GenerateRandomNumber(settings.MinNumber, settings.MaxNumber);

        return settings;
    }
}