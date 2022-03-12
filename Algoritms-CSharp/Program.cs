using Algorithms_DataStruct_Lib;
using Algorithms_DataStruct_Lib.Queues;
using Algorithms_DataStruct_Lib.Stack;
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
            var customersList = new List<Customer>()
            {
                new Customer { Name = "Ann", Age = 3},
                new Customer { Name = "Bill", Age = 16},
                new Customer { Name = "Rose", Age = 20},
                new Customer { Name = "Rob", Age = 14},
                new Customer { Name = "Bill", Age = 28},
                new Customer { Name = "John", Age = 14},
            };

            var intList = new List<int>() { 1, 4, 2, 7, 5, 9, 12, 3, 4, 12, 3 };

            bool contains = intList.Contains(1);
            bool contains2 = customersList.Contains(new Customer { Name = "Bill", Age = 28 },
                new CustomersComparer());

            bool contains3 = customersList.Exists(customer => customer.Name == "Rose");

            var customer = customersList.Max(customer => customer.Age);

            var customers = customersList.Where(customer => customer.Age > 18);

            var list = customersList.FindAll(customer => customer.Name == "Bill");

            var index = customersList.FindIndex(customer => customer.Age == 14);

            



            foreach (var item in customers)
            {
                Console.WriteLine(item.Name);
            }

            //Console.WriteLine(contains);
            //Console.WriteLine(contains2);
        }

        private static bool Exists(int[] array, int number)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == number)
                    return true;
            }
            return false;
        }

        private static int IndexOf(int[] array, int number)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == number)
                    return i;
            }

            return -1;
        }
    }
}
