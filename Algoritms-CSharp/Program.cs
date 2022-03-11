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
            ArrayStack<Person> stack = new ArrayStack<Person>(2);

            Person person1 = new Person() { Name = "Андрей"};
            Person person2 = new Person() { Name = "Максим" };
            Person person3 = new Person() { Name = "Серега" };

            stack.Push(person1);
            stack.Push(person2);
            stack.Push(person3);

            foreach (var item in stack)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine();

            stack.Pop();

            foreach (var item in stack)
            {
                Console.WriteLine(item.Name);
            }

            var person = stack.Peek();

        }
    }
}
