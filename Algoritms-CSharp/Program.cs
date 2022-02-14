using Algorithms_DataStruct_Lib;
using System;
using System.Diagnostics;
using System.Linq;

namespace Algoritms_CSharp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var ints = In.ReadInts(@"D:\Программирование\Data\2Kints.txt").ToArray();

            var watch = new Stopwatch();
            watch.Start();

            var triplets = ThreeSum.Count(ints);

            watch.Stop();

            Console.WriteLine($"The number triplets: {triplets}");
            Console.WriteLine($"Time taken: {watch.ElapsedMilliseconds}");
        }
    }
}
