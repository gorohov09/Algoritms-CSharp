using Algorithms_DataStruct_Lib;
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
            LinkedStack<Person> stack = new LinkedStack<Person>();

            Person person1 = new Person() { Name = "Андрей"};
            Person person2 = new Person() { Name = "Максим" };
            Person person3 = new Person() { Name = "Серега" };

            stack.Push(person1);
            stack.Push(person2);
            stack.Push(person3);

            stack.Pop();


            var person = stack.Peek();
            person.Name = "Aaaaaaaa";

            foreach (var e in stack)
            {
                Console.WriteLine(e.Name);
            }


        }
    }
}
