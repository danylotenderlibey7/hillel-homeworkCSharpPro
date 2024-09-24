using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2
{
    public class Violin : StringInstrument
    {
        public Violin() : base("Violin", "Played with a bow", "Has a long history dating back over 500 years")
        { }
        public override void Sound()
        {
            Console.WriteLine("The violin sounds: 'Tri-li-li!'");
        }
    }
}
