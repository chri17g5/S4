using System;
using System.Collections.Generic;
using System.Text;

namespace GraphTraversal
{
    class Graph
    {
        List<Node> nodes = new List<Node>();

        public void AddNode(Node node)
        {
            nodes.Add(node);
        }

        public void DepthFirst(Node node)
        {
            foreach (Node n in nodes)
            {
                n.Visited = false;
            }

            node.DepthFirst();
        }

        public void WidthFirst(Node node)
        {
            foreach (Node n in nodes)
            {
                n.Visited = false;
            }

            NodeQueue nodeQuue = new NodeQueue();
            node.WidthFirst(nodeQuue);

        }
    }

    class NodeQueue
    {
        public NodeQueueNode Root { get; set; } = null;
        public NodeQueueNode Last { get; set; } = null;

        public void Push(Node node)
        {
            NodeQueueNode newNode = new NodeQueueNode(node);
            newNode.Next = null;
            if (Last != null)
            {
                Last.Next = newNode;
            }
            newNode.Prev = Last;
            Last = newNode;
            if (Root == null)
            {
                Root = newNode;
            }
        }

        public Node Pop()
        {
            if (Last == Root)
            {
                Last = null;
            }
            Node node = Root.Node;
            Root = Root.Next;
            if (Root != null)
            {
                Root.Prev = null;
            }
            return node;
        }
    }

    class NodeQueueNode
    {
        public NodeQueueNode(Node node)
        {
            Node = node;
        }
        public Node Node { get; set; }
        public NodeQueueNode Next { get; set; }
        public NodeQueueNode Prev { get; set; }

        public override string ToString()
        {
            return Node.ToString();
        }
    }

    class Node
    {
        public bool Visited { get; set; }
        string name;
        List<Edge> edges = new List<Edge>();

        public Node(string name)
        {
            this.name = name;
        }

        public void AddEdge(Edge edge)
        {
            edges.Add(edge);
        }

        public void DepthFirst()
        {
            if (Visited)
            {
                Console.WriteLine($"already visited {name}");
                return;
            }

            Console.WriteLine(name);
            Visited = true;
            foreach (Edge e in edges)
            {
                if (e.node1 != this)
                {
                    e.node1.DepthFirst();
                }
                else
                {
                    e.node2.DepthFirst();
                }
            }
           
        }

        public void WidthFirst(NodeQueue nodeQueue)
        {
            if (Visited)
            {
                Console.WriteLine($"already visited {name}");
                return;
            }

            Console.WriteLine(name);
            Visited = true;

            foreach (Edge e in edges)
            {
                if (e.node1 != this)
                {
                    nodeQueue.Push(e.node1);
                }
                else
                {
                    nodeQueue.Push(e.node2);
                }
            }

            while (nodeQueue.Root != null)
            {
                nodeQueue.Pop().WidthFirst(nodeQueue);
            }
        }

        public override string ToString()
        {
            return name;
        }
    }

    class Edge
    {

        public Edge(Node node1, Node node2, int distance)
        {
            this.node1 = node1;
            this.node2 = node2;
            this.distance = distance;
        }
        public Node node1 { get; set; }
        public Node node2 { get; set; }

        int distance;
    }
}
