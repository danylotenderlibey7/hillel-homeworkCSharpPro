using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._1
{
    public class MyArray : IOutput, IMath, ISort
    {
        private int[] array;
        public MyArray(int[] array)
        {
            this.array = array;
        }
        public void Show()
        {
            foreach (var item in this.array)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
        public void Show(string info)
        {
            Console.Write($"{info}: ");
            Show();
        }
        //2
        public int Max()
        {
            return this.array.Max();
        }
        public int Min()
        {
            return this.array.Min();
        }
        public float Avg()
        {
            return (float)this.array.Average();
        }
        public bool Search(int valueToSearch)
        {
            return array.Contains(valueToSearch);
        }
        //3
        public void SortAsc()
        {
            Array.Sort(array);
        }
        public void SortDesc()
        {
            Array.Sort(array);
            Array.Reverse(array);
        }
        public void SortByParam(bool isAsc)
        {
            if (isAsc)
            {
                SortAsc();
            }
            else
            {
                SortDesc();
            }
        }
    }
}
