namespace _3._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 4, 3, 1, 5, 2, 6 };
            int valueToSearch1 = 1;
            int valueToSearch2 = 7;
            MyArray myArray = new MyArray(numbers);

            Console.WriteLine("Task 1");
            myArray.Show();
            myArray.Show("Information");

            Console.WriteLine();
            Console.WriteLine("Task 2");
            Console.WriteLine($"Max: {myArray.Max()}");
            Console.WriteLine($"Min: {myArray.Min()}");
            Console.WriteLine($"Average: {myArray.Avg()}");
            Console.WriteLine($"Searched value: {valueToSearch1} - " + (myArray.Search(valueToSearch1) ? "found" : "not found"));
            Console.WriteLine($"Searched value: {valueToSearch2} - " + (myArray.Search(valueToSearch2) ? "found" : "not found"));

            Console.WriteLine();
            Console.WriteLine("Task 3");
            myArray.SortAsc();
            myArray.Show("Array after sorting in ascending order:");
            myArray.SortDesc();
            myArray.Show("Array after sorting in descending order:");

            myArray.SortByParam(true);
            myArray.Show("Array after sorting in ascending order (choosing method SortByParam):");
            myArray.SortByParam(false);
            myArray.Show("Array after sorting in descending order (choosing method SortByParam):");
        }
    }
}
