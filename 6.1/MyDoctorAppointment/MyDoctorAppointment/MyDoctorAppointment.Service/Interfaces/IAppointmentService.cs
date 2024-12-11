using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Service.Interfaces
{
    public interface IAppointmentService
    {
        Appointment Create(Appointment appointment);
        Appointment? GetAppointmentById(int id);
        IEnumerable<Appointment> GetAllAppointments();
        Appointment UpdateAppointment(int id, Appointment appointment);
        bool DeleteAppointment(int id);
        IEnumerable<Appointment> GetAppointmentsByPatientId(int patientId);
        IEnumerable<Appointment> GetAppointmentsByDoctorId(int doctorId);
    }
}
