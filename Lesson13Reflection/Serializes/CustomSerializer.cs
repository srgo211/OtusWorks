using System.Text;

namespace Lesson13Reflection.Serializes;

public class CustomSerializer : ISerializationManager
{
    const char delimiterFild = ';';
    const char delimiterVal  = '=';

    public string SerializeToString(object obj)
    {
        if (obj is null) return default;
        Type type = obj.GetType();
        StringBuilder sb = new StringBuilder();

        // Сериализация свойств
        PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        foreach (var property in properties)
        {
            string value= property.GetValue(obj)?.ToString();
            sb.Append($"{property.Name}{delimiterVal}{value}{delimiterFild}");
        }

        return sb.ToString();
    }

    public T DeserializeToObject<T>(string serialized) where T : new()
    {
        // Создание экземпляра объекта с использованием Activator
        T obj = Activator.CreateInstance<T>();
        Type type = typeof(T);
        Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

        // Разбор строки
        string[] lines = serialized.Split(delimiterFild);
        foreach (var line in lines)
        {
            string[] parts = line.Split(delimiterVal);
            if (parts.Length == 2)
            {
                string key = parts[0].Trim();
                string value = parts[1].Trim();
                keyValuePairs[key] = value;
            }
        }

        // Присвоение значений полям и свойствам
        foreach (var kvp in keyValuePairs)
        {
            PropertyInfo property = type.GetProperty(kvp.Key, BindingFlags.Public | BindingFlags.Instance);
            if (property != null && property.CanWrite)
            {
                object value = Convert.ChangeType(kvp.Value, property.PropertyType);
                property.SetValue(obj, value);
            }

            FieldInfo field = type.GetField(kvp.Key, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (field != null)
            {
                object value = Convert.ChangeType(kvp.Value, field.FieldType);
                field.SetValue(obj, value);
            }
        }

        return obj;
    }

}
