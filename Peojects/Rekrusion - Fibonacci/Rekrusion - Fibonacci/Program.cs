using System;

namespace Rekrusion___Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                //  Get userinput
                Console.WriteLine("<< Please enter a value of = n >>");
                string userInput = Console.ReadLine();

                //  Try catch mainly so the program doesn't crash, if it fails to parse the int
                try
                {
                    int userNum = int.Parse(userInput);
                    WriteFibonacci(userNum);  //  Call Factorial function and write it!
                }
                catch
                {
                    //  Error message
                    Console.WriteLine("<< ERROR: Input was not an interger >>");
                }
            }
        }

        /// <summary>
        /// Prints out given Fibonacci que number.
        /// </summary>
        /// <param name="queNumber"></param>
        /// <returns></returns>
        static int Fibonacci(int queNumber)
        {
            if (queNumber <= 2)
                return 1;
            
            return Fibonacci(queNumber - 1) + Fibonacci(queNumber - 2);
        }

        /// <summary>
        /// Writes a Fibonacci value untill it hits "count" ammount
        /// </summary>
        /// <param name="count">Amount of times it has to count</param>
        static void WriteFibonacci(int count)
        {
            if (count > 1)
            {
                WriteFibonacci(count - 1);
            }
            Console.WriteLine(Fibonacci(count));
        }
    }
}
