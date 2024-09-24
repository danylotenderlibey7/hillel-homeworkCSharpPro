using System.Net.Http.Headers;

namespace _2._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
          /*Console.OutputEncoding = System.Text.Encoding.UTF8;
            Money money = new Money(4, 562);
            money.Display();*/

            Product tv_product = new Product("TV", 9999, 15);
            Product phone_product = new Product("Phone", 999, 815);
            Product laptop_product = new Product("Laptop", 659, 7);

            tv_product.DecreasePrice(99, 16);
            tv_product.DisplayProductInfo();

            phone_product.IncreasePrice(12, 10);
            phone_product.DisplayProductInfo();

            laptop_product.IncreasePrice(51, 93);
            laptop_product.DisplayProductInfo();
        }
    }
}
