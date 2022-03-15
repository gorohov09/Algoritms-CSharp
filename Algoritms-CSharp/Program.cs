using Algorithms_DataStruct_Lib;
using Algorithms_DataStruct_Lib.Queues;
using Algorithms_DataStruct_Lib.Stack;
using Algorithms_DataStruct_Lib.SymbolTables;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Algoritms_CSharp
{
    public class Customer
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }

    public class CustomersComparer : IEqualityComparer<Customer>
    {
        public bool Equals(Customer x, Customer y)
        {
            return x.Age == y.Age && x.Name == y.Name;
        }

        public int GetHashCode([DisallowNull] Customer obj)
        {
            return obj.GetHashCode();
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            SequentialSearchSt<int, int> dict = new SequentialSearchSt<int, int>();

            dict.Add(1, 1);
            dict.Add(2, 3);
            dict.Add(3, 18);
            dict.Remove(3);
        }
    }
}
