#region

using System;
using System.Collections.Generic;
using Epam.NetMentoring.DataStructures.HashTable;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace Epam.NetMentoring.DataStructures.UnitTests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        [ExpectedException(typeof (Exception))]
        public void Add() //add the object by a key which already exists
        {
            HashTable.HashTable ht = new HashTable.HashTable(3);
            ht.Add("1", "somevalue");
            ht.Add("2", "anothervalue");

            ht.Add("2", "test");
        }

        [TestMethod]
        [ExpectedException(typeof (KeyNotFoundException))]
        public void Get() //get the object by a key which does not exit
        {
            HashTable.HashTable ht = new HashTable.HashTable(3);
            ht.Add("1", "somevalue");
            ht.Add("2", "anothervalue");
            ht.Add("3", "thirdvalue");

            var test = ht["4"];
        }

        [TestMethod]
        public void Set() //If setter is null, element wil be removed
        {
            object test;
            HashTable.HashTable ht = new HashTable.HashTable(3);
            ht.Add("1", "somevalue");
            ht.Add("2", "anothervalue");

            ht["2"] = null;
            Assert.IsFalse(ht.Contains("2"));
        }
    }
}