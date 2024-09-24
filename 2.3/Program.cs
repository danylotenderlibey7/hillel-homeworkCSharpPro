
namespace _2._3
{
    public struct DecimalNumber
    {
        private int _value;
        public DecimalNumber(int value)
        { 
            _value = value; 
        }
        public string ToBinary()
        {
            return Convert.ToString(_value,2);
        }
        public string ToOctal()
        {
            return Convert.ToString(_value, 8);
        }
        public string ToHex()
        {
            return Convert.ToString(_value, 16).ToUpper();
        }
        public void Display()
        {
            Console.WriteLine($"DEC: {_value}");
            Console.WriteLine($"BIN: {ToBinary()}");
            Console.WriteLine($"OCT: {ToOctal()}");
            Console.WriteLine($"HEX: {ToHex()}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input a number: ");
            int inputNumber =Convert.ToInt32(Console.ReadLine());

            DecimalNumber number = new DecimalNumber(inputNumber);
            number.Display();

        }
    }
}
