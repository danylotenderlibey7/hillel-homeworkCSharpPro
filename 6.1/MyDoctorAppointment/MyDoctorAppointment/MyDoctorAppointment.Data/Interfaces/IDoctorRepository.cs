using MyDoctorAppointment.Domain.Entities;
using System.Collections.Generic;

namespace MyDoctorAppointment.Data.Interfaces
{
    public interface IDoctorRepository
    {
        Doctor Create(Doctor doctor);
        IEnumerable<Doctor> GetAll();
        Doctor? GetById(int id);
        bool Delete(int id);
        Doctor Update(int id, Doctor doctor);
    }
}
