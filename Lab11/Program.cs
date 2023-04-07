using System;
using Task1;

namespace Lab11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread producer = new Thread(ProduceConsumer.Produce);
            Thread consumer = new Thread(ProduceConsumer.Consume);

            producer.Start();
            consumer.Start();

            producer.Join();
            consumer.Join();

            Console.ReadLine();
        }
    }
}