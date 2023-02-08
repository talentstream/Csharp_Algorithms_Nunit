using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList.SinglyLinkedList
{
    /// <summary>
    ///     单链表
    /// </summary>
    /// <remarks>
    ///     提供的API ：
    ///     <list type="bullet">
    ///         <item>AddFirst</item>
    ///         <item>AddLast</item>
    ///         <item>GetElementByIndex</item>
    ///         <item>GetListData</item>
    ///         <item>Length</item>
    ///         <item>DeleteElement</item>
    ///     </list>
    /// </remarks>
    /// <typeparam name="T"></typeparam>
    public class SinglyLinkedList<T>
    {
        private SinglyLinkedListNode<T>? Head { get; set; }

        /// <summary>
        ///     添加节点到链表头
        ///     时间复杂度 O(1)
        /// </summary>
        /// <param name="data">节点所带的数据</param>
        /// <returns>返回一个新节点</returns>
        public SinglyLinkedListNode<T> AddFirst(T data)
        {
            var newListElement = new SinglyLinkedListNode<T>(data)
            {
                Next = Head,
            };

            Head = newListElement;
            return newListElement;
        }

        /// <summary>
        ///     添加节点到链表尾
        ///     时间复杂度 O(n)
        /// </summary>
        /// <param name="data">节点所带的数据</param>
        /// <returns>返回一个新节点</returns>
        public SinglyLinkedListNode<T> AddLast(T data)
        {
            var newListElement = new SinglyLinkedListNode<T>(data);

            if(Head is null)
            {
                Head = newListElement;
                return newListElement;
            }

            var tempElement = Head;

            while(tempElement.Next is not null)
            {
                tempElement = tempElement.Next;
            }

            tempElement.Next = newListElement;
            return newListElement;
        }

        /// <summary>
        ///     在链表中根据位置返回节点数据
        /// </summary>
        /// <param name="index">节点所带的数据</param>
        /// <returns>节点数据</returns>
        /// <exception cref="ArgumentOutOfRangeException">防止index越界</exception>
        public T GetElementByIndex(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            var tempElement = Head;

            for (var i = 0; tempElement is not null && i < index; i++)
            {
                tempElement = tempElement.Next;
            }

            if (tempElement is null)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            return tempElement.Data;
        }

        /// <summary>
        ///     返回链表长度
        /// </summary>
        /// <returns>链表长度</returns>
        public int Length()
        {
            if(Head is null)
            {
                return 0;
            }

            var tempElement = Head;
            var length = 1;

            while(tempElement.Next is not null)
            {
                tempElement = tempElement.Next;
                length++;
            }

            return length;
        }

        /// <summary>
        ///     返回链表数据
        /// </summary>
        /// <returns>返回可枚举类型</returns>
        public IEnumerable<T> GetListData()
        {
            var tempElement = Head;

            while (tempElement is not null)
            {
                yield return tempElement.Data;
                tempElement = tempElement.Next;
            }
        }

        /// <summary>
        ///     删除链表节点
        /// </summary>
        /// <param name="element">节点数据</param>
        /// <returns>返回bool型：是否删除了元素</returns>
        public bool DeleteElement(T element)
        {
            var currentElement = Head;
            SinglyLinkedListNode<T>? previousElement = null;

            while(currentElement is not null)
            {
                if(currentElement.Data is null && element is null ||
                    currentElement.Data is not null && currentElement.Data.Equals(element))
                {
                    if(currentElement.Equals(Head))
                    {
                        Head = Head.Next;
                        return true;
                    }
                    if(previousElement is not null)
                    {
                        previousElement.Next = currentElement.Next;
                        return true;
                    }
                }

                previousElement = currentElement;
                currentElement = currentElement.Next;
            }

            return false;
        }
    }
}
