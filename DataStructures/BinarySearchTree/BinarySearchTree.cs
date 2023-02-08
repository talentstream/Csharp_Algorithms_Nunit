using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.BinarySearchTree
{
    /// <summary>
    ///     二叉查找树，这里实现的二叉查找树节点数据不重复
    /// </summary>
    /// <remarks>
    ///     二叉查找树的属性 ：
    ///     <list type="bullet">
    ///         <item>当前节点左孩子的值要小于当前节点的值</item>
    ///         <item>当前节点右孩子的值要大于当前节点的值</item>
    ///         <item>平均情况下插入、删除、查找操作的时间复杂度为O(logn)</item>
    ///     </list>
    ///     提供的API ：
    ///     <list type="bullet">
    ///         <item>Add</item>
    ///         <item>AddRange</item>
    ///         <item>Search</item>
    ///         <item>Contains</item>
    ///         <item>Remove</item>
    ///         <item>GetMax</item>
    ///         <item>GetMin</item>
    ///         <item>GetKeysInOrder</item>
    ///         <item>GetKeysPreOrder</item>
    ///         <item>GetKeysPostOrder</item>
    ///     </list>
    /// </remarks>
    /// <typeparam name="T"></typeparam>
    public class BinarySearchTree<T>
    {
        private readonly Comparer<T> comparer;

        public BinarySearchTreeNode<T>? Root { get; private set; }

        public int Count { get; private set; }
        public BinarySearchTree()
        {
            Root = null;
            Count = 0;
            comparer = Comparer<T>.Default;
        }
        public BinarySearchTree(Comparer<T> customComparer)
        {
            Root = null;
            Count = 0;
            comparer = customComparer;
        }
        public void Add(T data)
        {
            if (Root is null)
            {
                Root = new BinarySearchTreeNode<T>(data);
            }
            else
            {
                Add(Root, data);
            }

            Count++;
        }
        public void AddRange(IEnumerable<T> datas)
        {
            foreach (var data in datas)
            {
                Add(data);
            }
        }

        public BinarySearchTreeNode<T>? Search(T data) => Search(Root, data);
        public bool Contains(T data) => Search(Root, data) is not null;
        public bool Remove(T data)
        {
            if (Root is null)
            {
                return false;
            }

            var result = Remove(Root, Root, data);
            if (result)
            {
                Count--;
            }
            return result;
        }

        public BinarySearchTreeNode<T>? GetMax()
        {
            if (Root is null)
            {
                return default;
            }

            return GetMax(Root);
        }
        public BinarySearchTreeNode<T>? GetMin()
        {
            if (Root is null)
            {
                return default;
            }

            return GetMin(Root);
        }

        public ICollection<T> GetKeysInOrder() => GetKeysInOrder(Root);
        public ICollection<T> GetKeysPreOrder() => GetKeysPreOrder(Root);
        public ICollection<T> GetKeysPostOrder() => GetKeysPostOrder(Root);

        /// <summary>
        ///     向二叉搜索树插入新节点
        /// </summary>
        /// <param name="curNode">当前节点</param>
        /// <param name="data">新节点数据</param>
        /// <exception cref="ArgumentException"></exception>
        private void Add(BinarySearchTreeNode<T> curNode, T data)
        {
            var compareResult = comparer.Compare(curNode.Data, data);

            if (compareResult > 0)
            {
                if (curNode.Left is not null)
                {
                    Add(curNode.Left, data);
                }
                else
                {
                    var newNode = new BinarySearchTreeNode<T>(data);
                    curNode.Left = newNode;
                }
            }
            else if (compareResult < 0)
            {
                if (curNode.Right is not null)
                {
                    Add(curNode.Right, data);
                }
                else
                {
                    var newNode = new BinarySearchTreeNode<T>(data);
                    curNode.Right = newNode;
                }
            }
            else
            {
                throw new ArgumentException($"Data \"{data}\" already exists in tree!");
            }
        }

        /// <summary>
        ///     删除二叉树的节点
        /// </summary>
        /// <param name="parent">当前节点父亲</param>
        /// <param name="node">当前节点</param>
        /// <param name="data">要删除的节点数据</param>
        /// <returns>返回是否删除节点</returns>
        /// <remarks>
        ///     删除节点的3种情况：
        ///     <br></br>
        ///     1.当前节点没有孩子，直接删除
        ///     <br></br>
        ///     2.当前节点只有一个孩子，直接让子节点替代当前节点
        ///     <br></br>
        ///     3.当前节点左右孩子都有，我们在这里去找到右子树的最小节点
        ///     然后让删除该节点，并且让该节点替代掉当前节点
        ///     <br></br>
        ///     第1、2种情况可以合并
        /// </remarks>
        private bool Remove(BinarySearchTreeNode<T>? parent, BinarySearchTreeNode<T>? node, T data)
        {
            if (node is null || parent is null)
            {
                return false;
            }

            var compareResult = comparer.Compare(node.Data, data);

            if (compareResult > 0)
            {
                return Remove(node, node.Left, data);
            }

            if (compareResult < 0)
            {
                return Remove(node, node.Right, data);
            }

            BinarySearchTreeNode<T>? replacementNode;

            if (node.Left is null || node.Right is null)
            {
                replacementNode = node.Left ?? node.Right;
            }

            else
            {
                var tempNode = GetMin(node.Right);
                Remove(Root, Root, tempNode.Data);
                replacementNode = new BinarySearchTreeNode<T>(tempNode.Data)
                {
                    Left = node.Left,
                    Right = node.Right,
                };
            }

            if (node == Root)
            {
                Root = replacementNode;
            }
            else if (parent.Left == node)
            {
                parent.Left = replacementNode;
            }
            else
            {
                parent.Right = replacementNode;
            }

            return true;
        }

        private BinarySearchTreeNode<T> GetMax(BinarySearchTreeNode<T> node)
        {
            if (node.Right is null)
            {
                return node;
            }

            return GetMax(node.Right);
        }

        private BinarySearchTreeNode<T> GetMin(BinarySearchTreeNode<T> node)
        {
            if (node.Left is null)
            {
                return node;
            }

            return GetMin(node.Left);
        }

        private BinarySearchTreeNode<T>? Search(BinarySearchTreeNode<T>? node, T data)
        {
            if (node is null)
            {
                return default;
            }

            var compareResult = comparer.Compare(node.Data, data);
            if (compareResult > 0)
            {
                return Search(node.Left, data);
            }

            if (compareResult < 0)
            {
                return Search(node.Right, data);
            }

            return node;
        }

        private IList<T> GetKeysInOrder(BinarySearchTreeNode<T>? node)
        {
            if (node is null)
            {
                return new List<T>();
            }

            var result = new List<T>();
            result.AddRange(GetKeysInOrder(node.Left));
            result.Add(node.Data);
            result.AddRange(GetKeysInOrder(node.Right));
            return result;
        }
        private IList<T> GetKeysPreOrder(BinarySearchTreeNode<T>? node)
        {
            if (node is null)
            {
                return new List<T>();
            }

            var result = new List<T>();
            result.Add(node.Data);
            result.AddRange(GetKeysPreOrder(node.Left));
            result.AddRange(GetKeysPreOrder(node.Right));
            return result;
        }
        private IList<T> GetKeysPostOrder(BinarySearchTreeNode<T>? node)
        {
            if (node is null)
            {
                return new List<T>();
            }

            var result = new List<T>();
            result.AddRange(GetKeysPostOrder(node.Left));
            result.AddRange(GetKeysPostOrder(node.Right));
            result.Add(node.Data);
            return result;
        }
    }
}
