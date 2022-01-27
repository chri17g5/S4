using System;
using System.Collections.Generic;
using System.Text;

namespace HeapSort
{
    class HeapTree
    {
        class Node
        {
            public int Value { get; set; }
            public Node Left { get; set; } = null;
            public Node Right { get; set; } = null;
            public Node Parent { get; set; } = null;

            public override string ToString()
            {
                return Value.ToString();
            }
        }

        Node Root = null;
        Node Bottom = null;

        //      (10)
        //     /   \
        //   (15)  (25)
        //   /  \
        // (22) (47)
        //
        // Vi kan finde det nye sted at indsætte en knude ved at starte søgningen ved "bunden"
        //
        // Eksempel: Indsæt 12
        //        (10)
        //      /      \
        //   (15)      (25)
        //   /  \      /
        // (22) (47) (12)
        //

        public void Insert(int value)
        {
            Node node = new Node()
            {
                Value = value,
            };

            if (Bottom == null)
            {
                Root = node;
                Bottom = node;
            }
            else
            {
                Node searchNode = Bottom;
                // Gå op i træet indtil vi kan komme ned til højre til en *ny* underknude
                while (searchNode.Parent != null && searchNode == searchNode.Parent.Right)
                {
                    searchNode = searchNode.Parent;
                }

                if (searchNode.Parent != null && searchNode.Parent.Right == null)
                {
                    // Vi er nået i mål.
                    // Indsætte den nye knude her
                    searchNode.Parent.Right = node;
                    node.Parent = searchNode.Parent;

                    // Fortsæt med at swappe på plads.
                }
                else
                {
                    // Vi kan nu gå ned til højre med mindre træet i forvejen var fuldstændig balanceret.
                    if (searchNode.Parent != null && searchNode != searchNode.Parent.Right)
                    {
                        searchNode = searchNode.Parent.Right;
                    }

                    // Gå til venstre indtil der ikke er flere venstre undertræer
                    while (searchNode.Left != null)
                    {
                        searchNode = searchNode.Left;
                    }

                    // searchNode.Left == null
                    searchNode.Left = node;
                    node.Parent = searchNode;
                }

                Bottom = node;

                // Swap den nye knude op på plads
                while (node.Parent != null && node.Value < node.Parent.Value)
                {
                    // Swap with parent
                    int tmp = node.Value;
                    node.Value = node.Parent.Value;
                    node.Parent.Value = tmp;

                    node = node.Parent;
                }
            }
        }

        public void Print()
        {
            Print(Root);
        }

        private void Print(Node node, int level = 0)
        {
            if (Root == null)
            {
                Console.WriteLine("The tree is empty");
            }

            for (int i = 0; i < level; i++)
            {
                Console.Write(" ");
            }

            if (node == null)
            {
                Console.WriteLine("-");
                return;
            }

            if (node.Parent != null)
            {
                Console.WriteLine($"{node.Parent.Value} - {node.Value}");
            }

            else
            {
                Console.WriteLine(node.Value);
            }

            Print(node.Left, level + 4);
            Print(node.Right, level + 4);
        }

        //      (10)
        //     /   \
        //   (15)  (25)
        //   /  \
        // (22) (47)
        // Eksempel: Fjern (10)
        //        (10)
        //      /      \
        //   (15)      (25)
        //   /  \      /   \
        // (22) (47) (32)  (35)
        //  /
        //(45)
        //
        public int Remove()
        {
            if (Root == null)
            {
                int exit = 0;
                return exit;
            }

            int value = Root.Value;

            Node node = Bottom;
            Node newBottom;

            if (Bottom == Root)
            {
                Root = null;
                Bottom = null;
                return value;
            }

            // Move bottom value to Root
            Root.Value = Bottom.Value;

            // Find new bottom
            if (Bottom.Parent.Right == Bottom)
            {
                newBottom = Bottom.Parent.Left;
                Bottom.Parent.Right = null;
            }
            else
            {
                // Bottom is to the left
                while (node.Parent != null && node.Parent.Left == node)
                {
                    node = node.Parent;
                }

                if (node.Parent != null)
                {
                    // node is right subnode
                    node = node.Parent.Left;
                }
                while (node.Right != null)
                {
                    node = node.Right;
                }
                newBottom = node;
                Bottom.Parent.Left = null;
            }

            Bottom.Parent = null;
            Bottom = newBottom;

            // Swap root value in place
            //        (45)
            //      /      \
            //   (15)      (25)
            //   /  \      /   \
            // (22) (47) (32)  (35)
            // 
            //
            //

            node = Root;
            while ((node.Left != null && node.Value > node.Left.Value) || (node.Right != null &&node.Value > node.Right.Value))
            {
                if (node.Right == null || node.Left.Value < node.Right.Value)
                {
                    int tmp = node.Left.Value;
                    node.Left.Value = node.Value;
                    node.Value = tmp;
                    node = node.Left;
                }
                else
                {
                    int tmp = node.Right.Value;
                    node.Right.Value = node.Value;
                    node.Value = tmp;
                    node = node.Right;
                }
            }


            return value;
        }
    }
}
