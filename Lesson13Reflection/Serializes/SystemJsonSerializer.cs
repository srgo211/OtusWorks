using System.Text.Json;

namespace Lesson13Reflection.Serializes;

internal class SystemJsonSerializer : ISerializationManager
{
    public string SerializerToString(object classData)
    {
        if (classData is null) return String.Empty;

        string json = JsonSerializer.Serialize(classData);
        return json;
    }

    public T DeserializeToObject<T>(string serialized) where T : class
    {
        if (String.IsNullOrWhiteSpace(serialized)) return default;
        T model = JsonSerializer.Deserialize<T>(serialized);
        return model;
    }
}