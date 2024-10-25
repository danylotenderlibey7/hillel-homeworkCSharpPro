namespace _7._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int totalClients = new Random().Next(3, 10);
            int waitingChairCount = new Random().Next(2, 5);
            Console.WriteLine($"There are {totalClients} clients");
            Console.WriteLine();

            var barberShop = new BarberShop(waitingChairCount, totalClients); 
            var barberThread = new Thread(barberShop.StartBarber);//поток для барбера
            barberThread.Start();

            List<Thread> clientThreads = new List<Thread>();

            for (int i = 1; i <= totalClients; i++)//потоки для клиентов
            {
                int clientNumber = i;
                var clientThread = new Thread(() => barberShop.EnterBarberShop(clientNumber));
                clientThreads.Add(clientThread);//добавление потока в список
                clientThread.Start();//запуск клиента

                Thread.Sleep(new Random().Next(1, 3)*1000);//время прибытия другого клиента
            }

            foreach (var thread in clientThreads)//ожидания прибытия всех клиентов
            {
                thread.Join();
            }

            barberThread.Join();//ожидания конца работы барбера
            Console.WriteLine("The barbershop is closed for the day.");
        }
    }
}
