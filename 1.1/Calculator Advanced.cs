using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1
{
    public class Calculator_Advanced : Calculator
    {
        public double Power(double first_number, double power)
        {
            return Math.Pow(first_number, power);
        }
        public double Sqrt(double first_number)
        {
            if (first_number < 0)
            {
                throw new ArgumentOutOfRangeException("The square root of a negative number cannot be taken");
            }
            else
            {
                return Math.Sqrt(first_number);
            }
        }
        public double Sin(double first_number)
        { 
            return Math.Sin(first_number);
        }
        public double Cos(double first_number)
        {
            return Math.Cos(first_number);
        }
        public double Tan(double first_number)
        {
            return Math.Tan(first_number);
        }
    }
}
