using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Domain.Enums;
using MyDoctorAppointment.Domain.ViewModels;

namespace MyDoctorAppointment.Service.Extensions
{
    public static class Mapper
    {
        public static DoctorViewModel ConvertTo(this Doctor doctor)
        {
            if (doctor == null)
                return null;

            string doctorType;

            switch (doctor.DoctorType)
            {
                case DoctorTypes.Dentist:
                    doctorType = "Dentist";
                    break;
                case DoctorTypes.Dermatologist:
                    doctorType = "Dermatologist";
                    break;
                case DoctorTypes.FamilyDoctor:
                    doctorType = "FamilyDoctor";
                    break;
                case DoctorTypes.Paramedic:
                    doctorType = "Paramedic";
                    break;
                default:
                    doctorType = "Unknown";
                    break;
            }

            return new DoctorViewModel()
            {
                Name = doctor.Name,
                Surname = doctor.Surname,
                Phone = doctor.Phone,
                Email = doctor.Email,
                DoctorType = doctorType,
                Experience = doctor.Experience,
                Salary = doctor.Salary
            };
        }
        public static PatientViewModel ConvertTo(this Patient patient)
        {
            if (patient == null)
                return null;

            return new PatientViewModel
            {
                Name = patient.Name,
                Surname = patient.Surname,
                IllnestType = patient.IllnestType.ToString(),
                Address = patient.Address,
                AdditionalInfo = patient.AdditionalInfo 
            };
        }
        /*public static AppointmentViewModel ConvertTo(this Appointment appointment)
        {
            if (appointment == null)
                return null;

            return new AppointmentViewModel
            {
                Id = appointment.Id, 
                PatientName = appointment.Patient?.Name + " " + appointment.Patient?.Surname,
                DoctorName = appointment.Doctor?.Name + " " + appointment.Doctor?.Surname,
                DateTimeFrom = appointment.DateTimeFrom,
                DateTimeTo = appointment.DateTimeTo,
                Description = appointment.Description,
                Status = appointment.Status 
            };
        }*/
    }
}
