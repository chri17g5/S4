using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] values = { 1, 3, 4, 7, 12, 18, 21, 34, 47 };
            Fifo fifo = new Fifo();
            Lifo lifo = new Lifo();

            foreach (int value in values)   //  Ïnserts values into fifo list
            {
                fifo.Insert(value);
            }

            while (!fifo.IsEmpty)
            {
                Console.WriteLine(fifo.Extract());
            }

            Console.WriteLine("");

            foreach (int value in values)
            {
                lifo.Insert(value);
            }

            while (!lifo.IsEmpty)
            {
                Console.WriteLine(lifo.Pull());
            }
        }
    }
}
