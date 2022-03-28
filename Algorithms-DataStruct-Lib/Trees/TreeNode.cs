using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_DataStruct_Lib.Trees
{
    public class TreeNode<T>
        where T : IComparable<T> //Накладываем ограничение, тип T, обязан реализовывать интерфейс IComparable
    {
        public T Value { get; set; } //Хранимое значение узла

        public TreeNode<T> Left { get; set; } //Левый дочерний узел

        public TreeNode<T> Right { get; set; } //Правый дочерний узел

        public TreeNode(T value) 
        {
            Value = value;
        }

        /// <summary>
        /// Вставка
        /// </summary>
        /// <param name="newValue">Новое добавляемое значение</param>
        public void Insert(T newValue)
        {
            //Сравнение значения в текущем узле со значением, которое пытаемся добавить
            int compare = newValue.CompareTo(Value);

            if (compare == 0) //Если они равны
                return; //Такое значение игнорируем

            if (compare < 0) //Если значение меньше
            {
                if (Left is null)
                {
                    //На данный момент - в конце дерева, просто вставляем новый узел
                    Left = new TreeNode<T>(newValue);
                }
                else
                {
                    Left.Insert(newValue); //Спускаемся ниже по дереву(влево)
                }
            }
            else
            {
                if (Right is null)
                {
                    //На данный момент - в конце дерева, просто вставляем новый узел
                    Right = new TreeNode<T>(newValue);
                }
                else
                {
                    Right.Insert(newValue); //Спускаемся ниже по дереву(вправо)
                }
            }
        }

        /// <summary>
        /// Получение значения
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public TreeNode<T> Get(T value)
        {
            int compare = value.CompareTo(Value); //Сравнение

            if (compare == 0) //Если значение текущего экземпляра равно переданному значению
                return this; //Возвращаем ссылку на этот экземпляр(текущий узел)

            if (compare < 0) //Если значение меньше
            {
                if (Left != null)
                    return Left.Get(value); //Спускаемся влево
            }
            else
            {
                if (Right != null)
                    return Right.Get(value); //Спускаемся вправо
            }

            return null;
        }

        public IEnumerable<T> TraverseInOrder()
        {
            var list = new List<T>();
            InnerTraverse(list);
            return list;
        }

        private void InnerTraverse(List<T> list)
        {
            if (Left != null)
                Left.InnerTraverse(list);

            list.Add(Value);

            if (Right != null)
                Right.InnerTraverse(list);
        }

        public T Min()
        {
            if (Left != null)
                return Left.Min();

            return Value;
        }

        public T Max()
        {
            if (Right != null)
                return Right.Max();

            return Value;
        }

    }
}
