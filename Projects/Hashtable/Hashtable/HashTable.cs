using System;
using System.Collections.Generic;
using System.Text;

namespace Hashtable
{
    class HashTable<Tvalue>
    {
        const int size = 5;
        string key { get; set; }
        (string key, Tvalue value)[] values { get; set; } = new (string key, Tvalue value)[size];

        int HashFunc(string key)
        {
            int index = 0;
            for (int i = 0; i < key.Length; i++)
            {
                index += key[i];
            }

            index = index % size;
            return index;
        }

        public void Insert(string key, Tvalue value)
        {
            int index = HashFunc(key);

            // Is the location already taken, then take next free location
            while (values[index].value != null && values[index].key != key)
            {
                index = (index + 1) % size;
            }

            values[index] = (key, value);
        }

        public Tvalue GetTvalue(string key)
        {
            int index = HashFunc(key);
            int startindex = index;

            while (values[index].value != null && values[index].key != key)
            {
                index = (index + 1) % size;
                if (index == startindex)
                {
                    return default(Tvalue);
                }
            }

            return values[index].value;
        }

        public override string ToString()
        {
            string result = "";
            foreach((string key, Tvalue value) hash in values)
            {
                Tvalue v = hash.value;
                if (v != null)
                {
                    result += $"{v.ToString()}\n";
                }

            }
            return result;
        }
    }
}
