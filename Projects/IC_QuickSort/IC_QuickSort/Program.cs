using System;
using System.Collections.Generic;

namespace IC_QuickSort
{
    class Program
    {
        static int[] Elements = { 12, 6, 14, 9, 2, 21, 15, 4, 20, 8, 13, 5, 17, 10, 11, 7, 18, 1, 16, 3, 19 };

        static void Main(string[] args)
        {
            int[] ElementCopy = Elements.Clone() as int[];
            QuickSort(ElementCopy);
            Console.WriteLine("\nQuickSort:");
            WriteArray(ElementCopy);
        }
        static void WriteArray(int[] arr)
        {
            foreach (int value in arr)
            {
                Console.Write($"{value} ");
            }
            Console.WriteLine();
        }

        static void Swap<T>(int i, int j, T[] arr)
        {
            T tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
        }

        static void QuickSort<T>(T[] values) where T:IComparable
        {
            void QSort(int start, int end)
            {
                //  Basecase
                if (end - start <= 0)
                {
                    return;
                }

                T pivot = values[start];

                //  Both sides defined
                int left = start;
                int right = end;

                //Swap(left, right, values);
                while (left <= right)
                {
                    //  If left value is less than pivot check the next left item
                    if (values[left].CompareTo(pivot) < 0)
                    {
                        left++;
                    }
                    //  If right value is more than pivot check the next right item
                    else if (values[right].CompareTo(pivot) > 0)
                    {
                        right--;
                    }
                    //  Else left and right are wrong and we swap them
                    else
                    {
                        Swap(left, right, values);
                        left++;
                        right--;
                    }
                }

                QSort(start, right);
                QSort(left, end);
            }

            QSort(0, values.Length - 1);
        }
    }
}
