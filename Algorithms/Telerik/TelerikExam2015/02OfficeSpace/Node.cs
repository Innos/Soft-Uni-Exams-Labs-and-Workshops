namespace _02OfficeSpace
{
    using System.Collections.Generic;

    public class Node
    {
        public Node(int value)
        {
            this.Value = value;
            this.Children = new List<int>();
        }

        public int Value { get; set; }

        public List<int> Children { get; private set; }
    }
}
