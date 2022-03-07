using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_DataStruct_Lib
{
    public class Node<T>
    {
        /// <summary>
        /// Хранение данных
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Ссылка на объект своего типа(Указатель на следующий элемент)
        /// </summary>
        public Node<T> Next { get; set; }

        public Node(T value)
        {
            Value = value;
        }
    }
}
