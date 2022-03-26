using Algorithms_DataStruct_Lib.Queues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_DataStruct_Lib.SymbolTables
{
    public class ChainHashSet<Tkey, TValue> //Шаблонный класс
    {
        private SequentialSearchSt<Tkey, TValue>[] _chains; //Массив цепочек

        private const int DefaultCapacity = 4;

        public int Count { get; private set; } //Колличество элементов

        public int Capacity { get; private set; } //Размер массива цепочек

        public ChainHashSet(int capacity)
        {
            Capacity = capacity;
            _chains = new SequentialSearchSt<Tkey, TValue>[Capacity]; //Инициализация массива

            for (int i = 0; i < Capacity; i++)
            {
                _chains[i] = new SequentialSearchSt<Tkey, TValue>(); //Инициализация цепочек
            }
        }

        public ChainHashSet()
        {
            Capacity = DefaultCapacity;
            _chains = new SequentialSearchSt<Tkey, TValue>[DefaultCapacity];          

            for (int i = 0; i < Capacity; i++)
            {
                _chains[i] = new SequentialSearchSt<Tkey, TValue>();
            }
        }

        /// <summary>
        /// Функция хеширования
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private int Hash(Tkey key)
        {
            //Битовая маска, чтобы избежать отрицательных ключей
            return (key.GetHashCode() & 0x7fffffff) % Capacity;
        }

        public TValue Get(Tkey key)
        {
            if (key is null)
                throw new ArgumentNullException("Key is not allowed to be null");

            int index = Hash(key); //Вычисляем индекс, по которому лежит ключ

            //Используя индекс, получаем доступ к необходимой цепочке и получаем значение
            #region Под копотом функции TryGet
            //for (Node x = _first; x != null; x = x.Next)
            //{
            //    if (_comparer.Equals(x.Key, key))
            //    {
            //        val = x.Value;
            //        return true;
            //    }
            //}
            #endregion

            if (_chains[index].TryGet(key, out TValue val))
            {
                return val;
            }

            //Если ключ не найден - выбрасываем исключение
            throw new ArgumentException("Key was not found");
        }

        public bool Contains(Tkey key)
        {
            if (key is null)
                throw new ArgumentNullException("Key is not allowed to be null");

            int index = Hash(key);

            return _chains[index].Contains(key);
        }

        public bool Remove(Tkey key)
        {
            if (key is null)
                throw new ArgumentNullException("Key is not allowed to be null");

            int index = Hash(key);

            if (_chains[index].Contains(key)) //Если в цепочке есть ключ
            {
                _chains[index].Remove(key); //Удаляем пару по ключу
                Count--;

                //Сужение размерности массива
                if (Capacity > DefaultCapacity && Count <= 2 * Capacity)
                    Resize(Prime.ReducePrime(Capacity));

                return true;
            }

            return false;
        }

        public void Add(Tkey key, TValue val)
        {
            if (key is null)
                throw new ArgumentNullException("Key is not allowed to be null");

            if (val is null)
            {
                Remove(key);
                return;
            }

            //Когда средняя длина цепочек достигает 10 узлов и больше, удавиваем в размерах массив цепочек
            if (Count >= 10 * Capacity)
                Resize(Prime.ExpendPrime(Capacity));

            int i = Hash(key);

            if (!_chains[i].Contains(key)) //Если в цепочке нет такого ключа
                Count++; //Инкрементируем Count

            //Если ключ уже есть в цепочке, обновляем значение, а Count трогать не надо
            _chains[i].Add(key, val); //Добавляем пару ключ-значение по вычесленному индексу
        }

        private void Resize(int chains)
        {
            var temp = new ChainHashSet<Tkey, TValue>(chains); //Создаем больший массив цепочек

            //Копируем данные
            for (int i = 0; i < Capacity; i++) //Проход по текущей таблицы
            {
                foreach (var key in _chains[i].Keys()) //Извлекаем пары(ключ-значение) из цепочек
                {
                    if (_chains[i].TryGet(key, out TValue val))
                        temp.Add(key, val); //Добавляем пары во временный массив, большего размера
                }
            }

            Capacity = temp.Capacity;
            Count = temp.Count;
            _chains = temp._chains; //Перестанавливаем ссылку
        }

        public IEnumerable<Tkey> Keys()
        {
            var queue = new LinkedQueue<Tkey>(); //Создаем очередь ключей

            for (int i = 0; i < Capacity; i++) //Итерируем по массиву цепочек
            {
                foreach (var key in _chains[i].Keys())
                {
                    queue.Enqueue(key);
                }
            }

            return queue;
        }
    }
}
