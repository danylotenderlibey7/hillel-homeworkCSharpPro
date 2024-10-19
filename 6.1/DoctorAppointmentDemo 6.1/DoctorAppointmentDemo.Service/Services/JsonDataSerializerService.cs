using DoctorAppointmentDemo.Service.Interfaces;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

public class JsonDataSerializerService : ISerializationService
{
    public void Serialize<T>(List<T> items, string path)
    {
        var jsonString = JsonSerializer.Serialize(items);
        File.WriteAllText(path, jsonString);
    }

    public List<T> Deserialize<T>(string path)
    {
        var jsonString = File.ReadAllText(path);
        return JsonSerializer.Deserialize<List<T>>(jsonString);
    }
}