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
            LinkedQueue<int> queue = new LinkedQueue<int>();

            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();

            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }

        }
    }
}
