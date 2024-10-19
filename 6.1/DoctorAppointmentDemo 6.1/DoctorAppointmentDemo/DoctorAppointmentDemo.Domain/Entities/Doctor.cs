using System.Xml.Serialization;
using MyDoctorAppointment.Domain.Enums;

namespace MyDoctorAppointment.Domain.Entities
{
    [XmlRoot("Doctor")] // Укажите корневой элемент
    public class Doctor : UserBase
    {
        [XmlElement("DoctorType")] // Укажите элемент для перечисления
        public DoctorTypes DoctorType { get; set; }

        [XmlElement("Experience")]
        public byte Experience { get; set; }

        [XmlElement("Salary")]
        public decimal Salary { get; set; }

        [XmlElement("Name")] // Укажите элементы для имени и фамилии
        public string Name { get; set; }

        [XmlElement("Surname")]
        public string Surname { get; set; }
    }
}
