namespace _4._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee emp1 = new Employee("Danylo", 5000);
            Employee emp2 = new Employee("Zakhar", 7500);

            Console.WriteLine(emp1);
            Console.WriteLine(emp2);

            emp1 += 1000;
            Console.WriteLine($"{emp1.Name} after the salary increase: {emp1.Salary}$");

            emp2 -= 500;
            Console.WriteLine($"{emp2.Name} after a reduction in salary: {emp2.Salary}$");


            if (emp1 > emp2)
            {
                Console.WriteLine($"{emp1.Name} receives more than {emp2.Name}");
            }
            else if (emp1 < emp2)
            {
                Console.WriteLine($"{emp1.Name} receives less than {emp2.Name}");
            }
            else
            {
                Console.WriteLine($"{emp1.Name} and {emp2.Name} have the same salary");
            }

            bool areEqual = emp1 == emp2;
            string result = areEqual ? "yes" : "no";
            Console.WriteLine($"Employees' salaries are the same: {result}");
        }
    }
}
