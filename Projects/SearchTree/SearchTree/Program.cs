using System;

namespace SearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            float[] values = { 1, 3, 4, 7, 12, 18, 21, 34, 47 };
            Fifo fifo = new Fifo();

            foreach (float value in values)
            {
                fifo.Insert(value);
            }

            while (!fifo.IsEmpty)
            {
                Console.WriteLine(fifo.Extract());
            }
        }
    }
}
