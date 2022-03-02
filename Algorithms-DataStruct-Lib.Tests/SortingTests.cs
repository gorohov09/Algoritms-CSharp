using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_DataStruct_Lib.Tests
{
    [TestFixture]
    public class SortingTests
    {
        /// <summary>
        /// Метод, возвращающий базовый массив
        /// </summary>
        /// <returns></returns>
        private int[][] Samples()
        {
            int[][] samples = new int[9][];
            samples[0] = new[] { 1, -1, 100, -44, 13 };
            samples[1] = new[] { 2, 1 };
            samples[2] = new[] { 2, 1, 3 };
            samples[3] = new[] { 1, 1, 5, 12, 1 };
            samples[4] = new[] { 2, -1, 3, 3 };
            samples[5] = new[] { 4, -5, 3, 1 };
            samples[6] = new[] { 1, 3, 12, 1 };
            samples[7] = new[] { 0, 5, -3, 0 };
            samples[8] = new[] { 3, 2, 4, 5, 1, 2, 3 };

            return samples;
        }

        /// <summary>
        /// Метод, помогающий запустить тест
        /// </summary>
        /// <param name="sort"></param>
        private void RunTestsForSortAlgoritm(Action<int[]> sort)
        {
            foreach (var sample in Samples())
            {
                sort(sample);
                CollectionAssert.IsOrdered(sample);
                PrintOut(sample);
            }
        }

        /// <summary>
        /// Вывод трассировочной информации
        /// </summary>
        /// <param name="array"></param>
        private void PrintOut(int[] array)
        {
            TestContext.WriteLine("--------TRACE------------\r");
            foreach (var el in array)
            {
                TestContext.Write(el + " ");
            }
            TestContext.WriteLine();
        }

        [Test]
        public void BubbleSort_ValidInput_SortedOutput()
        {
            Sorting sort = new Sorting();
            RunTestsForSortAlgoritm(sort.BubbleSort);
        }

        [Test]
        public void SelectionSort_ValidInput_SortedOutput()
        {
            Sorting sort = new Sorting();
            RunTestsForSortAlgoritm(sort.SelectionSort);
        }

        [Test]
        public void InsertionSort_ValidInput_SortedOutput()
        {
            Sorting sort = new Sorting();
            RunTestsForSortAlgoritm(sort.InsertionSort);
        }

        [Test]
        public void ShellSort_ValidInput_SortedOutput()
        {
            Sorting sort = new Sorting();
            RunTestsForSortAlgoritm(sort.ShellSort);
        }

        [Test]
        public void MergeSort_ValidInput_SortedOutput()
        {
            Sorting sort = new Sorting();
            RunTestsForSortAlgoritm(sort.MergeSort);
        }
    }
}
