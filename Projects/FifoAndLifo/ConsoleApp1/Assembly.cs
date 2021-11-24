using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Fifo : DoubleLinkedList
    {
        public int Extract()
        {
            int value = Last.Value;
            if (Last.Prev != null)
            {
                Last.Prev.Next = null;
                Last = Last.Prev;
            }
            else
            {
                //  Only one element in list
                Last = null;
                Root = null;
            }
            return value;
        }
    }

    class Lifo : DoubleLinkedList
    {
        public int Pull()
        {
            int value = Root.Value;
            if (Root.Next != null)
            {
                Root.Next.Prev = null;
                Root = Root.Next;
            }
            else
            {
                //  Only one element in list
                Last = null;
                Root = null;
            }
            return value;
        }
    }
}
