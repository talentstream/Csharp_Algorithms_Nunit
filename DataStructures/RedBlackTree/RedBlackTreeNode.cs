using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.RedBlackTree
{
    /// <summary>
    ///     红黑树节点定义
    /// </summary>
    public class RedBlackTreeNode<T>
    {
        public T Data { get; }
        public NodeColor Color { get; set; }

        public RedBlackTreeNode<T>? Left { get; set; }
        public RedBlackTreeNode<T>? Right { get; set; }

        public RedBlackTreeNode(T data, NodeColor color)
        {
            Data = data;
            Color = color;
        }
    }

    public enum NodeColor
    {
        Red,
        Black,
    }
}
