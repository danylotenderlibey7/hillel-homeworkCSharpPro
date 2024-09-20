using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1
{
    public class Calculator_Advanced : Calculator
    {
        public double Power(double power, double a)
        {
            return Math.Pow(a, power);
        }
        public double Sqrt(double a)
        {
            if (a < 0)
            {
                throw new ArgumentException("The square root of a negative number cannot be taken");
            }
            else
            {
                return Math.Sqrt(a);
            }
        }
    }
}
