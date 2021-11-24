using System;
using System.Collections.Generic;
using System.Text;

namespace SearchTree1
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

        public void Print()
        {
            Print(Root);
        }

        private void Print(Node node, int level = 0)
        {
            for (int i=0; i< level; i++)
            {
                Console.Write(" ");
            }
            if (node == null)
            {
                Console.WriteLine("-");
                return;
            }
            Console.WriteLine(node.Value);
            Print(node.Left, level +4);
            Print(node.Right, level +4);
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
