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

    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public int Ssh { get; set; }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            ChainHashSet<string, int> table = new ChainHashSet<string, int>(5);

            table.Add("a", 3);
            table.Add("b", 4);
            table.Add("c", 5);
            table.Add("d", 6);
            table.Add("dfdf", 45);
            table.Add("4567", 12);

            var keys = table.Keys();

            foreach (string key in keys)
            {
                Console.WriteLine(key);
            }
        }
    }
}
