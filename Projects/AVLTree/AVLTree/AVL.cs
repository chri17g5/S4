using System;
using System.Collections.Generic;
using System.Text;

namespace AVLTree
{
    class AVL
    {
        class Node
        {
            public Node(int value)
            {
                Value = value;
            }

            int Value { get; set; }

            Node Left;
            Node Right;
            Node Parent;

            int Height;
            int Balance;

            public static Node Root { get; set; }

            public void Insert(int value)
            {
                if (value < Value)
                {
                    if (Left != null)
                    {
                        Left.Insert(value);
                    }

                    else
                    {
                        Left = new Node(value);
                    }
                }
                else
                {
                    if (Right != null)
                    {
                        Right.Insert(value);
                    }

                    else
                    {
                        Right = new Node(value);

                    }
                    UpdateHeightAndBalance();

                    //  Preform rotation to rebalance the AVL tree
                    Rebalance();

                }
            }

            void UpdateHeightAndBalance()
            {
                int leftHeight = -1;
                int rightHeight = -1;
                if (Left != null)
                {
                    leftHeight = Left.Height;
                }

                if (Right != null)
                {
                    rightHeight = Right.Height;
                }

                Height = Math.Max(leftHeight, rightHeight) + 1;

                Balance = leftHeight - rightHeight;
            }

            void Rebalance()
            {
                if (Balance > 1) //  Left Heavy Tree
                {
                    if (Left.Balance > 0) //    If Left(2) is heavy
                    {
                        RightRotate();
                    }
                    else //     if (2) is right heavy
                    {
                        Left.LeftRotate();
                        RightRotate();
                    }

                }

                else if (Balance < -1) //   Right Heavy Tree
                {
                    if (Right.Balance < 0) //    If Right(2) is heavy
                    {
                        LeftRotate();
                    }
                    else //     if (2) is right heavy
                    {
                        Right.RightRotate();
                        LeftRotate();
                    }
                }
            }
            void LeftRotate()
            {
                Node nodeL2 = Right.Left;
                Node parent1 = Parent;

                Right.Left = this;
                Parent = Right;

                Right = nodeL2;
                nodeL2.Parent = this;

                Parent.Parent = parent1;
                if (parent1 != null)
                {
                    Root = Parent;
                    Parent.Parent = null;
                }

                else
                {
                    Parent.Parent = parent1;
                    if (parent1.Left == this)
                    {
                        Parent.Left = Parent;
                    }
                    else
                    {
                        parent1.Right = Parent;
                    }
                }

                UpdateHeightAndBalance();
                Parent.UpdateHeightAndBalance();
            }

            void RightRotate()
            {
                Node node2R = Left.Right;
                Node Parent3 = Parent;

                Left.Right = this;
                this.Parent = Left;

                Left = node2R;
                if (node2R != null)
                {
                    node2R.Parent = this;
                }

                if (this == Root)
                {
                    Root = Parent;
                }
                else
                {
                    Parent.Parent = Parent3;
                    if (Parent3.Left == this)
                    {
                        Parent.Left = Parent;
                    }
                    else
                    {
                        Parent3.Right = Parent;
                    }
                }

                UpdateHeightAndBalance();
                Parent.UpdateHeightAndBalance();
            }
        }

        Node Root = null;

        public void Insert(int value)
        {
            if (Root != null)
            {
                Root.Insert(value);
            }
            else
            {
                Root = new Node(value);
            }
        }
    }
}
