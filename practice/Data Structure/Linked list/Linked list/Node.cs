namespace Linked_list
{
    internal class Node
    {
        //BK:I think currentNode should be replaced with value
        public Node(object currentNode, Node nextNode, Node previousNode)
        {
            Current = currentNode;
            Next = nextNode;
            Previous = previousNode;
        }

        public object Current { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }
    }
}