using _1._1;
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Choose calculator (1. normal or 2. advanced): ");
        int calculator_number = Convert.ToInt32(Console.ReadLine());
        Calculator calculator;

        if (calculator_number == 1)
        {
            calculator = new Calculator();
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
        }
        else if (calculator_number == 2)
        {
            calculator = new Calculator_Advanced();
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Power");
            Console.WriteLine("6. Square Root");
            Console.WriteLine("7. Sin");
            Console.WriteLine("8. Cos");
            Console.WriteLine("9. Tan");
        }
        else
        {
            Console.WriteLine("Invalid calculator choice.");
            return;
        }

        Console.Write("Select an operation: ");
        int calculator_operation = Convert.ToInt32(Console.ReadLine());

        Console.Write("Input first number: ");
        double first_number = Convert.ToDouble(Console.ReadLine());
        double second_number = 0;
        if ((CalculatorOperation)calculator_operation <= CalculatorOperation.Divide)
        {
            Console.Write("Input second number: ");
            second_number = Convert.ToDouble(Console.ReadLine());
        }
        double result;

        try
        {
            switch ((CalculatorOperation)calculator_operation)
            {
                case CalculatorOperation.Add:
                    result = calculator.Add(first_number, second_number);
                    break;
                case CalculatorOperation.Subtract:
                    result = calculator.Subtract(first_number, second_number);
                    break;
                case CalculatorOperation.Multiply:
                    result = calculator.Multiply(first_number, second_number);
                    break;
                case CalculatorOperation.Divide:
                    result = calculator.Divide(first_number, second_number);
                    break;
                case CalculatorOperation.Power when calculator_number == 2:
                    result = ((Calculator_Advanced)calculator).Power(first_number, second_number);
                    break;
                case CalculatorOperation.Sqrt when calculator_number == 2:
                    result = ((Calculator_Advanced)calculator).Sqrt(first_number);
                    break;
                case CalculatorOperation.Sin when calculator_number == 2:
                    result = ((Calculator_Advanced)calculator).Sin(first_number);
                    break;
                case CalculatorOperation.Cos when calculator_number == 2:
                    result = ((Calculator_Advanced)calculator).Cos(first_number);
                    break;
                case CalculatorOperation.Tan when calculator_number == 2:
                    result = ((Calculator_Advanced)calculator).Tan(first_number);
                    break;
                default:
                    Console.WriteLine("Invalid operation choice.");
                    return;
            }

            Console.WriteLine($"Result: {result.ToString("F2")}");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Error: Cannot divide by zero.");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Error: Cannot take the square root of a negative number.");
        }
    }
}
