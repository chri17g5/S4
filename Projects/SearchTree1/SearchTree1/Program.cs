using System;

namespace SearchTree1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

            }

            SearchTree tree = new SearchTree();
            int[] val = { 11, 18, 15, 19, 13, 17, 13, 16 };

            foreach (int v in val)
            {
                tree.Insert(v);
            }

            //int a = 17;
            //Console.WriteLine(tree.Search(a));

            tree.Print();
        }
    }
}
