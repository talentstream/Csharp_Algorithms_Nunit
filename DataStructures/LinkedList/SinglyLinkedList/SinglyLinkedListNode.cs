using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList.SinglyLinkedList
{
    public class SinglyLinkedListNode<T>
    {
        public T Data { get; }
        public SinglyLinkedListNode<T>? Next { get; set; }

        public SinglyLinkedListNode(T data)
        {
            Data = data;
            Next = null;
        }
    }
}
