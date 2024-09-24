using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1
{
    internal class Product
    {
        private Money _price;
        private string _name;
        public Product(string name, int integerPart, int fractionalPart)
        {
            _name = name;
            _price = new Money(integerPart, fractionalPart);
        }
        private void AdjustPrice(int integerChange, int fractionalChange)
        {
            int newIntegerPart = _price.IntegerPart + integerChange;
            int newFractionalPart = _price.FractionalPart + fractionalChange;
            if (newFractionalPart < 0)
            {
                newIntegerPart -= 1;
                newFractionalPart += 100;
            }
            if (newIntegerPart < 0)
            {
                newIntegerPart = 0;
                newFractionalPart = 0;
            }

            _price = new Money(newIntegerPart, newFractionalPart);
        }

        public void DecreasePrice(int integerPartDecrease, int fractionalPartDecrease)
        {
            AdjustPrice(-integerPartDecrease, -fractionalPartDecrease);
        }

        public void IncreasePrice(int integerPartIncrease, int fractionalPartIncrease)
        {
            AdjustPrice(integerPartIncrease, fractionalPartIncrease);
        }

        public void DisplayProductInfo()
        {
            Console.Write($"Product: {_name}, price: ");
            _price.Display();
        }
    }
}
