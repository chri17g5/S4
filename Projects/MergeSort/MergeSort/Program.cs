using System;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] testArr = { 3, 4, 23, 21, 43, 12, 55, 54, 2, 1, 5 };

            Console.WriteLine("\nFinal output: ");
            PrintArr(MSort(testArr));
        }

        static int[] MSort(int[] arr)
        {
            //  Basecase
            if (arr.Length > 1)
            {
                int mid = arr.Length / 2;   //  Math for mid - number of elements in the left part
                int[] arrLeft = new int[mid];
                int[] arrRight = new int[arr.Length - mid];
                Array.Copy(arr, 0, arrLeft, 0, mid);
                Array.Copy(arr, mid, arrRight, 0, arr.Length - mid);
                arrLeft = MSort(arrLeft);    //    Left sort array
                arrRight = MSort(arrRight);   //    Right sort array
                return Merge(arrLeft, arrRight); //    Merge
            }
            else
            {
                return arr;
            }
        }

        static int[] Merge(int[] arr1, int[] arr2)
        {
            //  Lengh of tmp arrays
            int[] arr = new int[arr1.Length + arr2.Length];

            int i1 = 0;
            int i2 = 0;
            int i = 0;
            while (i2<arr2.Length && i1<arr1.Length)
            {
                if (arr1[i1] < arr2[i2])
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

            if (i2>=arr2.Length)
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

        static void PrintArr(int[] arr)
        {
            foreach (int value in arr)
            {
                Console.Write($"{value} ");
            }
        }
    }
}
