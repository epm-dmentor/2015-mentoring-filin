using System;
using System.Diagnostics;
using Linked_list;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_Test_Linked_List
{
    [TestClass]
    public class UnitTest
    {
        readonly Linked_List _list = new Linked_List();

        [TestMethod]
        public void ForEachAndCount()
        {
            for (int i = 1; i < 4; i++)
            {
                _list.Add(i);
            }

            foreach (var node in _list)
            {
                Assert.AreEqual(node,node);
            }

            for (int i = 0; i < _list.Count; i++)
            {
                Assert.AreEqual(_list[i], ++i);

            }

            Assert.AreEqual(_list[0], 1);
            Assert.AreEqual(_list[1], 2);
            Assert.AreEqual(_list[2], 3);

            Assert.IsTrue(_list.Count == 3);

        }

        [TestMethod]
        public void AddandCount()
        {
            for (int i = 1; i < 4; i++)
            {
                _list.Add(i);
            }

            for (int i = 0; i < _list.Count; i++)
            {
                Assert.AreEqual(_list[i], ++i);
               
            }
            
            Assert.AreEqual(_list[0], 1);
            Assert.AreEqual(_list[1], 2);
            Assert.AreEqual(_list[2], 3);

            Assert.IsTrue(_list.Count==3);

        }

        [TestMethod]
        public void AddAt()
        {
         _list.AddAt(0,1);
         Assert.AreEqual(_list[0], 1);
   
        }

        [TestMethod]
        public void Remove()
        {
            for (int i = 0; i < 4; i++)
            {
                _list.Add(i);
            }

            _list.Remove(2);

            foreach (object node in _list)
            {
                Assert.IsTrue(node != (object) 2);
            }
        }

        [TestMethod]
        public void RemoveAt()
        {
            for (int i = 0; i < 4; i++)
            {
                _list.Add(i);
            }

            _list.RemoveAt(0);

            Assert.AreEqual(_list.Count, 3);
        }
    }
}
