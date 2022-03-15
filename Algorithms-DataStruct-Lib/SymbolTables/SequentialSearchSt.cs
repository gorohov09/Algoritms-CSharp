using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_DataStruct_Lib.SymbolTables
{
    public class SequentialSearchSt<TKey, TValue>
    {
        private class Node
        {
            public TKey Key { get; }

            public TValue Value { get; set; }

            public Node Next { get; set; }

            public Node(TKey key, TValue value, Node next)
            {
                Key = key;
                Value = value;
                Next = next;
            }
        }

        private Node _first;

        private readonly EqualityComparer<TKey> _comparer;

        public int Count { get; private set; }

        public bool IsEmpty
        {
            get { return Count == 0; }
        }

        public SequentialSearchSt()
        {
            _comparer = EqualityComparer<TKey>.Default;
        }

        public SequentialSearchSt(EqualityComparer<TKey> comparer)
        {
            _comparer = comparer ?? throw new ArgumentNullException();
        }

        public bool TryGet(TKey key, out TValue val)
        {
            for (Node x = _first; x != null; x = x.Next)
            {
                if (_comparer.Equals(x.Key, key))
                {
                    val = x.Value;
                    return true;
                }
            }

            val = default(TValue);
            return false;
        }

        public void Add(TKey key, TValue val)
        {
            if (key is null)
                throw new ArgumentNullException("Key can't be null");

            for (Node x = _first; x != null; x = x.Next)
            {
                if (_comparer.Equals(x.Key, key))
                {
                    x.Value = val;
                    return;
                }
            }

            _first = new Node(key, val, _first);

            Count++;
        }

        public bool Contains(TKey key)
        {
            for (Node x = _first; x != null; x = x.Next)
            {
                if (_comparer.Equals(x.Key, key))
                {
                    return true;
                }
            }

            return false;
        }

        public IEnumerable<TKey> Keys()
        {
            for (Node x = _first; x != null; x = x.Next)
            {
                yield return x.Key;
            }
        }

        public bool Remove(TKey key)
        {
            if (key is null)
                throw new ArgumentNullException("Key can't be null");

            if ((Count == 1) && (_comparer.Equals(key, _first.Key)))
            {
                _first = null;
                Count = 0;
                return true;
            }
            else
            {
                Node prev = null; //Предыдущий узел
                for (Node x = _first; x != null; x = x.Next)
                {
                    if (_comparer.Equals(x.Key, key))
                    {
                        if (x == _first)
                        {
                            _first = x.Next;
                        }
                        else
                        {
                            prev.Next = x.Next;
                        }
                        Count--;
                        return true;
                    }
                    prev = x;
                }

                return false;
            }

        }
    }
}
