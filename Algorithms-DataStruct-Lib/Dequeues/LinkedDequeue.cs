using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_DataStruct_Lib.Dequeues
{
    public class LinkedDequeue<T> : IEnumerable<T>
    {
        private DoubleLinkedNode<T> _head;

        private DoubleLinkedNode<T> _tail;

        public int Count { get; private set; }

        public bool IsEmpty { get { return Count == 0; } }

        public void Push_Back(T elem)
        {
            if (elem is null)
                throw new ArgumentNullException("Elem is null");

            DoubleLinkedNode<T> node = new DoubleLinkedNode<T>(elem);

            if (Count == 0)
            {
                _head = node;
            }
            else
            {
                _tail.Next = node;
                node.Prev = _tail;
            }
            _tail = node;
            Count++;
        }

        public void Push_Front(T elem)
        {
            if (elem is null)
                throw new ArgumentNullException("Elem is null");

            DoubleLinkedNode<T> node = new DoubleLinkedNode<T>(elem);

            if (Count == 0)
            {
                _tail = node;
            }
            else
            {
                node.Next = _head;
                _head.Prev = node;
            }
            _head = node;
            Count++;
        }

        public T Pop_Back()
        {
            if (Count == 0)
                throw new InvalidOperationException();

            DoubleLinkedNode<T> temp = _tail;

            if (Count == 1)
            {
                _head = _tail = null;
            }
            else
            {
                _tail.Prev.Next = null;
                _tail = _tail.Prev;
            }
            Count--;
            return temp.Value;
        }

        public T Pop_Front()
        {
            if (Count == 0)
                throw new InvalidOperationException();

            DoubleLinkedNode<T> temp = _head;

            if (Count == 1)
            {
                _head = _tail = null;
            }
            else
            {
                _head.Next.Prev = null;
                _head = _head.Next;
            }
            Count--;
            return temp.Value;
        }

        public T Peek_Front()
        {
            if (IsEmpty)
                throw new InvalidOperationException();

            return _head.Value;
        }

        public T Peek_Back()
        {
            if (IsEmpty)
                throw new InvalidOperationException();

            return _tail.Value;
        }

        public bool Contains(T elem)
        {
            for (DoubleLinkedNode<T> current = _head; current != null; current = current.Next)
            {
                if (current.Value.Equals(elem))
                    return true;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (DoubleLinkedNode<T> current = _head; current != null; current = current.Next)
            {
                yield return current.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
