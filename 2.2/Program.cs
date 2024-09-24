namespace _2._2
{
    public enum SwitchInstrument
    {
        Violin =1,
        Ukulele =2,
        Trombone =3,
        Cello =4
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Viloin");
            Console.WriteLine("2. Ukulele");
            Console.WriteLine("3. Trombone");
            Console.WriteLine("4. Cello");
            Console.Write("Select number: ");
            int instrumentNumber = Convert.ToInt32(Console.ReadLine());
            
            MusicalInstrument instrument;
            switch (instrumentNumber)
            {
                case (int)SwitchInstrument.Violin:
                    instrument = new Violin();
                    break;
                case (int)SwitchInstrument.Ukulele:
                    instrument = new Ukulele();
                    break;
                case (int)SwitchInstrument.Trombone:
                    instrument = new Trombone();
                    break;
                case (int)SwitchInstrument.Cello:
                    instrument = new Cello();
                    break;
                default:
                    Console.WriteLine("Invalid number!");
                    return;
            }
            instrument.Show();
            instrument.Desc();
            instrument.History();
            instrument.Sound();
        }
    }
}
