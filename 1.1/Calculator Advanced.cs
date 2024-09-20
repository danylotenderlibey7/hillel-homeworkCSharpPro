using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1
{
    public class Calculator_Advanced : Calculator
    {
        public double Power(double a, double power)
        {
            return Math.Pow(a, power);
        }
        public double Sqrt(double a)
        {
            if (a < 0)
            {
                throw new ArgumentOutOfRangeException("The square root of a negative number cannot be taken");
            }
            else
            {
                return Math.Sqrt(a);
            }
        }
        public double Sin(double a)
        { 
            return Math.Sin(a);
        }
        public double Cos(double a)
        {
            return Math.Cos(a);
        }
        public double Tan(double a)
        {
            return Math.Tan(a);
        }
    }
}
