using Algorithms_DataStruct_Lib;
using Algorithms_DataStruct_Lib.Dequeues;
using Algorithms_DataStruct_Lib.Queues;
using Algorithms_DataStruct_Lib.Stack;
using Algorithms_DataStruct_Lib.SymbolTables;
using Algorithms_DataStruct_Lib.Trees;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Algoritms_CSharp
{
    
    public class PhoneNumber
    {
        public string AreaCode { get; }

        public string Exchange { get; }

        public string Number { get; }

        public override bool Equals(object obj)
        {
            var other = obj as PhoneNumber;

            if (other is null)
                return false;

            return this.AreaCode == other.AreaCode
                && this.Exchange == other.Exchange
                && this.Number == other.Number;
        }

        public static bool operator ==(PhoneNumber left, PhoneNumber right)
        {
            if (object.ReferenceEquals(left, right))
                return true;

            if (object.ReferenceEquals(null, left))
                return false;

            return left.Equals(right);
        }

        public static bool operator !=(PhoneNumber left, PhoneNumber right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(AreaCode, Exchange, Number);
        }
    }

    public class Person : IComparable<Person>
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public int CompareTo(Person other)
        {
            if (this.Age == other.Age) return 0;
            else if (this.Age < other.Age) return -1;
            else return 1;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            MaxHeap<int> heap = new MaxHeap<int>();

            heap.Insert(12);
            heap.Insert(55);
            heap.Insert(3);
            heap.Insert(100);
            heap.Insert(150);

            var val = heap.Values();

            foreach (var item in val)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            Console.WriteLine(heap.Peek());

            heap.Remove();

            Console.WriteLine(heap.Peek());

            

            
        }
    }
}
