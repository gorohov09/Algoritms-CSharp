using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritms_CSharp
{
    public class In
    {
        /// <summary>
        /// Метод для чтения целых чисел из файла
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static IEnumerable<int> ReadInts(string filePath)
        {
            using(TextReader reader = File.OpenText(filePath))
            {
                string lastLine;
                while((lastLine = reader.ReadLine()) != null)
                {
                    yield return int.Parse(lastLine);
                }
            }
        }
    }
}
