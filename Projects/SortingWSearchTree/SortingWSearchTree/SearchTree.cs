using System;
using System.Collections.Generic;
using System.Text;

namespace SortingWSearchTree
{
    class SearchTree
    {
        class Node
        {
            public Node Left { get; set; } = null;
            public Node Right { get; set; } = null;
            public int Value { get; set; }

        }

        Node Root = null;

        public void WriteTree()
        {
            WriteTree(Root);
            Console.WriteLine();
        }

        public List<int> SortTree()
        {
            List<int> list = new List<int>();
            Sort(list, Root);
            return list;
        }

        private void Sort(List<int> sortedList, Node node)
        {
            if (node != null)
            {
                Sort(sortedList, node.Left);
                sortedList.Add(node.Value);
                Sort(sortedList, node.Right);
            }
        }

        private void WriteTree(Node node)
        {
            if (node != null)
            {
                WriteTree(node.Left);
                Console.WriteLine($"{node.Value} ");
                WriteTree(node.Right);
            }
        }

        public void Insert(int value)
        {
            Node newNode = new Node();
            newNode.Value = value;

            if (Root == null)
            {
                Root = newNode;
            }
            else
            {
                // Find the Node to insert new node under
                Node node = Root;
                while (true)
                {
                    if (newNode.Value < node.Value)
                    {
                        // Go left i possible
                        if (node.Left != null)
                        {
                            node = node.Left;
                        }
                        else
                        {
                            node.Left = newNode;
                            break;
                        }
                    }
                    else
                    {
                        // Go right if possble
                        if (node.Right != null)
                        {
                            node = node.Right;
                        }
                        else
                        {
                            node.Right = newNode;
                            break;
                        }
                    }
                }
            }
        }

        public bool Search(int value)
        {
            Node node = Root;
            while (true)
            {
                if (value < node.Value)
                {
                    //  If current node is value
                    if (node.Value == value)
                    {
                        return true;
                    }

                    // Go left i possible
                    else if (node.Left != null)
                    {
                        node = node.Left;
                    }
                    //  If we hit a dead end return false
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    //  If current node is value
                    if (node.Value == value)
                    {
                        return true;
                    }

                    // Go Right i possible
                    else if (node.Right != null)
                    {
                        node = node.Right;
                    }
                    //  If we hit a dead end return false
                    else
                    {
                        return false;
                    }
                }
            }
        }
    }
}
