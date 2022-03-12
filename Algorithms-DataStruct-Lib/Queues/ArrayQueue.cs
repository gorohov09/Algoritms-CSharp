using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_DataStruct_Lib.Queues
{
    public class ArrayQueue<T> : IEnumerable<T>
    {
        private T[] _queue;

        private int _head;

        private int _tail;

        private const int defaultCapacity = 4;

        public int Count { get { return _tail - _head; } }

        public bool IsEmpty { get { return Count == 0; } }

        public ArrayQueue()
        {
            _queue = new T[defaultCapacity];
        }

        public ArrayQueue(int Capacity)
        {
            _queue = new T[Capacity];
        }

        public void Enqueue(T item)
        {
            if (_queue.Length == _tail)
            {
                T[] largeArray = new T[Count * 2];

                for (int i = 0; i < Count; i++)
                    largeArray[i] = _queue[i];

                _queue = largeArray;
            }
            _queue[_tail++] = item;
        }

        public void Dequeue()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Очередь пуста");

            _queue[_head++] = default(T);

            if (IsEmpty)
                _head = _tail = 0;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Очередь пуста");

            return _queue[_head];
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _head; i < _tail; i++)
                yield return _queue[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
