using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1
{
    public class Calculator
    {

        public double Add(double first_number, double second_number)
        {
            return first_number + second_number;
        }
        public double Subtract(double first_number, double second_number)
        { 
            return first_number - second_number;
        }
        public double Multiply(double first_number, double second_number)
        {
            return first_number * second_number;
        }
        public double Divide(double first_number, double second_number)
        {
            if (second_number == 0)
            {
                throw new DivideByZeroException("It's forbidden to divide by zero");
            }
            else
            {
                return first_number / second_number;
            }

        }
    }
}
