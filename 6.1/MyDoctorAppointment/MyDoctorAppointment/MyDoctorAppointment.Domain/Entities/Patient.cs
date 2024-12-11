using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Domain.Enums;
using System.Xml.Serialization;

[XmlRoot("Patient")]
public class Patient : UserBase
{
    [XmlElement("IllnestType")]
    public IllnestTypes IllnestType { get; set; }

    [XmlElement("AdditionalInfo")]
    public string? AdditionalInfo { get; set; }

    [XmlElement("Address")]
    public string? Address { get; set; }
}