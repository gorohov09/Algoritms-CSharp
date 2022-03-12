using Algorithms_DataStruct_Lib;
using Algorithms_DataStruct_Lib.Queues;
using Algorithms_DataStruct_Lib.Stack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Algoritms_CSharp
{
    public class Person
    {
        public string Name { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is Person person)
            {
                return person.Name == this.Name;
            }
            else
                return false;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            CircularQueue<int> queue = new CircularQueue<int>(2);

            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

            queue.Dequeue();
            queue.Dequeue();
            queue.Enqueue(12);
            queue.Enqueue(14);
            queue.Enqueue(22);

            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            queue.Enqueue(1);

            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            queue.Dequeue();

            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }

        }
    }
}
