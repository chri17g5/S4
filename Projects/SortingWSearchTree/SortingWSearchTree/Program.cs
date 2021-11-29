using System;

namespace SortingWSearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            SearchTree tree = new SearchTree();
            int[] arr = { 54, 12, 41, 2, 49, 14, 53, 1, 30, 5, 7, 15, 533 };

            foreach (int v in arr)
            {
                tree.Insert(v);
            }


            int value = 2;
            Console.WriteLine(tree.Search(value));

            Console.WriteLine(tree.SortTree());
        }
    }
}
