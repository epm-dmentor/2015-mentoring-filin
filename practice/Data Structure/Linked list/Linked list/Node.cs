namespace Linked_list
{
    internal class Node
    {
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