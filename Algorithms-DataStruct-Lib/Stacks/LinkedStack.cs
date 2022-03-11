using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_DataStruct_Lib.Stack
{
    public class LinkedStack<T> : IEnumerable<T>
    {
        public Node<T> Head { get; set; }

        public int Count { get; set; }

        public bool IsEmpty { get { return Count == 0; } }

        public void Push(T item)
        {
            Node<T> node = new Node<T>(item);
            node.Next = Head;
            Head = node;
            Count++;
        }

        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Стек пустой");

            T result = Head.Value;

            Head = Head.Next;
            Count--;
            return result;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Стек пустой");

            return Head.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> Current = Head;
            while (Current != null)
            {
                yield return Current.Value;
                Current = Current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
