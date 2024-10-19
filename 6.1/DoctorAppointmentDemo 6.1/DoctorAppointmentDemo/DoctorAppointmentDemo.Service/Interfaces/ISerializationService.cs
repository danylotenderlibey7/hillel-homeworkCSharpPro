using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentDemo.Service.Interfaces
{
    public interface ISerializationService
    {
        void Serialize<T>(List<T> items, string path);
        List<T> Deserialize<T>(string path);
    }
}
