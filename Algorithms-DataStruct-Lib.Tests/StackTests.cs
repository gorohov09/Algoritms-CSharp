using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_DataStruct_Lib.Tests
{
    [TestFixture]
    public class StackTests
    {
        [Test]
        public void IsEmpty_EmptyStack_ReturnsTrue()
        {
            var stack = new ArrayStack<int>();
            Assert.IsTrue(stack.IsEmpty);
        }

        [Test]
        public void Count_PushOneItem()
        {
            var stack = new ArrayStack<int>();
            stack.Push(12);

            Assert.AreEqual(1, stack.Count);
            Assert.IsFalse(stack.IsEmpty);
        }

        [Test]
        public void Peek_Push_Pop_Item()
        {
            var stack = new ArrayStack<int>();
            stack.Push(12);
            stack.Push(14);
            stack.Push(2);

            Assert.AreEqual(2, stack.Peek());

            stack.Pop();

            Assert.AreEqual(14, stack.Peek());

            stack.Pop();
            stack.Pop();
            Assert.IsTrue(stack.IsEmpty);

        }
    }
}
