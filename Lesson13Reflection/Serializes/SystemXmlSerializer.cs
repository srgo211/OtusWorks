using System.Xml.Serialization;

namespace Lesson13Reflection.Serializes;

internal class SystemXmlSerializer : ISerializationManager
{
    public string SerializeToString(object classData)
    {
        if (classData is null) return default;
        Type type = classData.GetType();
        XmlSerializer serializer = new XmlSerializer(type);

        using (StringWriter writer = new StringWriter())
        {
            serializer.Serialize(writer, classData);
            string personXml = writer.ToString();
            return personXml;
        }

    }

    public T DeserializeToObject<T>(string serialized) where T : class
    {
        if (String.IsNullOrWhiteSpace(serialized)) return default;
       
        XmlSerializer serializer = new XmlSerializer(typeof(T));

        using (StringReader reader = new StringReader(serialized))
        {
            
            try
            {
                return serializer.Deserialize(reader) as T;
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Ошибка десериализации: {ex.Message}");
                return default; 
            }
        }

    }
}