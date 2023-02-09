using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.RedBlackTree
{
    public class RedBlackTree<T>
    {
        private readonly Comparer<T> comparer;

        public RedBlackTreeNode<T>? Root { get; private set; }

        public RedBlackTree()
        {
            Root = null;
            comparer = Comparer<T>.Default;
        }

        public RedBlackTree(Comparer<T> customComparer)
        {
            comparer = customComparer;
        }

        public void Add(T data)
        {
            if (Root is null)
            {
                Root = new RedBlackTreeNode<T>(data, NodeColor.Red);
            }
            else
            {
                _ = Add(Root, data);
            }
        }

        public void Delete(T data)
        {
            if (!IsRed(Root.Left) && !IsRed(Root.Right))
            {
                Root.Color = NodeColor.Red;
            }

            Root = Delete(Root, data);
            if (Root is not null) Root.Color = NodeColor.Black;
        }


        private RedBlackTreeNode<T> Add(RedBlackTreeNode<T>? curNode, T data)
        {
            if (curNode is null)
            {
                return new RedBlackTreeNode<T>(data, NodeColor.Red);
            }
            var compareResult = comparer.Compare(curNode.Data, data);

            if (compareResult < 0) curNode.Left = Add(curNode.Left, data);
            else if (compareResult > 0) curNode.Right = Add(curNode.Right, data);
            else
            {
                throw new ArgumentException($"Data \"{data}\" already exists in tree!");
            }

            return Balance(curNode);
        }
        private RedBlackTreeNode<T>? Delete(RedBlackTreeNode<T>? curNode, T data)
        {
            var compareResult = comparer.Compare(curNode.Data, data);
            if (compareResult > 0)
            {
                if (!IsRed(curNode.Left) && !IsRed(curNode.Left.Left))
                {
                    curNode = MoveRedLeft(curNode);
                }
                curNode.Left = Delete(curNode.Left, data);
            }
            else
            {
                if (IsRed(curNode.Left))
                {
                    curNode = RotateRight(curNode);
                }
                if(compareResult == 0 && curNode.Right is null)
                {
                    return null;
                }
                if(!IsRed(curNode.Right) && !IsRed(curNode.Right.Left))
                {
                    curNode = MoveRedRight(curNode);
                }
                if(compareResult == 0)
                {

                }
                else
                {
                    curNode.Right = Delete(curNode.Right, data);
                }
            }

            return Balance(curNode);
        }

        private RedBlackTreeNode<T> MoveRedLeft(RedBlackTreeNode<T>? node)
        {
            FlipColors(node);
            if (IsRed(node.Right.Left))
            {
                node.Right = RotateRight(node.Right);
                node = RotateLeft(node);
            }
            return node;
        }
        private RedBlackTreeNode<T> MoveRedRight(RedBlackTreeNode<T>? node)
        {
            FlipColors(node);
            if (!IsRed(node.Left.Left))
            {
                node = RotateRight(node);
            }
            return node;
        }
        private bool IsRed(RedBlackTreeNode<T>? node)
        {
            if (node == null) return false;
            return node.Color == NodeColor.Red;
        }

        private RedBlackTreeNode<T> Balance(RedBlackTreeNode<T> node)
        {
            if (IsRed(node.Right) && !IsRed(node.Left)) node = RotateLeft(node);
            if (IsRed(node.Left) && IsRed(node.Left!.Left)) node = RotateRight(node);
            if (IsRed(node.Left) && IsRed(node.Right)) FlipColors(node);

            return node;
        }
        private RedBlackTreeNode<T> RotateLeft(RedBlackTreeNode<T> node)
        {
            var tempNode = node.Right;
            node.Right = tempNode!.Left;
            tempNode.Left = node;
            tempNode.Color = node.Color;
            node.Color = NodeColor.Red;
            return tempNode;
        }

        private RedBlackTreeNode<T> RotateRight(RedBlackTreeNode<T> node)
        {
            var tempNode = node.Left;
            node.Left = tempNode!.Right;
            tempNode.Right = node;
            tempNode.Color = node.Color;
            node.Color = NodeColor.Red;
            return tempNode;
        }

        private void FlipColors(RedBlackTreeNode<T> node)
        {
            node.Color = NodeColor.Red;
            node.Left!.Color = NodeColor.Black;
            node.Right!.Color = NodeColor.Black;
        }
    }
}
