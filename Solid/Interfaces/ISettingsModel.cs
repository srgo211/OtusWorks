namespace Solid.Interfaces;

public interface ISettingsModel
{

    /// <summary>Колличество попыток</summary>
    int AttemptsCount { get; set; }

    /// <summary>Мин число </summary>
    int MinNumber { get; set; }

    /// <summary>Макс число </summary>
    int MaxNumber { get; set; }

    /// <summary>Правильный номер </summary>
    int AproveNumber { get; set; }
}