using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1
{
    public class Money
    {
        private int _integerPart;
        private int _fractionalPart;

        public Money(int integerPart, int fractionalPart)
        {
            if (fractionalPart >= 100)
            {
                _integerPart = integerPart + fractionalPart / 100;
                _fractionalPart = fractionalPart % 100;
            }
            else
            {
                _integerPart = integerPart;
                _fractionalPart = fractionalPart;
            }
        }

        public int IntegerPart => _integerPart; 
        public int FractionalPart => _fractionalPart;
        public void Display()
        {
            Console.Write($"{_integerPart}.{_fractionalPart:D2}");

            Console.WriteLine();
        }
    }
}
