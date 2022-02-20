using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_DataStruct_Lib
{
    public class Sorting
    {
        /// <summary>
        /// Алгоритм пузырьковой сортировки
        /// </summary>
        /// <param name="array"></param>
        public void BubbleSort(int[] array)
        {
            for (int partIndex = array.Length - 1; partIndex > 0; partIndex--)
            {
                for (int i = 0; i < partIndex; i++)
                {
                    if (array[i] > array[i + 1])
                        Swap(array, i, i + 1);
                }
            }
        }

        /// <summary>
        /// Вспомогательный метод, который нужен для перестановки элементов
        /// </summary>
        /// <param name="array"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private void Swap(int[] array, int i, int j)
        {
            if (i == j)
                return;

            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
