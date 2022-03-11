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
        private readonly SinglyLinkedList<T> _list = new SinglyLinkedList<T>();

        public void Push(T item)
        {
            _list.AddFirst(item);
            Count++;
        }

        public void Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Стек пустой");

            _list.RemoveFirst();
            Count--;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Стек пустой");

            return _list.Head.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool IsEmpty { get { return Count == 0; } }

        public int Count { get; private set; }
    }
}
