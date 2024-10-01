namespace _4._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Card card1 = new Card("1234 5428 **** ****", "12/29", 008, 2500);
            Card card2 = new Card("9876 1234 **** ****", "01/39", 008, 500);

            Console.WriteLine(card1);
            Console.WriteLine(card2);

            card1 += 1000.00;
            Console.WriteLine($"{card1.Name} new balance: {card1.Balance}$");

            card2 -= 500.00;
            Console.WriteLine($"{card2.Name} new balance: {card2.Balance}$");

            if (card1 > card2)
            {
                Console.WriteLine($"{card1.Name} has more money than {card2.Name}");
            }
            else if (card1 < card2)
            {
                Console.WriteLine($"{card1.Name} has less money than {card2.Name}");
            }
            else
            {
                Console.WriteLine($"{card1.Name} and {card2.Name} have the same balance");
            }

            bool areEqual = card1 == card2;
            Console.WriteLine($"Do {card1.Name} and {card2.Name} have the same CVC? {(areEqual ? "yes" : "no")}");
        }
    }
}
