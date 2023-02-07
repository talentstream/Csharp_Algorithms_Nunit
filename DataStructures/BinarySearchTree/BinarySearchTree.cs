using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.BinarySearchTree
{
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
