using System;

namespace SearchAlgorithm___BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] test = { 1, 3, 4, 5, 13, 20, 25, 40, 42, 44, 53 };
            int input = 40;

            int result = BinarySearch(test, 0, test.Length, input);

            if (result != -1)
            {
                Console.WriteLine($"{input} is present at index: {result}");
            }
            else
            {
                Console.WriteLine($"{input} is not present in array");
            }
        }

        static int BinarySearch(int[] arr, int low, int high, int input)
        {
            if (high >= low)
            {
                //  Mid calculation
                double midCal = high + low;
                midCal = Math.Floor(midCal / 2);
                Math.Round(midCal);
                int mid = Convert.ToInt32(midCal);

                //  Íf mid is the users input
                if (arr[mid] == input)
                {
                    return mid;
                }

                // If input is less than mid, then it can only be on the left side
                else if (arr[mid] > input)
                {
                    return BinarySearch(arr, low, mid - 1, input);
                }

                // Else x can only be on the right side
                else
                {
                    return BinarySearch(arr, mid + 1, high, input);
                }
            }
            else
            {
                return -1;
            }
        }
    }
}
