namespace _5._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (Play play = new Play("Hamlet", "William Shakespeare", "Tragedy", 1603))
            {
                play.DisplayInfo();
            }
            Console.WriteLine();
            using (Store store = new Store("Grocery Store", "123 Main St", "Grocery"))
            {
                store.DisplayInfo();
            }
        }
    }
}
