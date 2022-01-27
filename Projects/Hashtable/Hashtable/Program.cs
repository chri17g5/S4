using System;

namespace Hashtable
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable<string> hashTable = new HashTable<string>();

            hashTable.Insert("Christian", "Elev");
            hashTable.Insert("Claus", "Lærer");
            hashTable.Insert("Shano", "Elev");
            hashTable.Insert("Jonas", "syvsover");
            hashTable.Insert("Hans", "koder");

            Console.WriteLine(hashTable);

            Console.WriteLine();
            Console.WriteLine(hashTable.GetTvalue("Christian"));
            Console.WriteLine(hashTable.GetTvalue("Claus"));
            Console.WriteLine(hashTable.GetTvalue("Shano"));
            Console.WriteLine(hashTable.GetTvalue("Jonas"));
            Console.WriteLine(hashTable.GetTvalue("Hans"));
        }
    }
}
