using System;
using System.Collections.Generic;
using System.Text;

namespace SearchTree
{
    class DoubleLinkedList
    {
        public DoubleLinkedListElement Root = null;
        public DoubleLinkedListElement Last = null;
        public bool IsEmpty
        {
            get
            {
                return Root == null;
            }
        }
        public class DoubleLinkedListElement
        {
            public float Value { get; set; }
            public DoubleLinkedListElement Next { get; set; }
            public DoubleLinkedListElement Prev { get; set; }
        }
        public void Insert(float value)
        {
            DoubleLinkedListElement newElement = new DoubleLinkedListElement()
            {
                Value = value,
                Next = Root,
                Prev = null
            };

            if (newElement.Next != null)
            {
                newElement.Next.Prev = newElement;
            }
            else
            {
                Last = newElement;
            }
            Root = newElement;
        }
    }

    class Fifo : DoubleLinkedList
    {
        public float Extract()
        {
            float value = Last.Value;
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
}
