namespace MyDoctorAppointment.Domain.Entities
{
    public enum AppointmentStatus
    {
        Scheduled=1,
        Completed,
        Cancelled,
        NoShow
    }
    public class Appointment : Auditable
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime DateTimeFrom { get; set; }
        public DateTime DateTimeTo { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
