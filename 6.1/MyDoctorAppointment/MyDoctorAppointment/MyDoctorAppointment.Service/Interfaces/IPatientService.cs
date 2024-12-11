using MyDoctorAppointment.Domain.Entities;
using System.Collections.Generic;

namespace MyDoctorAppointment.Service.Interfaces
{
    public interface IPatientService
    {
        Patient Create(Patient patient);
        bool Delete(int id);
        Patient? Get(int id);
        IEnumerable<PatientViewModel> GetAll();
        Patient Update(int id, Patient patient);
    }
}
