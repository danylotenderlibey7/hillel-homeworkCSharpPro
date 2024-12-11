using System.Xml.Serialization;

[XmlRoot("DoctorViewModel")]
public class DoctorViewModel
{
    [XmlElement("Name")]
    public string Name { get; set; } = string.Empty;

    [XmlElement("Surname")]
    public string Surname { get; set; } = string.Empty;

    [XmlElement("Phone")]
    public string? Phone { get; set; }

    [XmlElement("Email")]
    public string? Email { get; set; }

    [XmlElement("DoctorType")]
    public string? DoctorType { get; set; }

    [XmlElement("Experience")]
    public byte Experience { get; set; }

    [XmlElement("Salary")]
    public decimal Salary { get; set; }
}