using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_DataStruct_Lib
{
    public class SinglyLinkedList<T>
    {
        public Node<T> Head { get; set; } //Ссылка на начало узла

        public Node<T> Tail { get; set; } //Ссылка на конец узла

        public int Count { get; set; }

        public void AddFirst(T value)
        {
            Node<T> node = new Node<T>(value);
            AddFirst(node);
        }

        private void AddFirst(Node<T> node)
        {
            Node<T> tmp = Head;

            Head = node;

            Head.Next = tmp;

            Count++;

            if (Count == 1)
                Tail = Head;
        }

        public void AddLast(T value)
        {
            Node<T> node = new Node<T>(value);
            AddLast(node);
        }

        private void AddLast(Node<T> node)
        {
            if (Count == 0)
                Head = node;
            else
                Tail.Next = node; 

            Tail = node;
            Count++;
        }

        public void RemoveFirst()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Список пустой");

            Head = Head.Next;

            if (Count == 1)
                Tail = null;
            
            Count--;
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
            else
            {
                Node<T> Current = Head;

                while (Current.Next != Tail)
                    Current = Current.Next;

                Current.Next = null;
                Tail = Current;
            }
            Count--;

        }

        public bool IsEmpty => Count == 0;
    }
}
