using DoctorAppointmentDemo.Service.Interfaces;
using System.IO;
using System.Xml.Serialization;

public class XmlDataSerializerService : ISerializationService
{
    public void Serialize<T>(List<T> items, string path)
    {
        var serializer = new XmlSerializer(typeof(List<T>));
        using (var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, items);
        }
    }

    public List<T> Deserialize<T>(string path)
    {
        try
        {
            var serializer = new XmlSerializer(typeof(List<T>));
            using (var stream = new FileStream(path, FileMode.Open))
            {
                return (List<T>)serializer.Deserialize(stream);
            }
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Deserialization error: {ex.Message}");
            throw; // Можно выбросить снова или обработать иначе
        }
    }

}
