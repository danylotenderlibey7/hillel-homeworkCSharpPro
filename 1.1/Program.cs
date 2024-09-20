using _1._1;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Choose calculator (1. normal or 2. advanced): ");
        int calculator_number = Convert.ToInt32(Console.ReadLine());
        Calculator calculator;

        Console.WriteLine("1. Addition");
        Console.WriteLine("2. Subtraction");
        Console.WriteLine("3. Multiplication");
        Console.WriteLine("4. Division");

        if (calculator_number == 1)
        {
            calculator = new Calculator();
        }
        else if (calculator_number == 2)
        {
            calculator = new Calculator_Advanced();
            Console.WriteLine("5. Power");
            Console.WriteLine("6. Square Root");
        }
        else
        {
            Console.WriteLine("Invalid calculator choice.");
            return;
        }

        Console.Write("Select an operation: ");
        int calculator_operation = Convert.ToInt32(Console.ReadLine());

        Console.Write("Input first number: ");
        double a = Convert.ToDouble(Console.ReadLine());
        double b = 0;
        if (calculator_operation >= 1 && calculator_operation <= 5)
        {
            Console.Write("Input second number: ");
           b = Convert.ToDouble(Console.ReadLine());
        }
        double result;

        switch (calculator_operation)
        {
            case 1:
                result = calculator.Add(a, b);
                break;
            case 2:
                result = calculator.Subtract(a, b);
                break;
            case 3:
                result = calculator.Multiply(a, b);
                break;
            case 4:
                result = calculator.Divide(a, b);
                break;
            case 5 when calculator_number == 2:
                result = ((Calculator_Advanced)calculator).Power(a, b);
                break;
            case 6 when calculator_number == 2:
                result = ((Calculator_Advanced)calculator).Sqrt(a);
                break;
            default:
                Console.WriteLine("Invalid operation choice.");
                return;
        }

        Console.WriteLine($"Result: {result}");
    }
}
