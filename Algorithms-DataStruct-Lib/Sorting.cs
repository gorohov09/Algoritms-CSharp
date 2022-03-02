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
        /// Сортировка вставками(Insertion Sort)
        /// </summary>
        /// <param name="array"></param>
        public void InsertionSort(int[] array)
        {
            for (int partIndex = 1; partIndex < array.Length; partIndex++)
            {
                int curUnsorted = array[partIndex];
                int i = 0;
                for (i = partIndex; i > 0 && array[i - 1] > curUnsorted; i--)
                {
                    array[i] = array[i - 1];
                }
                array[i] = curUnsorted;
            }
        }

        /// <summary>
        /// Сортировка Шелла(Shell Sort)
        /// </summary>
        /// <param name="array"></param>
        public void ShellSort(int[] array)
        {
            int gap = 1;
            while (gap < array.Length / 3)
                gap = 3 * gap + 1;

            while (gap >= 1)
            {
                for(int i = gap; i < array.Length; i++)
                {
                    for(int j = i; j >= gap && array[j] < array[j - gap]; j-= gap)
                    {
                        Swap(array, j, j - gap);
                    }
                }
                gap /= 3;
            }
        }

        /// <summary>
        /// Сортировка слиянием
        /// </summary>
        /// <param name="array"></param>
        public void MergeSort(int[] array)
        {
            int[] aux = new int[array.Length]; //Вспомогательный массив

            Sort(0, array.Length - 1);

            void Sort(int low, int high)
            {
                if (high <= low) //Базовый случай выхода из рекурсии
                    return;

                int mid = (low + high) / 2; //Срединный индекс
                Sort(low, mid); //Разделение левой части
                Sort(mid + 1, high); //Разделение правой части
                Merge(low, mid, high); //Фаза слияния
            }

            void Merge(int low, int mid, int high)
            {
                int i = low; //Первый элемент левого массива
                int j = mid + 1;  //Первый элемент правого массива

                Array.Copy(array, low, aux, low, high - low + 1);

                for (int k = low; k <= high; k++)
                {
                    if (i > mid) 
                        array[k] = aux[j++];
                    else if (j > high) 
                        array[k] = aux[i++];
                    else if (aux[j] < aux[i]) 
                        array[k] = aux[j++];
                    else 
                        array[k] = aux[i++];
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
