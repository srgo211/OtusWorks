namespace Solid.Interfaces;

public interface ISettingsServise
{
    /// <summary>Колличество попыток</summary>
    int AttemptsCount  { get; set; }

    /// <summary>Мин число </summary>
    int MinNumber { get; set; }

    /// <summary>Макс число </summary>
    int MaxNumber { get; set; }
  
}
