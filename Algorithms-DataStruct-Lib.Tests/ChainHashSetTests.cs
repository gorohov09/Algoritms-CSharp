using Algorithms_DataStruct_Lib.SymbolTables;
using Algorithms_DataStruct_Lib.Tests.Data;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_DataStruct_Lib.Tests
{
    [TestFixture]
    public class ChainHashSetTests
    {
        private ChainHashSet<string, PersonTest> _hashSet;

        [SetUp]
        public void Init()
        {
            _hashSet = new ChainHashSet<string, PersonTest>();
        }

        [Test]
        public void ChainHashSetInit()
        {
            ChainHashSet<char, string> table = new ChainHashSet<char, string>();

            Assert.IsTrue(table.Capacity == 3);
            Assert.IsNotNull(table);
            Assert.IsNotNull(_hashSet);
        }

        [Test]
        public void ChainHashSetAddandRemove()
        {
            _hashSet.Add("abc", new PersonTest() { Name = "Андрей", Age = 19});
            _hashSet.Add("cdf", new PersonTest() { Name = "Максим", Age = 20 });
            _hashSet.Add("der", new PersonTest() { Name = "Коля", Age = 30 });
            _hashSet.Add("ngq", new PersonTest() { Name = "Игорь", Age = 36 });

            Assert.IsTrue(_hashSet.Count == 4);
            Assert.AreEqual(_hashSet.Get("cdf").Age, 20);

            _hashSet.Remove("der");
            _hashSet.Remove("ngq");

            var keys = _hashSet.Keys();

            foreach (var key in keys)
            {
                Assert.IsTrue(key == "abc" || key == "cdf");
            }

            Assert.IsTrue(_hashSet.Count == 2);
        }
    }
}
