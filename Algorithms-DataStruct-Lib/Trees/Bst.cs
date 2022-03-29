using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_DataStruct_Lib.Trees
{
    public class Bst<T> where T : IComparable<T>
    {
        private TreeNode<T> _root; //Корень дерева

        public TreeNode<T> Get(T value)
        {
            return _root?.Get(value);
        }

        public T Min()
        {
            if (_root is null)
                throw new InvalidOperationException("Дерево не создано");

            return _root.Min();
        }

        public T Max()
        {
            if (_root is null)
                throw new InvalidOperationException("Дерево не создано");

            return _root.Max();
        }

        public void Insert(T value)
        {
            if (value is null)
                throw new InvalidOperationException();

            if (_root is null)
                _root = new TreeNode<T>(value);
            else
            {
                _root.Insert(value);
            }
        }

        public IEnumerable<T> TraverseInOrder()
        {
            if (_root is null)
                return Enumerable.Empty<T>(); //Возвращение пустой коллекции - best practice!!!
            else
            {
                return _root.TraverseInOrder();
            }
        }

        public void Remove(T value)
        {
            _root = Remove(_root, value); //Удаляемый узел, может быть сам _root
        }

        public TreeNode<T> Remove(TreeNode<T> subtreeRoot, T value)
        {
            if (subtreeRoot is null) //Базовый случай
                return null; //Закончили обход по дереву

            int compareTo = value.CompareTo(subtreeRoot.Value); //Сравниваем удаляемое значение, со значением в текущем узле

            if (compareTo < 0)
            {
                subtreeRoot.Left = Remove(subtreeRoot.Left, value); //Идем в левую сторону
            }
            else if (compareTo > 0)
            {
                subtreeRoot.Right = Remove(subtreeRoot.Right, value); //Идем в правую сторону
            }
            else
            {
                if (subtreeRoot.Left is null)
                {
                    return subtreeRoot.Right;
                }
                if (subtreeRoot.Right is null)
                {
                    return subtreeRoot.Left;
                }

                subtreeRoot.Value = subtreeRoot.Right.Min();
                subtreeRoot.Right = Remove(subtreeRoot.Right, subtreeRoot.Value);
            }

            return subtreeRoot;
        }
    }
}
