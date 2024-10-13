using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._1
{
    public class Store : IDisposable
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }

        public Store(string name, string address, string type)
        {
            Name = name;
            Address = address;
            Type = type;
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Address: {Address}");
            Console.WriteLine($"Type: {Type}");
            Console.WriteLine();
        }
        ~Store()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Destructor called for store: {Name}");
            Console.ResetColor();
        }
        public void Dispose()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Disposing store: {Name}");
            Console.ResetColor();
            GC.SuppressFinalize(this);
        }
    }
}
