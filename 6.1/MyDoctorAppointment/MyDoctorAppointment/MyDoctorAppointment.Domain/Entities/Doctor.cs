using MyDoctorAppointment.Domain.Enums;
using System.Xml.Serialization;

namespace MyDoctorAppointment.Domain.Entities
{
    [XmlRoot("Doctor")]
    public class Doctor : UserBase
    {
        [XmlElement("DoctorType")]
        public DoctorTypes DoctorType { get; set; }

        [XmlElement("Experience")]
        public byte Experience { get; set; }

        [XmlElement("Salary")]
        public decimal Salary { get; set; }
    }
}
