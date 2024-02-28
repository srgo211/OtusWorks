namespace Lesson13Reflection.Interfaces;

public interface ISerializationManager
{

    /// <summary>Сериализация данных в строку</summary>
    string SerializeToString(object classData);

    /// <summary>Десериализация данных</summary>
    T DeserializeToObject<T>(string serialized) where T : new();
}

