using System;
using System.Collections;

namespace Epam.NetMentoring.DataStructures.LinkedList
{
    //BK: Never use underscores in a naming. Why do you use that here?
    //AF: Yes, was a mess with naming ;). I've corrected it.
    public class LinkedList: IEnumerable
    {
        //BK: I would strongly recommend not to use underscrores in the code too
        //AF: Corrected
        private readonly Node head;

        public LinkedList()
        {
            head = new Node(null, null, null);
            head.Next = head;
            head.Previous = head;
            Count = 0;
        }

        public int Count { get; private set; }

        public object this[int index]
        {
            get { return FindNodeAt(index).Value; }
            set { FindNodeAt(index).Value = value; }
        }

        public void Clear()
        {
            head.Next = head;
            head.Previous = head;

            Count = 0;
        }

        public override string ToString()
        {
            var tmp = string.Empty;

            if (head == null)
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

            //BK: Put that if statement into findNodeAt better
            //AF: Not sure how you see this works. Let's duscuss that.

            if (index == Count)
            {
                node = new Node(value, head, head.Previous);
            }
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
            //BK: Why do you need if else statement here? Use == for example and no "if else"
            //AF: Yes, it was redundancy
                for (var node = head.Next; node != head; node = node.Next)
                {
                    if (node.Value == null)
                    {
                        Remove(node);
                    }
                }
        }

        public void RemoveAt(int index)
        {
            Remove(FindNodeAt(index));
        }

        private void Remove(Node value)
        {
            if (value == head) return;
            value.Previous.Next = value.Next;
            value.Next.Previous = value.Previous;

            Count--;
        }

        private Node FindNodeAt(int index)
        {
            if (index < 0 || Count <= index)
                throw new IndexOutOfRangeException("Index is out of range");

            var node = head;

            if (index < (Count/2))
            {
                for (var i = 0; i <= index; i++)
                {
                    node = node.Next;
                }
            }
            else
            {
                for (var i = Count; i > index; i--)
                {
                    node = node.Previous;
                }
            }

            return node;
        }

        public IEnumerator GetEnumerator()
        {
            for (var i = 0; i < Count; i++)
            {
                yield return this[i];
            }
        }
    }
}
