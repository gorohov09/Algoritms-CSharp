using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_DataStruct_Lib
{
    public class ArrayStack<T> : IEnumerable<T>
    {
        private T[] _items;
        private const int defaultCapacity = 4;

        public int Count { get; private set; }

        public bool IsEmpty { get { return Count == 0; } }

        public ArrayStack()
        {
            _items = new T[defaultCapacity];
        }

        public ArrayStack(int Capacity)
        {
            _items = new T[Capacity];
        }

        public void Push(T item)
        {
            if (_items.Length == Count)
            {
                Resize(Count);
            }
            _items[Count++] = item;
        }

        public void Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Стек пустой");

            _items[--Count] = default(T);
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Стек пустой");

            return _items[Count - 1];
        }

        private void Resize(int n)
        {
            T[] newArray = new T[n * 2];

            for (int i = 0; i < _items.Length; i++)
            {
                newArray[i] = _items[i];
            }

            _items = newArray;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
