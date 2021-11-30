using System;

namespace Generic_MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] testArr = { 3, 4, 23, 21, 43, 12, 55, 54, 2, 1, 5 };
            string[] testArr1 = { "Doma", "Shiina", "Aoi", "Reisuko" };

            Console.WriteLine("Final int output: ");
            PrintArr(MSort(testArr));

            Console.WriteLine("\n\nFinal string output: ");
            PrintArr(MSort(testArr1));

            Console.WriteLine();
        }


        static T[] MSort<T>(T[] arr) where T : IComparable
        {
            //  Basecase
            if (arr.Length > 1)
            {
                int mid = arr.Length / 2;        //  Math for mid - number of elements in the left part
                T[] arrLeft = new T[mid];
                T[] arrRight = new T[arr.Length - mid];
                Array.Copy(arr, 0, arrLeft, 0, mid);
                Array.Copy(arr, mid, arrRight, 0, arr.Length - mid);
                arrLeft = MSort(arrLeft);        //    Left sort array
                arrRight = MSort(arrRight);      //    Right sort array
                return Merge(arrLeft, arrRight); //    Merge
            }
            else
            {
                return arr;
            }
        }

        static T[] Merge<T>(T[] arr1, T[] arr2) where T : IComparable
        {
            //  Lengh of tmp arrays
            T[] arr = new T[arr1.Length + arr2.Length];

            int i1 = 0;
            int i2 = 0;
            int i = 0;
            while (i2 < arr2.Length && i1 < arr1.Length)
            {
                if (arr1[i1].CompareTo(arr2[i2]) < 0)
                {
                    arr[i] = arr1[i1];
                    i1++;
                }
                else
                {
                    arr[i] = arr2[i2];
                    i2++;
                }
                i++;
            }

            if (i2 >= arr2.Length)
            {
                while (i1 < arr1.Length)
                {
                    arr[i] = arr1[i1];
                    i++;
                    i1++;
                }
            }
            else
            {
                while (i2 < arr2.Length)
                {
                    arr[i] = arr2[i2];
                    i++;
                    i2++;
                }
            }

            return arr;
        }

        static void PrintArr<T>(T[] arr)
        {
            foreach (T value in arr)
            {
                Console.Write($"{value} ");
            }
        }
    }
}
