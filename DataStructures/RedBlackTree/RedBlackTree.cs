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

        private RedBlackTreeNode<T> Add(RedBlackTreeNode<T>? curNode, T data)
        {
            if(curNode is null)
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

            if (IsRed(curNode.Right) && !IsRed(curNode.Left)) curNode = RotateLeft(curNode);
            if (IsRed(curNode.Left) && IsRed(curNode.Left!.Left)) curNode = RotateRight(curNode);
            if (IsRed(curNode.Left) && IsRed(curNode.Right)) FlipColors(curNode);

            return curNode;
        }

        private bool IsRed(RedBlackTreeNode<T>? node)
        {
            if (node == null) return false;
            return node.Color == NodeColor.Red;
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
