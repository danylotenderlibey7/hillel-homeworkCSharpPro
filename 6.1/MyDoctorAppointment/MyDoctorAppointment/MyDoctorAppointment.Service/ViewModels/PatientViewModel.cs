using System.Xml.Serialization;

[XmlRoot("PatientViewModel")]
public class PatientViewModel
{
    [XmlElement("Name")]
    public string Name { get; set; } = string.Empty;

    [XmlElement("Surname")]
    public string Surname { get; set; } = string.Empty;

    [XmlElement("IllnestType")]
    public string IllnestType { get; set; } = string.Empty;

    [XmlElement("AdditionalInfo")]
    public string? AdditionalInfo { get; set; }

    [XmlElement("Address")]
    public string? Address { get; set; }
}