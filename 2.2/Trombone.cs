using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2
{
    public class Trombone : WindInstrument
    {
        public Trombone() : base("Trombone", "A brass instrument with a movable slide.", "Originated in the 16th century in Europe.")
        { }

        public override void Sound()
        {
            Console.WriteLine("The trombone sounds: 'Boom!'");
        }
    }
}
