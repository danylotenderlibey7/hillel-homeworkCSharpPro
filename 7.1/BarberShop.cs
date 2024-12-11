using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _7._1
{
    public class BarberShop
    {
        Random random = new Random();
        private static Semaphore waitingChair;// Семафор для ожидания -> кресло ожидания
        private static Semaphore barberChair = new Semaphore(1, 1);// Семафор для кресла барбера
        private static Semaphore barberSleepChair = new Semaphore(0, 1);// Семафор для контроля

        private int _clientsServed = 0;
        private int _totalClients;

        public BarberShop(int waitingChairCount, int totalClients) 
        { 
            waitingChair = new Semaphore(waitingChairCount, waitingChairCount);
            _totalClients = totalClients;
        }

        public void EnterBarberShop(int clientCount)//метод входа клиента в барбершоп
        {
            Console.WriteLine($"The client {clientCount} entered the barbershop");

            if (waitingChair.WaitOne(0)) // Есть ли свободное место в креслах ожидания
            {
                Console.WriteLine($"The client {clientCount} is waiting on a waiting chair");
                barberChair.WaitOne();// Клиент занимает кресло барбера
                waitingChair.Release();// Освобождается место в креслах ожидания

                Console.WriteLine($"The client {clientCount} is on a barber chair");
                barberSleepChair.Release();// Барбер просыпаеться

                Thread.Sleep(random.Next(1, 3) * 1000);//Время стрижки
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"The client {clientCount} left the barbershop");
                Console.ResetColor();
                barberChair.Release();//Кресло барбера освобождено 

                Interlocked.Increment(ref _clientsServed);//Увеличивает счетчик обслуженых клиентов
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"The client {clientCount} didn't find a free chair and left");
                Console.ResetColor();
            }
        }

        public void StartBarber()//метод работы барбера
        {
            while(_clientsServed < _totalClients)
            {
                Console.WriteLine("The barber felt asleep");
                barberSleepChair.WaitOne();//барбер ждет пока его не разбудят
                Console.WriteLine("The barber woke up and started cutting");
                Console.WriteLine();

                Thread.Sleep(random.Next(1, 3) * 1000);//время стрижки
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The barber has finished his work");
                Console.ResetColor();
            }
            Console.WriteLine();
            Console.WriteLine("All clients have been served. The barber is going home.");
        }
    }
}
