using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.BinarySearchTree
{
    /// <summary>
    ///     二叉搜索树节点定义
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinarySearchTreeNode<T>
    {
        public T Data { get; }

        public BinarySearchTreeNode<T>? Left { get; set; }
        public BinarySearchTreeNode<T>? Right { get; set; }

        public BinarySearchTreeNode(T data) => Data = data;
    }
}
