using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2
{
    public abstract class MusicalInstrument
    {
        private string _name;
        private string _description;
        private string _history;

        public MusicalInstrument(string name, string description, string history)
        {
            _name = name;
            _description = description;
            _history = history;
        }

        public void Show() => Console.WriteLine($"Name: {_name}");
        public void Desc() => Console.WriteLine($"Description: {_description}");
        public void History() => Console.WriteLine($"History: {_history}");
        public abstract void Sound();
    }
}
