using System;

namespace GraphTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();

            Node nodeA = new Node("A");
            Node nodeB = new Node("B");
            Node nodeC = new Node("C");
            Node nodeD = new Node("D");
            Node nodeE = new Node("E");
            Node nodeF = new Node("F");
            Node nodeG = new Node("G");
            Node nodeH = new Node("H");

            graph.AddNode(nodeA);
            graph.AddNode(nodeB);
            graph.AddNode(nodeC);
            graph.AddNode(nodeD);
            graph.AddNode(nodeE);
            graph.AddNode(nodeF);
            graph.AddNode(nodeG);
            graph.AddNode(nodeH);

            #region EVERYTHING CONNECTED TO A

            //  Adds edge between A and B
            Edge edge = new Edge(nodeA, nodeB, 10);
            nodeA.AddEdge(edge);
            nodeB.AddEdge(edge);

            //  Adds edge between A and C
            edge = new Edge(nodeA, nodeC, 10);
            nodeA.AddEdge(edge);
            nodeC.AddEdge(edge);

            //  Adds edge between A and D
            edge = new Edge(nodeA, nodeD, 15);
            nodeA.AddEdge(edge);
            nodeD.AddEdge(edge);

            //  Adds Edge between A and E
            edge = new Edge(nodeA, nodeE, 18);
            nodeA.AddEdge(edge);
            nodeE.AddEdge(edge);

            #endregion

            #region EVERYTHING CONNECTED TO B

            //  Adds Edge between B and E
            edge = new Edge(nodeB, nodeE, 13);
            nodeB.AddEdge(edge);
            nodeE.AddEdge(edge);            
            
            //  Adds Edge between B and E
            edge = new Edge(nodeB, nodeG, 15);
            nodeB.AddEdge(edge);
            nodeG.AddEdge(edge);

            #endregion
            
            #region EVERYTHING CONNECTED TO C

            //  Adds Edge between C and D
            edge = new Edge(nodeC, nodeD, 9);
            nodeC.AddEdge(edge);
            nodeD.AddEdge(edge);            
            
            //  Adds Edge between C and E
            edge = new Edge(nodeC, nodeE, 15);
            nodeC.AddEdge(edge);
            nodeE.AddEdge(edge);

            #endregion
            
            #region EVERYTHING CONNECTED TO D

            //  Adds Edge between D and F
            edge = new Edge(nodeD, nodeF, 8);
            nodeD.AddEdge(edge);
            nodeF.AddEdge(edge);

            #endregion
            
            #region EVERYTHING CONNECTED TO E

            //  Adds Edge between E and F
            edge = new Edge(nodeE, nodeF, 20);
            nodeE.AddEdge(edge);
            nodeF.AddEdge(edge);

            //  Adds Edge between E and G
            edge = new Edge(nodeE, nodeG, 15);
            nodeE.AddEdge(edge);
            nodeG.AddEdge(edge);

            //  Adds Edge between E and H
            edge = new Edge(nodeE, nodeH, 13);
            nodeE.AddEdge(edge);
            nodeH.AddEdge(edge);

            #endregion
            
            #region EVERYTHING CONNECTED TO H

            //  Adds Edge between H and F
            edge = new Edge(nodeH, nodeF, 10);
            nodeH.AddEdge(edge);
            nodeF.AddEdge(edge);

            //  Adds Edge between H and G
            edge = new Edge(nodeH, nodeG, 20);
            nodeH.AddEdge(edge);
            nodeG.AddEdge(edge);

            #endregion

            //graph.DepthFirst(nodeA);
            graph.WidthFirst(nodeA);
        }
    }
}