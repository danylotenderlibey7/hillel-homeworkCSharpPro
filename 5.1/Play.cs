using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _5._1
{
    public class Play : IDisposable
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public Play(string title, string author, string genre, int year)
        {
            Title = title;
            Author = author;
            Genre = genre;
            Year = year;
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Genre: {Genre}");
            Console.WriteLine($"Year: {Year}");
            Console.WriteLine();
        }
        ~Play()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Play *{Title}* is destroyed.");
            Console.ResetColor();
        }
        public void Dispose()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Disposing play: {Title}");
            Console.ResetColor();
            GC.SuppressFinalize(this);
        }

    }
}
