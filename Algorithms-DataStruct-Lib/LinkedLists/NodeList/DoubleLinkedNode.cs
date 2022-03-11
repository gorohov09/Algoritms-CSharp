using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_DataStruct_Lib
{
    public class DoubleLinkedNode<T>
    {
        public DoubleLinkedNode<T> Next { get; set; } //Указатель на следующий узел

        public DoubleLinkedNode<T> Prev { get; set; } //Указатель на предыдущий узел

        public T Value { get; set; }

        public DoubleLinkedNode(T value)
        {
            Value = value;
        }
    }
}
