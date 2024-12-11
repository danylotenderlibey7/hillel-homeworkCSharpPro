using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Data.Repositories;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Domain.Enums;
using MyDoctorAppointment.Service;
using MyDoctorAppointment.Service.Interfaces;
using MyDoctorAppointment.Service.Services;
public enum EntityType
{
    Doctor = 1,
    Patient,
    Appointment,
    Exit
}

public enum ActionType
{
    Add = 1,
    Edit,
    Delete,
    View,
    Exit
}

public enum DataType
{
    XML = 1,
    JSON
}

namespace MyDoctorAppointment
{
	public class DoctorAppointment
	{
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;
        private readonly IAppointmentService _appointmentService;
        //private readonly IAppointmentRepository _appointmentRepository;

        public DoctorAppointment(string appSettings, ISerializationService serializationService)
        {
            //_appointmentRepository = new AppointmentRepository(appSettings, serializationService);
            _doctorService = new DoctorService(appSettings, serializationService);
            _patientService = new PatientService(appSettings, serializationService);
            //_appointmentService = new AppointmentService(_appointmentRepository);
        }
        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("Select entity type:");
                Console.WriteLine("1. Doctor");
                Console.WriteLine("2. Patient");
                Console.WriteLine("3. Appointment");
                Console.WriteLine("4. Exit");

                if (!Enum.TryParse(Console.ReadLine(), out EntityType entityType))
                {
                    Console.WriteLine("Invalid choice. Try again.");
                    continue;
                }

                switch (entityType)
                {
                    case EntityType.Doctor:
                        HandleDoctorActions();
                        break;

                    case EntityType.Patient:
                        HandlePatientActions();
                        break;

                    case EntityType.Appointment:
                        HandleAppointmentActions();
                        break;
                    case EntityType.Exit:
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
        private void HandleDoctorActions()
        {
            Console.WriteLine("Select action:");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Edit");
            Console.WriteLine("3. Delete");
            Console.WriteLine("4. View List");
            Console.WriteLine("5. Exit");

            if (!Enum.TryParse(Console.ReadLine(), out ActionType actionType))
            {
                Console.WriteLine("Invalid choice. Try again.");
                return;
            }

            switch (actionType)
            {
                case ActionType.Add:
                    AddDoctor();
                    break;
                case ActionType.Edit:
                    EditDoctor();
                    break;
                case ActionType.Delete:
                    DeleteDoctor();
                    break;
                case ActionType.View:
                    ViewDoctor();
                    break;
                case ActionType.Exit:
                    Console.Clear(); 
                    return; 
                default:
                    Console.WriteLine("Invalid action. Try again.");
                    break;
            }
        }
        private void AddDoctor()
        {
            Console.WriteLine("Adding new doctor:");

            Console.Write("Enter doctor's name: ");
            string name = Console.ReadLine();

            Console.Write("Enter doctor's surname: ");
            string surname = Console.ReadLine();

            Console.WriteLine("Select doctor's type:");
            foreach (var type in Enum.GetValues(typeof(Domain.Enums.DoctorTypes)))
            {
                Console.WriteLine($"{(int)type}. {type}");
            }

            Domain.Enums.DoctorTypes doctorType;
            while (!Enum.TryParse(Console.ReadLine(), out doctorType) || !Enum.IsDefined(typeof(Domain.Enums.DoctorTypes), doctorType))
            {
                Console.WriteLine("Invalid input. Please select a valid doctor type.");
            }

            var newDoctor = new Doctor
            {
                Name = name,
                Surname = surname,
                DoctorType = doctorType
            };
            
            _doctorService.Create(newDoctor);
            Console.WriteLine($"Doctor {name} {surname} added successfully.");
        }
        private void EditDoctor()
        {
            Console.WriteLine("Enter the ID of the doctor you want to edit:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID. Please enter a valid number.");
                return;
            }

            var doctorToEdit = _doctorService.Get(id);
            if (doctorToEdit == null)
            {
                Console.WriteLine("Doctor not found.");
                return;
            }

            Console.WriteLine("Editing doctor:");
            Console.WriteLine($"Current Name: {doctorToEdit.Name}");
            Console.Write("Enter new name (leave blank for no change): ");
            string newName = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(newName))
            {
                doctorToEdit.Name = newName;
            }

            Console.WriteLine($"Current Surname: {doctorToEdit.Surname}");
            Console.Write("Enter new surname (leave blank for no change): ");
            string newSurname = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(newSurname))
            {
                doctorToEdit.Surname = newSurname;
            }

            Console.WriteLine("Select new doctor type (leave blank for no change):");
            foreach (var type in Enum.GetValues(typeof(Domain.Enums.DoctorTypes)))
            {
                Console.WriteLine($"{(int)type}. {type}");
            }

