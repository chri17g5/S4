using System;

namespace HeapSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 13, 1, 23, 6, 89, 64, 23, 54 };

            HeapTree tree = new HeapTree();
            foreach (int i in arr)
            {
                tree.Insert(i);
            }

            for (int i = arr.Length + 1; i > 0; i--)
            {
                tree.Print();
                tree.Remove();
            }
        }
    }
}
