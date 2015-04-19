using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash_Table
{
    

    public class CustomHashTable : IHashTable
    {
        private readonly int _size;
        private readonly LinkedList<Bucket>[] _items;

        //public object[] Keys
        //{
        //    get
        //    {
                
        //    }
        //}

        public object Value { get; set; }

        public CustomHashTable(int size)
        {
            _size = size;
            _items = new LinkedList<Bucket>[size];
        }

        private struct Bucket
        {
            public object Key { get; set; }
            public object Value { get; set; }
        }

        private int GetHashCode(object key)
        {
            int hash = 17 * key.GetHashCode() % _size;
            return Math.Abs(hash);
        }

        private Bucket Find(object key)
        {
            int index = GetHashCode(key);
            LinkedList<Bucket> linkedList = GetLinkedList(index);

           foreach (Bucket item in linkedList.Where(item => item.Key.Equals(key)))
            {
                return item;
                
            }
            throw new ArgumentNullException();
        }

        public void Add(object key, object value)
        {
            if (Contains(key)) throw new Exception("Key already exist"); 

            int index = GetHashCode(key);
            LinkedList<Bucket> linkedList = GetLinkedList(index);
            Bucket item = new Bucket()
            {
                Key = key,
                Value = value
            };
            linkedList.AddLast(item);
           
        }

        public void Remove(object key)
        {
            int index = GetHashCode(key);
            LinkedList<Bucket> linkedList = GetLinkedList(index);
            bool itemFound = false;
            Bucket foundItem = new Bucket();
            foreach (Bucket item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    itemFound = true;
                    foundItem = item;
                }
            }

            if (itemFound)
            {
                linkedList.Remove(foundItem);
            }
        }

        private LinkedList<Bucket> GetLinkedList(int index)
        {
            LinkedList<Bucket> linkedList = _items[index];
            if (linkedList == null)
            {
                linkedList = new LinkedList<Bucket>();
                _items[index] = linkedList;
            }

            return linkedList;
        }

        public object this[object key]
        {
            get
            {
                return Find(key).Value;
            }
            set
            {
                if (value == null)
                {
                    Remove(key);
                }

                Add(Find(key).Key, value);
            }
        }

        public bool Contains(object key)
        {
            int index = GetHashCode(key);
            var linkedList = GetLinkedList(index);
            return linkedList.Any(item => item.Key.Equals(key));
        }

        public bool TryGet(object key, out object value)
        {
            int index = GetHashCode(key);
            LinkedList<Bucket> linkedList = GetLinkedList(index);

           foreach (Bucket item in linkedList.Where(item => item.Key.Equals(key)))
            {
                value = item.Value;
                return true;
            }
            value = null;
            return false;
        }
    }
}
