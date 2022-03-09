using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_DataStruct_Lib.Tests
{
    [TestFixture]
    public class DoubleLinkedList
    {
        private DoubleLinkedList<int> _list;

        [SetUp]
        public void Init()
        {
            _list = new DoubleLinkedList<int>();
        }

        [Test]
        public void CreateEmptyList_CorrectState()
        {
            Assert.True(_list.IsEmpty);
            Assert.IsNull(_list.Tail);
            Assert.IsNull(_list.Head);
        }

        [Test]
        public void AddFirst_and_AddLast_Correct()
        {
            _list.AddFirst(45);
            _list.AddLast(14);
            Assert.True(_list.Head.Value == 45);
            Assert.True(_list.Tail.Value == 14);
        }

        [Test]
        public void Add_and_Remove()
        {
            _list.AddFirst(14);
            _list.Remove(14);
            Assert.True(_list.Head == _list.Tail);
        }
    }
}
