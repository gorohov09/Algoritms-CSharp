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
        /// Пузырьковая сортировка(Bubble Sort)
        /// </summary>
        /// <param name="array"></param>
        public void BubbleSort(int[] array)
        {
            #region 1_version
            //for (int partIndex = array.Length - 1; partIndex > 0; partIndex--)
            //{
            //    for (int i = 0; i < partIndex; i++)
            //    {
            //        if (array[i] > array[i + 1])
            //            Swap(array, i, i + 1);
            //    }
            //}
            #endregion

            #region 2_version
            for (int i = 0; i < array.Length; i++)
            {
                for(int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (array[j] > array[j + 1])
                        Swap(array, j, j + 1);
                }
                    
            }
            #endregion
        }

        /// <summary>
        /// Сортировка выборкой(Selection Sort)
        /// </summary>
        /// <param name="array"></param>
        public void SelectionSort(int[] array)
        {
            #region version_1
            //for (int partIndex = array.Length - 1; partIndex > 0; partIndex--)
            //{
            //    int largestAt = 0;
            //    for (int i = 1; i <= partIndex; i++)
            //    {
            //        if (array[i] > array[largestAt])
            //        {
            //            largestAt = i;
            //        }
            //    }
            //    Swap(array, largestAt, partIndex);
            //}
            #endregion

            #region version_2
            for (int i = 0; i < array.Length; i++)
            {
                int min = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[min])
                        min = j;
                }
                Swap(array, i, min);
            }
            #endregion
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
