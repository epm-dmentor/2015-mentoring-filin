using System;
using System.Collections;

namespace Linked_list
{
    public class Linked_List: IEnumerable
    {
        private readonly Node _head;

        public Linked_List()
        {
            _head = new Node(null, null, null);
            _head.Next = _head;
            _head.Previous = _head;
            Count = 0;
        }

        public int Count { get; private set; }

        public object this[int index]
        {
            get { return FindNodeAt(index).Current; }
            set { FindNodeAt(index).Current = value; }
        }

        public void Clear()
        {
            _head.Next = _head;
            _head.Previous = _head;

            Count = 0;
        }

        public override string ToString()
        {
            var tmp = string.Empty;

            if (_head == null)
            {
                tmp = "Linked List is empty";
                return tmp;
            }

            for (var i = 1; i <= Count; i++)
            {
                tmp += "Element " + i + " : " + this[i - 1] + Environment.NewLine;
            }

            return tmp;
        }

        public void Add(object value)
        {
            AddAt(Count, value);
        }

        public void AddAt(int index, object value)
        {
            Node node;

            if (index == Count)
                node = new Node(value, _head, _head.Previous);
            else
            {
                var tmp = FindNodeAt(index);

                node = new Node(value, tmp, tmp.Previous);
            }

            node.Previous.Next = node;
            node.Next.Previous = node;

            Count++;
        }

        public void Remove(object value)
        {
            if (value == null)
            {
                for (var node = _head.Next; node != _head; node = node.Next)
                    if (node.Current == null)
                        Remove(node);
            }
            else
            {
                for (var node = _head.Next; node != _head; node = node.Next)
                    if (value.Equals(node.Current))
                        Remove(node);
            }
        }

        public void RemoveAt(int index)
        {
            Remove(FindNodeAt(index));
        }

        private void Remove(Node value)
        {
            if (value == _head) return;
            value.Previous.Next = value.Next;
            value.Next.Previous = value.Previous;

            Count--;
        }

        private Node FindNodeAt(int index)
        {
            if (index < 0 || Count <= index)
                throw new IndexOutOfRangeException("Index is out of range");

            var node = _head;

            if (index < (Count/2))
            {
                for (var i = 0; i <= index; i++)
                    node = node.Next;
            }
            else
            {
                for (var i = Count; i > index; i--)
                    node = node.Previous;
            }

            return node;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return FindNodeAt(i).Current;
            }
        }
    }
}