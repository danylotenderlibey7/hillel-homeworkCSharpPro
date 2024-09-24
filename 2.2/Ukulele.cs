using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2
{
    public class Ukulele : StringInstrument
    {
        public Ukulele() : base("Ukulele", "A small string instrument", "Appeared in Hawaii in the 19th century")
        { }

        public override void Sound()
        {
            Console.WriteLine("The ukulele sounds: 'Tin-tan!'");
        }
    }
}
