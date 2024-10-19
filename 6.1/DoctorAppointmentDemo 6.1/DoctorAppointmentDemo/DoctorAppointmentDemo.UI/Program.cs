using DoctorAppointmentDemo.Service.Interfaces;
using MyDoctorAppointment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;

namespace MyDoctorAppointment
{
    public class DoctorAppointment
    {
        private readonly string _path;
        private readonly ISerializationService _serializationService;
        private List<Doctor> _doctors;

        public DoctorAppointment(string path, ISerializationService serializationService)
        {
            _path = path;
            _serializationService = serializationService;
            _doctors = new List<Doctor>();
            LoadDoctors(); // Загружаем врачей при создании
        }

        public void Menu()
        {
            Console.WriteLine("Select data format:");
            Console.WriteLine("1. XML");
            Console.WriteLine("2. JSON");

            string? choice = Console.ReadLine();
            DoctorAppointment? doctorAppointment = null;

            while (true)
            {
                if (choice.Equals("1"))
                {
                    doctorAppointment = new DoctorAppointment(Constants.XmlAppSettingsPath, new XmlDataSerializerService());
                    break;
                }
                else if (choice.Equals("2"))
                {
                    doctorAppointment = new DoctorAppointment(Constants.JsonAppSettingsPath, new JsonDataSerializerService());
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong choice. Please select 1 or 2.");
                    choice = Console.ReadLine();
                }
            }

            doctorAppointment?.ShowMenu();
        }

        private void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("Doctor Appointment Menu:");
                Console.WriteLine("1. Add Doctor");
                Console.WriteLine("2. View Doctors");
                Console.WriteLine("3. Save and Exit");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddDoctor();
                        break;
                    case "2":
                        ViewDoctors();
                        break;
                    case "3":
                        SaveDoctors();
                        Console.WriteLine("Data saved. Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        private void AddDoctor()
        {
            Console.Write("Enter doctor's name: ");
            string? name = Console.ReadLine();

            Console.Write("Enter doctor's surname: ");
            string? surname = Console.ReadLine();

            // Валидация данных
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname))
            {
                Console.WriteLine("Name and surname cannot be empty. Doctor not added.");
                return;
            }

            _doctors.Add(new Doctor { Name = name, Surname = surname });
            Console.WriteLine("Doctor added.");
        }

        private void ViewDoctors()
        {
            if (_doctors.Count == 0)
            {
                Console.WriteLine("No doctors available.");
                return;
            }

            foreach (var doctor in _doctors)
            {
                Console.WriteLine($"Name: {doctor.Name} {doctor.Surname}");
            }
        }

        private void SaveDoctors()
        {
            _serializationService.Serialize(_doctors, _path);
        }

        private void LoadDoctors()
        {
            if (File.Exists(_path))
            {
                _doctors = _serializationService.Deserialize<Doctor>(_path);
            }
            else
            {
                Console.WriteLine($"No existing file found at {_path}. Starting with an empty list.");
                _doctors = new List<Doctor>();
            }
        }
    }

    public static class Constants
    {
        public const string XmlAppSettingsPath = "C:\\DoctorAppointmentDemo\\DoctorAppointmentDemo.Data\\Configuration\\example.xml";
        public const string JsonAppSettingsPath = "C:\\DoctorAppointmentDemo\\DoctorAppointmentDemo.Data\\Configuration\\example.json";
    }

    public static class Program
    {
        public static void Main()
        {
            var doctorAppointment = new DoctorAppointment(Constants.JsonAppSettingsPath, new JsonDataSerializerService());
            doctorAppointment.Menu();
        }
    }
}
