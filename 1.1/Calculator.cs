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

        public double Add(double a, double b)
        {
            return a + b;
        }
        public double Subtract(double a, double b)
        { 
            return a - b;
        }
        public double Multiply(double a, double b)
        {
            return a * b;
        }
        public double Divide(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("It's forbidden to divide by zero");
            }
            else
            {
                return a / b;
            }

        }
    }
}
