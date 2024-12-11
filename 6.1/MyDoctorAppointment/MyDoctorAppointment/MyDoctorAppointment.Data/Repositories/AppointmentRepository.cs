using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Data.Repositories
{
    public class AppointmentRepository //: IAppointmentRepository
    {
        private readonly string _appSettings;
        private readonly ISerializationService _serializationService;
        private readonly List<Appointment> _appointments = new List<Appointment>();

        public AppointmentRepository(string appSettings, ISerializationService serializationService)
        {
            _appSettings = appSettings;
            _serializationService = serializationService;
        }

        public Appointment Create(Appointment appointment)
        {
            _appointments.Add(appointment);
            return appointment;
        }

        public Appointment? GetById(int id)
        {
            return _appointments.FirstOrDefault(a => a.Id == id);
        }

        public Appointment Update(int id, Appointment appointment)
        {
            var existing = GetById(id);
            if (existing != null)
            {
                /*existing.Patient = appointment.Patient;
                existing.Doctor = appointment.Doctor;*/
                existing.DateTimeFrom = appointment.DateTimeFrom;
                existing.DateTimeTo = appointment.DateTimeTo;
                existing.Description = appointment.Description;
                existing.Status = appointment.Status;
            }
            return existing;
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _appointments;
        }

        public bool Delete(int id)
        {
            var appointment = GetById(id);
            if (appointment != null)
            {
                _appointments.Remove(appointment);
                return true;
            }
            return false;
        }

        public void ShowInfo(Appointment appointment)
        {
           
            Console.WriteLine($"Appointment ID: {appointment.Id}, Date: {appointment.DateTimeFrom} to {appointment.DateTimeTo}, Status: {appointment.Status}");
        }

        /*public IEnumerable<Appointment> GetByPatientId(int patientId)
        {
            return _appointments.Where(a => a.Patient?.Id == patientId);
        }*/

        /*public IEnumerable<Appointment> GetByDoctorId(int doctorId)
        {
            return _appointments.Where(a => a.Doctor?.Id == doctorId);
        }*/
    }
}
