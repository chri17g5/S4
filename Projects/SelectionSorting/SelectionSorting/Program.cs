using System;

namespace SelectionSorting
{
    class Program
    {
        static int[] Elements = { 5, 1, 3, 2, 6, 8, 12, 41, 421, 432, 50, 102 };
        static void Main(string[] args)
        {
            int[] ElementCopy = Elements.Clone() as int[];
            SelectionSorting(ElementCopy);
            Console.WriteLine("SelectionSorting:");
            foreach (int value in ElementCopy)
            {
                Console.Write($"{value} ");
            }

            Console.WriteLine("\n\nInsertionSorting:");
            int[] iSorting = InsertionSorting(ElementCopy);
            foreach (int value in iSorting)
            {
                Console.Write($"{value} ");
            }

            Console.WriteLine("\n\nBoubleSorting:");
            int[] bSorting = BoubbleSort(ElementCopy);
            foreach (int value in bSorting)
            {
                Console.Write($"{value} ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Sorts Array by smallest number first
        /// </summary>
        /// <param name="values">int array that needs sorting</param>
        static void SelectionSorting(int[] values)
        {
            //-----------------------------------------------------------------
            //  Runs trough entire array too look for sortest value
            //  Then puts it in fron of the array
            //  Then we look for the second highest number
            //  (we don't look at first num)
            //  And we determin it's value until we have a fully sorted array
            //-----------------------------------------------------------------

            int unsorted = 0;   //  Points at the first index

            while (unsorted < values.Length)
            {
                int candidate = unsorted;
                for (int i = unsorted; i < values.Length; i++)
                {
                    if (values[i] < values[candidate])
                    {
                        candidate = i;
                    }
                }
                Swap(values, unsorted, candidate);

                //  Gets unsorted to the next index
                unsorted++;
            }
        }

        public static int[] InsertionSorting(int[] arr)
        {
            //-----------------------------------------------------------------
            //  Takes last number in array and checks if the number before
            //  is lower.
            //  If so swap thier position
            //  Do this till entire array is sorted
            //-----------------------------------------------------------------

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (arr[j - 1] > arr[j])
                    {
                        Swap(arr, j - 1, j);
                    }
                }
            }
            return arr;
        }

        public static int[] BoubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 2; i++)
            {
                for (int j = 0; j < arr.Length - 2; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(arr, j, j + 1);
                    }
                }
            }
            return arr;
        }

        /// <summary>
        /// Swaps aroud value i & j
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private static void Swap(int[] arr, int i, int j)
        {
            int tmp = arr[j];
            arr[j] = arr[i];
            arr[i] = tmp;
        }
    }
}
