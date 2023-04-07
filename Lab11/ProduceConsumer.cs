using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public static class ProduceConsumer
    {
        static Queue<int> queue = new Queue<int>();
        static object lockObject = new object();

        public static void Produce()
        {
            for (int i = 0; i < 10; i++)
            {
                int number = new Random().Next(100);
                lock (lockObject)
                {
                    queue.Enqueue(number);
                    Console.WriteLine($"Виробник згенерував число: {number}.");
                }
                Thread.Sleep(1000);
            }
        }

        public static void Consume()
        {
            while (true)
            {
                int number;
                lock (lockObject)
                {
                    if (queue.Count == 0)
                        continue;
                    number = queue.Dequeue();
                }
                Console.WriteLine($"Число, що отримав споживач: {number}.");
                Thread.Sleep(500);
            }
        }
    }
}
