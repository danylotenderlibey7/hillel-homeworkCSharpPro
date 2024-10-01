namespace _4._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            City city1 = new City("Kyiv", "Ukraine", 2884000);
            City city2 = new City("Almaty", "Kazakhstan", 1770000);

            Console.WriteLine(city1);
            Console.WriteLine(city2);

            city1 += 100000;
            Console.WriteLine($"{city1.Name} after population increase: {city1.Population}");

            city2 -= 70000;
            Console.WriteLine($"{city2.Name} after population decrease: {city2.Population}");

            if (city1 > city2)
            {
                Console.WriteLine($"{city1.Name} has a larger population than {city2.Name}");
            }
            else if (city1 < city2)
            {
                Console.WriteLine($"{city1.Name} has a smaller population than {city2.Name}");
            }
            else
            {
                Console.WriteLine($"{city1.Name} and {city2.Name} have the same population");
            }

            bool areEqual = city1 == city2;
            string result = areEqual ? "yes" : "no";
            Console.WriteLine($"Do {city1.Name} and {city2.Name} have the same population? {result}");
        }
    }
}