            string typeInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(typeInput) && Enum.TryParse(typeInput, out Domain.Enums.DoctorTypes newDoctorType))
            {
                doctorToEdit.DoctorType = newDoctorType;
            }

            _doctorService.Update(id, doctorToEdit);
            Console.WriteLine($"Doctor {doctorToEdit.Name} {doctorToEdit.Surname} updated successfully.");
        }
        private void DeleteDoctor()

        
        {
            Console.WriteLine("Enter the ID of the doctor you want to delete:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID. Please enter a valid number.");
                return;
            }

            if (_doctorService.Delete(id))
            {
                Console.WriteLine("Doctor deleted successfully.");
            }
            else
            {
                Console.WriteLine("Doctor not found or could not be deleted.");
            }
        }
        private void ViewDoctor()
        {
            Console.WriteLine("Current doctors list:");
            var docs = _doctorService.GetAll();
            foreach (var doc in docs)
            {
                Console.WriteLine($"{doc.Name} {doc.Surname} ({doc.DoctorType})");
            }
            Console.WriteLine();
        }


        private void HandlePatientActions()

        {
            while (true) 
            {
                Console.WriteLine("Select action:");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Edit");
                Console.WriteLine("3. Delete");
                Console.WriteLine("4. View List");
                Console.WriteLine("5. Exit");

                if (!Enum.TryParse(Console.ReadLine(), out ActionType actionType))
                {
                    Console.WriteLine("Invalid choice. Try again.");
                    continue;
                }

                switch (actionType)
                {
                    case ActionType.Add:
                        AddPatient();
                        break;
                    case ActionType.Edit:
                        EditPatient();
                        break;
                    case ActionType.Delete:
                        DeletePatient();
                        break;
                    case ActionType.View:
                        ViewPatients();
                        break;
                    case ActionType.Exit:
                        Console.Clear(); 
                        return;
                    default:
                        Console.WriteLine("Invalid action. Try again.");
                        break;
                }
            }
        }
        private void AddPatient()
        {
            Console.WriteLine("Adding new patient:");

            Console.Write("Enter patient's name: ");
            string name = Console.ReadLine();

            Console.Write("Enter patient's surname: ");
            string surname = Console.ReadLine();

            Console.WriteLine("Select illness type:");
            foreach (var type in Enum.GetValues(typeof(IllnestTypes))) 
            {
                Console.WriteLine($"{(int)type}. {type}");
            }

            IllnestTypes illnessType;
            while (!Enum.TryParse(Console.ReadLine(), out illnessType) || !Enum.IsDefined(typeof(IllnestTypes), illnessType))
            {
                Console.WriteLine("Invalid input. Please select a valid illness type.");
            }

            Console.Write("Enter additional info (optional): ");
            string additionalInfo = Console.ReadLine();

            Console.Write("Enter address (optional): ");
            string address = Console.ReadLine();

            var newPatient = new Patient
            {
                Name = name,
                Surname = surname,
                IllnestType = illnessType,
                AdditionalInfo = additionalInfo,
                Address = address
            };

            _patientService.Create(newPatient); 
            Console.WriteLine($"Patient {name} {surname} added successfully.");
        }//*
        private void EditPatient()
        {
            Console.WriteLine("Enter the ID of the patient you want to edit:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID. Please enter a valid number.");
                return;
            }

            var patientToEdit = _patientService.Get(id); 
            if (patientToEdit == null)
            {
                Console.WriteLine("Patient not found.");
                return;
            }

            Console.WriteLine("Editing patient:");
            Console.WriteLine($"Current Name: {patientToEdit.Name}");
            Console.Write("Enter new name (leave blank for no change): ");
            string newName = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(newName))
            {
                patientToEdit.Name = newName;
            }

            Console.WriteLine($"Current Surname: {patientToEdit.Surname}");
            Console.Write("Enter new surname (leave blank for no change): ");
            string newSurname = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(newSurname))
            {
                patientToEdit.Surname = newSurname;
            }

            Console.WriteLine("Select new illness type (leave blank for no change):");
            foreach (var type in Enum.GetValues(typeof(IllnestTypes)))
            {
                Console.WriteLine($"{(int)type}. {type}");
            }

            string typeInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(typeInput) && Enum.TryParse(typeInput, out IllnestTypes newIllnessType))
            {
                patientToEdit.IllnestType = newIllnessType;
            }

            Console.Write("Enter new additional info (leave blank for no change): ");
            string newAdditionalInfo = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newAdditionalInfo))
            {
                patientToEdit.AdditionalInfo = newAdditionalInfo;
            }

            Console.Write("Enter new address (leave blank for no change): ");
            string newAddress = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newAddress))
            {
                patientToEdit.Address = newAddress;
            }

            _patientService.Update(id, patientToEdit); 
            Console.WriteLine($"Patient {patientToEdit.Name} {patientToEdit.Surname} updated successfully.");
        }//*
        private void DeletePatient()
        {
            Console.WriteLine("Enter the ID of the patient you want to delete:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID. Please enter a valid number.");
                return;
            }

            if (_patientService.Delete(id)) 
            {
                Console.WriteLine("Patient deleted successfully.");
            }
            else
            {
                Console.WriteLine("Patient not found or could not be deleted.");
            }
        }
        private void ViewPatients()
        {
            Console.WriteLine("Current patients list:");
            var patients = _patientService.GetAll(); 
            foreach (var patient in patients)
            {
                Console.WriteLine($"{patient.Name} {patient.Surname} (Illness Type: {patient.IllnestType})");
            }
        }


        private void HandleAppointmentActions()
        {
            while (true)
            {
                Console.WriteLine("Select action:");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Edit");
                Console.WriteLine("3. Delete");
                Console.WriteLine("4. View List");
                Console.WriteLine("5. Exit");

                if (!Enum.TryParse(Console.ReadLine(), out ActionType actionType))
                {
                    Console.WriteLine("Invalid choice. Try again.");
                    continue;
                }

                switch (actionType)
                {
                    case ActionType.Add:
                        AddAppointment();
                        break;
                    case ActionType.Edit:
                        EditAppointment();
                        break;
                    case ActionType.Delete:
                        DeleteAppointment();
                        break;
                    case ActionType.View:
                        ViewAppointments();
                        break;
                    case ActionType.Exit:
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("Invalid action. Try again.");
                        break;
                }
            }
        }
        private void AddAppointment()
        {
            /*Console.WriteLine("Adding new appointment:");

            Console.Write("Enter doctor's ID: ");
            int doctorId = int.Parse(Console.ReadLine());

            Console.Write("Enter patient's ID: ");
            int patientId = int.Parse(Console.ReadLine());

            Console.Write("Enter appointment date (yyyy-mm-dd hh:mm): ");
            DateTime appointmentDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter notes (optional): ");
            string notes = Console.ReadLine();

            var newAppointment = new Appointment
            {
                DoctorId = doctorId,               
                PatientId = patientId                     
            };

            _appointmentService.Create(newAppointment);
            Console.WriteLine("Appointment added successfully.");*/
        }
        private void EditAppointment()
        {
            /*Console.WriteLine("Enter the ID of the appointment you want to edit:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID. Please enter a valid number.");
                return;
            }

            var appointmentToEdit = _appointmentService.Get(id);
            if (appointmentToEdit == null)
            {
                Console.WriteLine("Appointment not found.");
                return;
            }

            Console.WriteLine("Editing appointment:");
            Console.WriteLine($"Current Appointment Date: {appointmentToEdit.AppointmentDate}");
            Console.Write("Enter new appointment date (leave blank for no change): ");
            string dateInput = Console.ReadLine();
            if (DateTime.TryParse(dateInput, out DateTime newAppointmentDate))
            {
                appointmentToEdit.AppointmentDate = newAppointmentDate;
            }

            Console.Write("Enter new doctor's ID (leave blank for no change): ");
            string doctorIdInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(doctorIdInput) && int.TryParse(doctorIdInput, out int newDoctorId))
            {
                appointmentToEdit.DoctorId = newDoctorId;
            }

            Console.Write("Enter new patient's ID (leave blank for no change): ");
            string patientIdInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(patientIdInput) && int.TryParse(patientIdInput, out int newPatientId))
            {
                appointmentToEdit.PatientId = newPatientId;
            }

            Console.Write("Enter new notes (leave blank for no change): ");
            string newNotes = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newNotes))
            {
                appointmentToEdit.Notes = newNotes;
            }

            _appointmentService.Update(id, appointmentToEdit);
            Console.WriteLine($"Appointment updated successfully.");*/
        }
        private void DeleteAppointment()
        {
            /*Console.WriteLine("Enter the ID of the appointment you want to delete:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID. Please enter a valid number.");
                return;
            }

            if (_appointmentService.Delete(id))
            {
                Console.WriteLine("Appointment deleted successfully.");
            }
            else
            {
                Console.WriteLine("Appointment not found or could not be deleted.");
            }*/
        }
        private void ViewAppointments()
        {
            /*Console.WriteLine("Current appointments list:");
            var appointments = _appointmentService.GetAll();
            foreach (var appointment in appointments)
            {
                Console.WriteLine($"Appointment ID: {appointment.Id}, Doctor ID: {appointment.DoctorId}, Patient ID: {appointment.PatientId}, Date: {appointment.AppointmentDate}, Notes: {appointment.Notes}");
            }*/
        }
    }

    public static class Program
	{
		public static void Main()
		{
			Console.WriteLine("Select data format:");
			Console.WriteLine("1. XML");
			Console.WriteLine("2. JSON");

            if (!Enum.TryParse(Console.ReadLine(), out DataType dataType))
            {
                Console.WriteLine("Invalid choice. Using default JSON format.");
                dataType = DataType.JSON; 
            }

            DoctorAppointment? doctorAppointment = null;

            switch (dataType)
            {
                case DataType.XML:
                    doctorAppointment = new DoctorAppointment(Constants.XmlAppSettingsPath, new XmlDataSerializerService());
                    break;
                case DataType.JSON:
                    doctorAppointment = new DoctorAppointment(Constants.JsonAppSettingsPath, new JsonDataSerializerService());
                    break;
                default:
                    Console.WriteLine("Unknown format. Exiting.");
                    return;
            }
			doctorAppointment.Menu();
		}
	}
}