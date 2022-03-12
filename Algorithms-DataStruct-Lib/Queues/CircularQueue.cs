using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_DataStruct_Lib.Queues
{
    public class CircularQueue<T> : IEnumerable<T>
    {
        private T[] _queue;

        private int _head;
        private int _tail;

        private const int defaultCapacity = 4;

        public int Count
        {
            get
            {
                return _head <= _tail 
                    ? _tail - _head 
                    : _tail - _head + _queue.Length;
            }
        }

        public int Capacity {  get { return _queue.Length; } }

        public bool IsEmpty { get { return Count == 0; } }

        public CircularQueue()
        {
            _queue = new T[defaultCapacity];
        }

        public CircularQueue(int Capacity)
        {
            _queue = new T[Capacity];
        }

        public void Enqueue(T item)
        {
            if (Count == _queue.Length - 1) //Кол-во элементов близко подходит к длине массива, то увеличиваем массив
            {
                int countPriorResize = Count; //Сохраняем текущий размер массива
                T[] newArray = new T[2 * _queue.Length];

                if (_head <= _tail)
                {
                    for (int i = _head; i < _tail; i++)
                        newArray[i] = _queue[i];
                }
                else
                {
                    int index = 0;

                    for (int i = _head; i < _queue.Length; i++)
                        newArray[index++] = _queue[i];

                    for (int i = 0; i < _tail; i++)
                        newArray[index++] = _queue[i];
                }

                _queue = newArray;

                _head = 0;
                _tail = countPriorResize;
            }
            _queue[_tail] = item;

            if (_tail < _queue.Length - 1)
            {
                _tail++;
            }
            else
                _tail = 0;
        }

        public void Dequeue()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Очередь пуста");
            _queue[_head++] = default(T);

            if (IsEmpty)
            {
                _head = 0;
                _tail = 0;
            }
            else if (_head == _queue.Length)
                _head = 0;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Очередь пуста");

            return _queue[_head];
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (_head <= _tail)
            {
                for (int i = _head; i < _tail; i++)
                    yield return _queue[i];
            }
            else
            {
                for (int i = _head; i < _queue.Length; i++)
                    yield return _queue[i];

                for (int i = 0; i < _tail; i++)
                    yield return _queue[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
