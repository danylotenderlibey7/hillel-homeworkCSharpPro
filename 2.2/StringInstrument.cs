using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2
{
    public abstract class StringInstrument : MusicalInstrument
    {
        protected StringInstrument(string name, string description, string history) : base(name, description, history)
        {

        }
    }
}
