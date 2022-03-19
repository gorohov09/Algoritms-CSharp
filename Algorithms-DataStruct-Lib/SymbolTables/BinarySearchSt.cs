using Algorithms_DataStruct_Lib.Queues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_DataStruct_Lib.SymbolTables
{
    public class BinarySearchSt<TKey, TValue>
    {
        private TKey[] _keys; //Массив для хранения ключей(отсортированный)

        private TValue[] _values; //Массив для хранения значений

        public int Count { get; private set; } //Колличество элементов

        private readonly IComparer<TKey> _comparer; //Для сравнения между собой ключей

        public int Capacity => _keys.Length; //Длина массива

        private const int DefaultCapacity = 4; //Емкость по умолчанию = 4

        public bool IsEmpty { get { return Count == 0; } } 

        public BinarySearchSt(int capacity, IComparer<TKey> comparer)
        {
            _keys = new TKey[capacity];
            _values = new TValue[capacity];
            _comparer = comparer ?? throw new ArgumentNullException("Comparer can't be null");
        }

        public BinarySearchSt(int capacity)
            : this(capacity, Comparer<TKey>.Default)
        {
        }

        public BinarySearchSt()
            : this (DefaultCapacity)
        {
        }

        public int Rank(TKey key) //Определяет колличество ключей, меньших, чем запрошенный
        {
            int low = 0; //Нижняя граница
            int high = Count - 1; //Верхняя граница

            while (low <= high)
            {
                int mid = low + (high - low) / 2; //Индекс срединного элемента

                int cmp = _comparer.Compare(key, _keys[mid]); //Сравнение ключей

                if (cmp < 0)
                    high = mid - 1;
                else if (cmp > 0)
                    low = mid + 1;
                else
                    return mid;
            }

            return low;
        }

        public TValue GetValueOrDefault(TKey key)
        {
            if (IsEmpty)
            {
                return default(TValue);
            }

            int rank = Rank(key); //Вычисляем ранк запрошенного ключа
            if (rank < Count && _comparer.Compare(_keys[rank], key) == 0) //Если ключ нашли
            {
                return _values[rank];
            }
            
            return default(TValue);
        }

        public void Add(TKey key, TValue value)
        {
            if (key == null)
                throw new ArgumentNullException("Key can't be null");

            int rank = Rank(key);
            if (rank < Count && _comparer.Compare(_keys[rank], key) == 0) //Если такой существует
            {
                _values[rank] = value; //Обновляем значение
                return;
            }

            if (Count == Capacity) //Если колличество элементов равно размеру массива
                Resize(Capacity * 2); //Увеличиваем массив

            for (int j = Count; j > rank; j--)
            {
                _keys[j] = _keys[j - 1]; //Сдвигаем элементы
                _values[j] = _values[j - 1]; //Сдвигаем элементы
            }
            _keys[rank] = key; //Вставляем ключ
            _values[rank] = value; //Вставляем значение
            Count++; //Увеличиваем Count
        }

        public void Remove(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("Key can't be null");

            if (IsEmpty)
                return;

            int r = Rank(key);

            if (r == Count || _comparer.Compare(_keys[r], key) != 0) //Если не нашли ключ
                return;

            for (int j = r; j < Count - 1; j++)
            {
                _keys[j] = _keys[j + 1]; //Сдвигаем справа налево
                _values[j] = _values[j + 1]; //Сдвигаем справа налево
            }
            Count--;
            _keys[Count] = default(TKey);
            _values[Count] = default(TValue);
        }

        public bool Contains(TKey key)
        {
            int r = Rank(key);

            if (r < Count && _comparer.Compare(_keys[r], key) == 0)
                return true;
            return false;
        }

        public IEnumerable<TKey> Keys()
        {
            foreach (var key in _keys)
            {
                yield return key;
            }
        }

        private void Resize(int Capacity)
        {
            TKey[] newKeys = new TKey[Capacity];
            TValue[] newValues = new TValue[Capacity];

            for (int i = 0; i < Count; i++)
            {
                newKeys[i] = _keys[i];
                newValues[i] = _values[i];
            }

            _keys = newKeys;
            _values = newValues;
        }

        public TKey Min()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Table is Empty");

            return _keys[0];
        }

        public TKey Max()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Table is Empty");

            return _keys[Count - 1];
        }

        public void RemoveMin()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Table is Empty");

            TKey key = Min();
            Remove(key);
        }

        public void RemoveMax()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Table is Empty");

            TKey key = Max();
            Remove(key);
        }

        public TKey Floor(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("Key can't be null");

            int rank = Rank(key);
            if (rank < Count && _comparer.Compare(_keys[rank], key) == 0)
            {
                return key;
            }
            else if (_comparer.Compare(key, Max()) == 1)
            {
                return Max();
            }
            else
            {
                return default(TKey);
            }
        }

        public TKey Ceiling(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("Key can't be null");

            int rank = Rank(key);

            if (rank < Count && _comparer.Compare(_keys[rank], key) == 0)
            {
                return key;
            }
            else if (_comparer.Compare(key, Min()) == -1)
            {
                return Min();
            }
            else
            {
                return default(TKey);
            }
        }

        public TKey Select(int r)
        {
            if (r < 0 || r >= Count)
                throw new ArgumentException();

            return _keys[r];
        }

        public IEnumerable<TKey> Range(TKey a, TKey b)
        {
            if (a == null || b == null)
                throw new ArgumentNullException("Key can't be null");

            var q = new LinkedQueue<TKey>();

            int r1 = Rank(a);
            int r2 = Rank(b);

            for (int i = r1; i < r2; i++)
            {
                q.Enqueue(_keys[i]);
            }

            if (Contains(b))
                q.Enqueue(_keys[r2]);

            return q;
            
        }
    }
}
