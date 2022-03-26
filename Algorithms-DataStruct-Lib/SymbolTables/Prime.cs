using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_DataStruct_Lib.SymbolTables
{
    /// <summary>
    /// Класс, предоставляющий функционал, для вычисления новой размерности для массива цепочек
    /// </summary>
    public class Prime
    {
        //Массив простых чисел
        private static readonly int[] Predefined = {
            3, 7, 11, 17, 23, 29, 37, 47, 59, 71, 89, 107, 131, 163, 197, 239, 293, 353, 431, 521, 631, 761, 919,
            1103, 1327, 1597, 1931, 2333, 2801, 3371, 4049, 4861, 5839, 7013, 8419, 10103, 12143, 14591,
            17519, 21023, 25229, 30293, 36353, 43627, 52361, 62851, 75431, 90523, 108631, 130363, 156437,
            187751, 225307, 270371, 324449, 389357, 467237, 560689, 672827, 807403, 968897, 1162687, 1395263,
            1674319, 2009191, 2411033, 2893249, 3471899, 4166287, 4999559, 5999471, 7199369};

        public static int MinPrime => Predefined[0];

        const int HashPrime = 101;

        /// <summary>
        /// Метод, возвращающий простое число, которое больше переданного
        /// </summary>
        /// <param name="min"></param>
        /// <returns></returns>
        public static int GetPrime(int min)
        {
            if (min < 0)
                throw new ArgumentException("Min can't be negative");

            for (int i = 0; i < Predefined.Length; i++)
            {
                int prime = Predefined[i];

                if (prime >= min) return prime;
            }

            //Начинаем итерировать с самого ближайшего нечетного числа
            for (int i = min|1; i < int.MaxValue; i += 2)
            {
                if (IsPrime(i) && (i - 1) % HashPrime!=0)
                    return i;
            }
            return min;
        }

        private static bool IsPrime(int candidate)
        {
            if (candidate % 2 != 0)
            {
                int limit = (int)Math.Sqrt(candidate);

                for (int divisor = 3; divisor <= limit; divisor += 2)
                {
                    if (candidate % divisor == 0)
                        return false;
                }

                return true;
            }

            return candidate == 2;
        }

        public static int ExpendPrime(int oldSize)
        {
            int newSize = 2 * oldSize;

            if ((uint)newSize > MaxPrimeArrayLength && MaxPrimeArrayLength > oldSize)
                return MaxPrimeArrayLength;
            return GetPrime(newSize);
            
        }

        public static int ReducePrime(int oldSize)
        {
            int newSize = oldSize / 2;

            if (newSize > MaxPrimeArrayLength && MaxPrimeArrayLength > oldSize)
                return MaxPrimeArrayLength;

            return GetPrime(newSize);
        }

        public const int MaxPrimeArrayLength = 0x7FEFFFFD;
    }
}
