using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_DataStruct_Lib.Trees
{
    public class MaxHeap<T>
        where T : IComparable<T>
    {
        private const int DefaultCapacity = 4;

        private T[] _heap;

        public int Count { get; private set; } //Индекс первого пустого слота в массиве

        public bool IsEmpty => Count == 0;

        public bool IsFull => Count == _heap.Length;

        public MaxHeap(int capacity)
        {
            _heap = new T[capacity];
            Count = 0;
        }

        public MaxHeap()
            :this(DefaultCapacity)
        {
        }

        public void Insert(T value)
        {
            if (IsFull)
            {
                var newHeap = new T[_heap.Length * 2];
                Array.Copy(_heap, 0, newHeap, 0, _heap.Length);
                _heap = newHeap;
            }
            _heap[Count] = value;
            Swim(Count); //Восстановление пирамиды
            Count++;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException();

            return _heap[0];
        }

        public T Remove()
        {
            return Remove(0);
        }

        public T Remove(int index)
        {
            if (IsEmpty)
                throw new InvalidOperationException();

            T removedValue = _heap[index];
            _heap[index] = _heap[Count - 1];

            if (index == 0 || (_heap[index].CompareTo(GetParent(index)) < 0))
            {
                Sink(index);
            }
            else
            {
                Swim(index);
            }
            Count--;
            return removedValue;
        }

        public IEnumerable<T> Values()
        {
            for (int i = 0; i < Count; i++)
                yield return _heap[i];
        }

        private void Sink(int indexOfSinkingItem)
        {
            int lastHeapIndex = Count - 1;

            while (indexOfSinkingItem <= lastHeapIndex)
            {
                int leftChildIndex = LeftChildIndex(indexOfSinkingItem);
                int rightChildIndex = RightChildIndex(indexOfSinkingItem);

                if (leftChildIndex > lastHeapIndex)
                    break;

                int childIndexToSwap = GetChildIndexToSwap(leftChildIndex, rightChildIndex);

                if (SinkingIsLessThan(childIndexToSwap))
                {
                    Exchange(indexOfSinkingItem, childIndexToSwap);
                }
                else
                    break;

                indexOfSinkingItem = childIndexToSwap;
            }

            int GetChildIndexToSwap(int left, int right)
            {
                int childToSwap;
                if (right > lastHeapIndex)
                    childToSwap = left;
                else
                {
                    if (_heap[left].CompareTo(_heap[right]) > 0)
                        return left;
                    else
                        return right;
                }

                return childToSwap;
            }

            bool SinkingIsLessThan(int index)
            {
                return _heap[indexOfSinkingItem].CompareTo(_heap[index]) < 0;
            }

            void Exchange(int left, int right)
            {
                T tmp = _heap[left];
                _heap[left] = _heap[right];
                _heap[right] = tmp;
            }
        }

        private void Swim(int indexOfSwimmingItem)
        {
            T newValue = _heap[indexOfSwimmingItem];

            while (indexOfSwimmingItem > 0 && IsParentLess(indexOfSwimmingItem))
            {
                _heap[indexOfSwimmingItem] = GetParent(indexOfSwimmingItem);
                indexOfSwimmingItem = ParentIndex(indexOfSwimmingItem);
            }

            _heap[indexOfSwimmingItem] = newValue;

            bool IsParentLess(int swimmingItemIndex)
            {
                return newValue.CompareTo(GetParent(swimmingItemIndex)) > 0;
            }
        }

        private T GetParent(int index)
        {
            return _heap[ParentIndex(index)];
        }

        private int ParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        private int LeftChildIndex(int index)
        {
            return 2 * index + 1;
        }

        private int RightChildIndex(int index)
        {
            return 2 * index + 2;
        }

        
    }
}
