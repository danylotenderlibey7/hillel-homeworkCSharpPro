using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Data.Repositories;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.Interfaces;
using System.Collections.Generic;

namespace MyDoctorAppointment.Service.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }
        public Appointment Create(Appointment appointment)
        {
            return _appointmentRepository.Create(appointment);
        }

        public Appointment? GetAppointmentById(int id)
        {
            return _appointmentRepository.GetById(id);
        }

        public IEnumerable<Appointment> GetAllAppointments()
        {
            return _appointmentRepository.GetAll();
        }

        public Appointment UpdateAppointment(int id, Appointment appointment)
        {
            return _appointmentRepository.Update(id, appointment);
        }

        public bool DeleteAppointment(int id)
        {
            return _appointmentRepository.Delete(id);
        }

        public IEnumerable<Appointment> GetAppointmentsByPatientId(int patientId)
        {
            return _appointmentRepository.GetByPatientId(patientId);
        }

        public IEnumerable<Appointment> GetAppointmentsByDoctorId(int doctorId)
        {
            return _appointmentRepository.GetByDoctorId(doctorId);
        }

    }
}
