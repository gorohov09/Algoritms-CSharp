using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_DataStruct_Lib.Queues
{
    public class LinkedQueue<T> : IEnumerable<T>
    {
        private Node<T> _Head;

        private Node<T> _Tail;

        public int Count { get; private set; }

        public bool IsEmpty { get { return Count == 0; } }

        public void Enqueue(T item) //AddLast in LinkedList
        {
            Node<T> node = new Node<T>(item);

            if (IsEmpty)
                _Head = node;
            else
                _Tail.Next = node;

            _Tail = node;
            Count++;
        }

        public void Dequeue() //RemoveFirst in LinkedList
        {
            if (IsEmpty)
                throw new InvalidOperationException("Очередь пуста");

            if (Count == 1)
            {
                _Head = null;
                _Tail = null;
            }
            else
                _Head = _Head.Next;
            Count--;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Очередь пуста");

            return _Head.Value;
        }

        public void Clear()
        {
            _Head = null;
            _Tail = null;
            Count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> Current = _Head;
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
