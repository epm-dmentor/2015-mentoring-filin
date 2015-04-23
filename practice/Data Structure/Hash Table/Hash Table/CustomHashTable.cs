#region

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

//BK: What a strange namespace :) Please use conventional namespaces
namespace Hash_Table
{
    //BK:Why can't you name that simply HashTable?
    public class CustomHashTable : IHashTable
    {
        private readonly LinkedList<Bucket>[] _items;
        private readonly int _size;

        public CustomHashTable(int size)
        {
            _size = size;
            _items = new LinkedList<Bucket>[size];
        }

        public void Add(object key, object value)
        {
            if (Contains(key)) throw new Exception("Key already exist");

            int index = GetHashCode(key);
            LinkedList<Bucket> linkedList = Buckets(index);
            Bucket item = new Bucket
            {
                Key = key,
                Value = value
            };
            linkedList.AddLast(item);
        }

        public object this[object key]
        {
            get
            {
                if (!Contains(key))
                {
                    throw new KeyNotFoundException();
                }
                return Find(key).Value;
            }
            set
            {
                if (value != null)
                {
                    Add(Find(key).Key, value);
                }
                else
                {
                    Remove(key);
                }
            }
        }

        public bool Contains(object key)
        {
            int index = GetHashCode(key);
            var linkedList = Buckets(index);
            return linkedList.Any(item => item.Key.Equals(key));
        }

        public bool TryGet(object key, out object value)
        {
            int index = GetHashCode(key);
            LinkedList<Bucket> linkedList = Buckets(index);
            if (Contains(key))
            {
                value = linkedList.SingleOrDefault(item => item.Key.Equals(key)).Value;
                return true;
            }
            value = null;
            return false;
        }

        public void Remove(object key)
        {
            int index = GetHashCode(key);
            LinkedList<Bucket> linkedList = Buckets(index);
            bool itemFound = false;
            //BK: Why do you initialize new Bucket here?
            Bucket foundItem = new Bucket();
            //BK:Why do you need all that logic? This should be done in Linked LIst implementation!
            foreach (Bucket item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    itemFound = true;
                    foundItem = item;
                    //BK: Break here???
                }
            }
            if (itemFound)
            {
                linkedList.Remove(foundItem);
            }
        }

        private int GetHashCode(object key)
        {
            int hash = 17*key.GetHashCode()%_size;
            return Math.Abs(hash);
        }

        private Bucket Find(object key)
        {
            int index = GetHashCode(key);
            LinkedList<Bucket> linkedList = Buckets(index);
            return linkedList.SingleOrDefault(item => item.Key.Equals(key));
        }

        //BK: This method doesn't look very explanatory
        private LinkedList<Bucket> Buckets(int index)
        {
            LinkedList<Bucket> linkedList = _items[index];
            if (linkedList == null)
            {
                linkedList = new LinkedList<Bucket>();
                _items[index] = linkedList;
            }
            return linkedList;
        }
        //BK: Why have you decided to use structure not class here?
        private struct Bucket
        {
            public object Key { get; set; }
            public object Value { get; set; }
        }
    }
}