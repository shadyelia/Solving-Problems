using System.Collections.Generic;

namespace Build_Order
{
    public class Node
    {
        public string Value;
        public LinkedList<Node> Childern;
        public bool IsVisited;

        public Node(string value)
        {
            Value = value;
            Childern = new LinkedList<Node>();
            IsVisited = false;
        }
    }
}
