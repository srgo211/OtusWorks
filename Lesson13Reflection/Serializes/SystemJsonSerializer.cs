using System.Text.Json;

namespace Lesson13Reflection.Serializes;

internal class SystemJsonSerializer : ISerializationManager
{
    public string SerializeToString(object classData)
    {
        if (classData is null) return String.Empty;

        string json = JsonSerializer.Serialize(classData);
        return json;
    }

    public T DeserializeToObject<T>(string serialized) where T : new()
    {
        if (String.IsNullOrWhiteSpace(serialized)) return new T();
        T model = JsonSerializer.Deserialize<T>(serialized);
        if(model is null) return new T();
        return model;
    }
}