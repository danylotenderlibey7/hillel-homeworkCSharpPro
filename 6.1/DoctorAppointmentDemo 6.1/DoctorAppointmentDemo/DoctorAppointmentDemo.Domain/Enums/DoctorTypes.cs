using System.Xml.Serialization;
namespace MyDoctorAppointment.Domain.Enums
{
    public enum DoctorTypes
    {
        [XmlEnum(Name = "Dentist")]
        Dentist = 1,

        [XmlEnum(Name = "Dermatologist")]
        Dermatologist = 2,

        [XmlEnum(Name = "Family Doctor")]
        FamilyDoctor = 3,

        [XmlEnum(Name = "Paramedic")]
        Paramedic = 4
    }

}
