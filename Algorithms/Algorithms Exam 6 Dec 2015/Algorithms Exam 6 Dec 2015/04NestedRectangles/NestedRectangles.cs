namespace _04NestedRectangles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Rectangle
    {
        public Rectangle(string name, int x1, int x2, int y1, int y2)
        {
            this.Name = name;
            this.X1 = x1;
            this.X2 = x2;
            this.Y1 = y1;
            this.Y2 = y2;
            this.Children = new List<Rectangle>();
            this.Depth = 0;
        }

        public string Name { get; set; }

        public int X1 { get; set; }

        public int X2 { get; set; }

        public int Y1 { get; set; }

        public int Y2 { get; set; }

        public List<Rectangle> Children { get; private set; }

        public int Depth { get; set; }

        public Rectangle Successor { get; set; }
    }

    public class NestedRectangles
    {
        public static void Main(string[] args)
        {
            List<Rectangle> rectangles = new List<Rectangle>();
            string line = Console.ReadLine();
            while (line != "End")
            {
                string[] parameters = line.Split(new char[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string name = parameters[0];
                int x1 = int.Parse(parameters[1]);
                int y1 = int.Parse(parameters[2]);
                int x2 = int.Parse(parameters[3]);
                int y2 = int.Parse(parameters[4]);
                Rectangle rectangle = new Rectangle(name, x1, x2, y1, y2);
                rectangles.Add(rectangle);
                line = Console.ReadLine();
            }
            rectangles = rectangles.OrderBy(x => x.X1).ThenByDescending(x => x.X2).ThenByDescending(x => x.Y1).ThenBy(x => x.Y2).ThenBy(x => x.Name).ToList();
            for (int i = 0; i < rectangles.Count; i++)
            {
                Rectangle currentRectangle = rectangles[i];
                for (int j = i + 1; j < rectangles.Count; j++)
                {
                    if (rectangles[j].X2 > currentRectangle.X2 || rectangles[j].Y1 > currentRectangle.Y1 || rectangles[j].Y2 < currentRectangle.Y2)
                    {
                        continue;
                    }
                    currentRectangle.Children.Add(rectangles[j]);
                }
            }
            for (int i = 0; i < rectangles.Count; i++)
            {
                Dfs(rectangles[i]);
            }
            Rectangle top = rectangles.OrderByDescending(x => x.Depth).ThenBy(x => x.Name).First();
            int depth = top.Depth;
            while (true)
            {
                Console.Write(top.Name);
                depth -= 1;
                top = top.Successor;
                if (top == null || depth == 0)
                {
                    Console.WriteLine();
                    break;
                }
                Console.Write(" < ");
            }
        }

        private static int Dfs(Rectangle element)
        {
            if (element.Depth > 0)
            {
                return element.Depth;
            }

            element.Depth = 1;
            element.Successor = null;
            foreach (var child in element.Children)
            {
                int currentDepth = Dfs(child) + 1;
                if (currentDepth > element.Depth || (currentDepth == element.Depth && child.Name.CompareTo(element.Successor.Name) < 0))
                {
                    element.Depth = currentDepth;
                    element.Successor = child;
                }

            }
            return element.Depth;
        }
    }
}