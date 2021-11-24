using System;
using System.Collections.Generic;

namespace SearchAlgorithm___BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = 40;

            SortedArray array = new SortedArray();

            int result = array.BinarySearch(input);

            array.Insert(14);

            if (result != -1)
            {
                Console.WriteLine($"{input} is present at index: {result}");
            }
            else
            {
                Console.WriteLine($"{input} is not present in array");
            }
        }

        class SortedArray
        {
            List<int> arr = new List<int>() { 1, 3, 4, 5, 13, 20, 25, 40, 42, 44, 53 };
            //List<int> arr = new List<int>() { 1, 3, 4, 5, 13, 20, 25, 40, 42, 44, 13, 53, 21, 23 };

            private void Swap(int i, int j)
            {
                int tmp = arr[j];
                arr[j] = arr[i];
                arr[i] = tmp;
            }

            public void Insert(int input)
            {
                // Insert new element in array
                arr.Add(input);

                // Swap new element in place
                int i = arr.Count - 1;
                while (i>0)
                {
                    if (arr[i] < arr[i - 1])
                    {
                        // Swap i, i-1
                        Swap(i, i - 1);
                        i--;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            public int BinarySearch(int input)
            {
                return BinarySearch(0, arr.Count, input);
            }

            private int BinarySearch(int low, int high, int input)
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
                        return BinarySearch(low, mid - 1, input);
                    }

                    // Else x can only be on the right side
                    else
                    {
                        return BinarySearch(mid + 1, high, input);
                    }
                }
                else
                {
                    return -1;
                }
            }
        }
    }
}
