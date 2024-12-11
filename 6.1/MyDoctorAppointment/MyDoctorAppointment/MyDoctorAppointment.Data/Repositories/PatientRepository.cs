using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Data.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        private readonly ISerializationService _serializationService;

        public override string Path { get; set; }
        public override int LastId { get; set; }

        public PatientRepository(string appSettings, ISerializationService serializationService) : base(appSettings, serializationService)
        {
            _serializationService = serializationService;

            var result = ReadFromAppSettings(); 
            Path = result.Database.Patients.Path; 
            LastId = result.Database.Patients.LastId;
        }

        public override void ShowInfo(Patient source)
        {
            Console.WriteLine($"Patient: {source.Name} {source.Surname}, Address: {source.Address}, Illness Type: {source.IllnestType}");
        }

        protected override void SaveLastId()
        {
            var result = ReadFromAppSettings();
            result.Database.Patients.LastId = LastId;

            _serializationService.Serialize(AppSettings, result);
        }
    }
}
