using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_DataStruct_Lib
{
    public class DoubleLinkedList<T> : IEnumerable<T>
    {
        public DoubleLinkedNode<T> Head { get; set; }

        public DoubleLinkedNode<T> Tail { get; set; }

        public int Count { get; private set; }

        public bool IsEmpty { get { return Count == 0; } }

        public void AddFirst(T value)
        {
            DoubleLinkedNode<T> node = new DoubleLinkedNode<T>(value);
            AddFirst(node);
        }
        
        private void AddFirst(DoubleLinkedNode<T> node)
        {
            node.Next = Head;

            if (IsEmpty)
            {
                Tail = node;
            }
            else
            {
                Head.Prev = node;
            }

            Head = node;

            Count++;
        }

        public void AddLast(T value)
        {
            AddLast(new DoubleLinkedNode<T>(value));
        }

        private void AddLast(DoubleLinkedNode<T> node)
        {
            if (IsEmpty)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                Tail.Next = node;
                node.Prev = Tail;
                Tail = node;
            }
            Count++;
        }

        public void RemoveFirst()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Список пустой");

            Head = Head.Next;

            Count--;

            if (IsEmpty)
                Tail = null;
            else
                Head.Prev = null;
        }

        public void RemoveLast()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Список пустой");

            if (Count == 1)
            {
                Head = null;
                Tail = null;
            }
            {
                Tail.Prev.Next = null;
                Tail = Tail.Prev;
            }
            Count--;
        }

        public void Remove(T value)
        {
            if (IsEmpty)
                throw new InvalidOperationException("Список пустой");

            DoubleLinkedNode<T> Current = Head;
            DoubleLinkedNode<T> tmp = null;
            while (Current != null)
            {
                if (Current.Value.Equals(value))
                {
                    tmp = Current; break;
                }

                Current = Current.Next;
            }

            if (tmp == null)
            {
                Console.WriteLine("Элемент не найден");
                return;
            }
            else
            {
                if (tmp.Prev is null)
                {
                    RemoveFirst();
                    return;
                }  
                else if (tmp.Next is null)
                {
                    RemoveLast();
                    return;
                }
                    
                else
                {
                    tmp.Prev.Next = tmp.Next;
                    tmp.Next.Prev = tmp.Prev;
                    tmp.Next = null;
                    tmp.Prev = null;
                }
            }
            Count--;
        }

        public bool Contains(T value)
        {
            DoubleLinkedNode<T> Current = Head;
            while (Current != null)
            {
                if (Current.Value.Equals(value))
                    return true;
                Current = Current.Next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            DoubleLinkedNode<T> Current = Head;
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

        public IEnumerable<T> BackEnumenator()
        {
            DoubleLinkedNode<T> Currnet = Tail;
            while (Currnet != null)
            {
                yield return Currnet.Value;
                Currnet = Currnet.Prev;
            }
        }
    }
}
