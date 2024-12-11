using MyDoctorAppointment.Domain.Entities;
using System.Collections.Generic;

namespace MyDoctorAppointment.Data.Interfaces
{
    public interface IAppointmentRepository
    {
        Appointment Create(Appointment appointment);
        Appointment? GetById(int id);
        Appointment Update(int id, Appointment appointment);
        IEnumerable<Appointment> GetAll();
        bool Delete(int id);
        IEnumerable<Appointment> GetByPatientId(int patientId);
        IEnumerable<Appointment> GetByDoctorId(int doctorId);
    }
}
