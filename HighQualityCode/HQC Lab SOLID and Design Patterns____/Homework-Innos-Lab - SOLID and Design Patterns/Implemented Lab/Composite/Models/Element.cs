namespace Composite.Models
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class Element
    {
        private readonly List<Element> children;

        private string type;

        public Element(string type, params Element[] children)
        {
            this.children = children.Length > 0 ? children.ToList() : new List<Element>();
            this.type = type;
        }

        public void Add(Element element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element", "Input Element cannot be null");
            }
            this.children.Add(element);
        }

        public void Remove(Element element)
        {
            this.children.Remove(element);
        }

        public string Display(int indent)
        {
            var sb = new StringBuilder();
            string openTag = string.Format("{2}<{0}>{1}", this.type, Environment.NewLine, new string(' ', indent));
            sb.Append(openTag);
            foreach (var element in this.children)
            {
                var display = element.Display(indent + 2);
                sb.Append(display);
            }
            string closeTag = string.Format("{2}</{0}>{1}", this.type, Environment.NewLine, new string(' ', indent));
            sb.Append(closeTag);
            return sb.ToString();
        }
    }
}
