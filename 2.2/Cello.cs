using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2
{
    public class Cello : StringInstrument
    {
        public Cello() : base("Cello", "A large string instrument played while seated", "Originated in Italy in the 16th century")
        { }

        public override void Sound()
        {
            Console.WriteLine("The cello sounds: 'Goom!'");
        }
    }
}
