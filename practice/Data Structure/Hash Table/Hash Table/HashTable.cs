#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

#endregion

//BK: What a strange namespace :) Please use conventional namespaces
//AF: Corrected ;)
namespace Epam.NetMentoring.DataStructures.HashTable
{
    //BK:Why can't you name that simply HashTable?
    //AF: Corrected
    public class HashTable : IHashTable
    {
        private readonly LinkedList<bucket>[] items;
        private readonly int size;

        public HashTable(int size)
        {
            this.size = size;
            items = new LinkedList<bucket>[size];
        }

        public void Add(object key, object value)
        {
            if (Contains(key)) throw new Exception("Key already exist");

            int bucketNumber = GetBucketNumberHashCode(key);
            LinkedList<bucket> linkedList = buckets(bucketNumber);
            bucket item = new bucket
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
            int bucketNumber = GetBucketNumberHashCode(key);
            var linkedList = buckets(bucketNumber);
            return linkedList.Any(item => item.Key.Equals(key));
        }

        public bool TryGet(object key, out object value)
        {
            int bucketNumber = GetBucketNumberHashCode(key);
            LinkedList<bucket> linkedList = buckets(bucketNumber);

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
            //BK:Why do you need all that logic? This should be done in Linked LIst implementation!
            //AF:Improved logic
            int bucketNumber = GetBucketNumberHashCode(key);
            buckets(bucketNumber).Clear();
        }

        private int GetBucketNumberHashCode(object key)
        {
            int hash = 17 * key.GetHashCode() % size;
            return Math.Abs(hash);
        }

        private bucket Find(object key)
        {
            int bucketNumber = GetBucketNumberHashCode(key);
            LinkedList<bucket> linkedList = buckets(bucketNumber);
            return linkedList.SingleOrDefault(item => item.Key.Equals(key));
        }

        //BK: This method doesn't look very explanatory
        //AF: Changed local var name, should be clear
        private LinkedList<bucket> buckets(int bucketNumber)
        {
            LinkedList<bucket> linkedList = items[bucketNumber];

            if (linkedList == null)
                return items[bucketNumber] = new LinkedList<bucket>();

            return linkedList;
        }

        //BK: Why have you decided to use structure not class here?
        //AF: Video lessons influence and by the way Microsoft also uses "struct" to store hash table data ;)
        private class bucket
        {
            public object Key { get; set; }
            public object Value { get; set; }
        }
    }
}
