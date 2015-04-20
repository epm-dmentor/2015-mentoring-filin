namespace Epam.NetMentoring.DataStructures.LinkedList
{
    internal class Node
    {
        //BK:I think currentNode should be replaced with value
        //AF:Agree. Corrected
        public Node(object value, Node nextNode, Node previousNode)
        {
            Value = value;
            Next = nextNode;
            Previous = previousNode;
        }

        public object Value { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }
    }
}