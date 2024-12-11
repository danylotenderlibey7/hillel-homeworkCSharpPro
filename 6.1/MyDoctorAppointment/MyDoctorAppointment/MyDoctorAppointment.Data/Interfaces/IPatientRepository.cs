using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Data.Interfaces
{
    public interface IPatientRepository
    {
        Patient Create(Patient patient);
        IEnumerable<Patient> GetAll();
        Patient? GetById(int id);
        bool Delete(int id);
        Patient Update(int id, Patient patient);
    }
}
