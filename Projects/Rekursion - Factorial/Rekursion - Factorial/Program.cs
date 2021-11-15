using System;

namespace Rekursion___Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                //  Get userinput
                Console.WriteLine("<< Please enter a value of = n >>");
                string userInput = Console.ReadLine();

                //  Try catch manly so the program doesn't crash if it fails to parse the int
                try
                {
                    int userNum = int.Parse(userInput);
                    Console.WriteLine(Factorial(userNum));  //  Call Factorial function and write it!
                }
                catch
                {
                    //  Error message
                    Console.WriteLine("<< ERROR: Input was not an interger >>");
                }
            }
        }

        static int Factorial(int number)
        {
            if (number == 1)    //  Ends the recursion if the number is one
                return 1;

            //  Returns the factorial number 
            return number * Factorial(number - 1);  //  Too large numbers create a stack overflow error
        }
    }
}
