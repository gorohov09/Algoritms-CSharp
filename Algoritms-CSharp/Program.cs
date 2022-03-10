using Algorithms_DataStruct_Lib;
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
            DoubleLinkedList<Person> list = new DoubleLinkedList<Person>();

            Person person = new Person() { Name = "Андрей"};
            Person person2 = new Person() { Name = "Максим" };
            Person person3 = new Person() { Name = "Серега" };

            list.AddLast(person);
            list.AddLast(person2);
            list.AddLast(person3);

            foreach (var item in list.BackEnumenator())
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine(list.Contains(person));

            LinkedList<int> l = new LinkedList<int>();
        }
    }
}
