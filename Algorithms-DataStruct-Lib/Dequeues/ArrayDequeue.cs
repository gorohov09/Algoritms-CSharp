using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_DataStruct_Lib.Dequeues
{
    public class ArrayDequeue<T> : IEnumerable<T>
    {
        private T[] _dequeue; //Массив, в котором хранятся элементы дэка

        private int _head; //Индекс головного элемента

        private int _tail; //Индекс хвостового элемента

        private const int DefaultCapacity = 4;

        public int Count { get; private set; } //Колличество элементов дэка

        public bool IsEmpty => Count == 0;

        public bool IsFull => Count == Capacity;

        public int Capacity { get { return _dequeue.Length; } } //Размер массива _dequeue(емкость дэка)

        public ArrayDequeue(int capacity)
        {
            _dequeue = new T[capacity];
            Count = 0;
            _head = -1;
            _tail = -1;
        }

        public ArrayDequeue()
            : this(DefaultCapacity)
        {
        }

        public void Push_Back(T elem)
        {
            if (Count == Capacity)
                Resize(Capacity * 2);

            if (Count == 0)
            {
                _tail = 0;
                _head = 0;
            }
            else
            {
                if (++_tail == Capacity)
                    _tail = 0;
            }

            _dequeue[_tail] = elem;
            Count++;
        }

        public void Push_Front(T elem)
        {
            if (Count == Capacity)
                Resize(Capacity * 2);

            if (Count == 0)
            {
                _tail = 0;
                _head = 0;
            }
            else
            {
                if (--(_head) < 0)
                    _head = Capacity - 1;
            }

            _dequeue[_head] = elem;
            Count++;
        }

        public T Pop_Back()
        {
            int index = _tail;

            if (Count == 1)
                _head = _tail = -1;
            else
            {
                if (--(_tail) < 0)
                    _tail = Capacity - 1;
            }
            Count--;
            return _dequeue[index];
        }

        public T Pop_Front()
        {
            int index = _head;

            if (Count == 1)
                _head = _tail = -1;
            else
            {
                if (++_head == Capacity)
                    _head = 0;
            }
            Count--;
            return _dequeue[index];
        }

        public T Peek_Front()
        {
            return _dequeue[_head];
        }

        public T Peek_Back()
        {
            return _dequeue[_tail];
        }

        private void Resize(int capacity)
        {
            int countPriorSize = Count;
            T[] newArray = new T[capacity];

            if (_head <= _tail)
            {
                for (int i = _head; i < _tail; i++)
                    newArray[i] = _dequeue[i];
            }
            else
            {
                int index = 0;

                for (int i = _head; i < _dequeue.Length; i++)
                    newArray[index++] = _dequeue[i];

                for (int i = 0; i < _tail; i++)
                    newArray[index++] = _dequeue[i];
            }

            _dequeue = newArray;
            _head = 0;
            _tail = countPriorSize - 1;

        }

        public IEnumerator<T> GetEnumerator()
        {
            if (_head <= _tail)
            {
                for (int i = _head; i <= _tail; i++)
                    yield return _dequeue[i];
            }
            else
            {
                for (int i = _head; i < _dequeue.Length; i++)
                    yield return _dequeue[i];

                for (int i = 0; i <= _tail; i++)
                    yield return _dequeue[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
