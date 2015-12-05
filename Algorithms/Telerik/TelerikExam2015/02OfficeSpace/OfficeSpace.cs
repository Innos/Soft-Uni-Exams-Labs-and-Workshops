namespace _02OfficeSpace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class OfficeSpace
    {
        private static int maxTime = 0;

        private static bool[] visited;

        private static int[] maxValue;

        public static void Main(string[] args)
        {
            List<Node> graph = new List<Node>();
            int vertexes = int.Parse(Console.ReadLine());
            int[] values = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < vertexes; i++)
            {
                graph.Add(new Node(values[i]));
            }
            bool hasStartingPoint = false;
            List<int> startingNodes = new List<int>();
            for (int i = 0; i < vertexes; i++)
            {
                int[] parents = Console.ReadLine().Split().Select(int.Parse).ToArray();
                if (parents[0] == 0)
                {
                    hasStartingPoint = true;
                    startingNodes.Add(i);
                    continue;
                }
                for (int j = 0; j < parents.Length; j++)
                {

                    graph[(parents[j] - 1)].Children.Add(i);
                }
            }
            bool hasCycle = false;
            if (hasStartingPoint)
            {
                maxValue = new int[vertexes];
                for (int i = 0; i < startingNodes.Count; i++)
                {
                    try
                    {
                        visited = new bool[vertexes];
                        maxTime = Math.Max(maxTime, DFS(startingNodes[i], graph));

                    }
                    catch (InvalidOperationException)
                    {
                        hasCycle = true;
                        break;
                    }
                }
                if (hasCycle)
                {
                    Console.WriteLine(-1);
                }
                else
                {
                    Console.WriteLine(maxTime);
                }
            }
            else
            {
                Console.WriteLine(-1);
            }
        }

        private static int DFS(int element, List<Node> graph)
        {
            if (visited[element])
            {
                throw new InvalidOperationException("Graph cannot contain cycles!");
            }

            if (maxValue[element] > 0)
            {
                return maxValue[element];
            }
            maxValue[element] = graph[element].Value;

            visited[element] = true;
            foreach (var child in graph[element].Children)
            {
                maxValue[element] = Math.Max(maxValue[element], DFS(child, graph) + graph[element].Value);
            }
            visited[element] = false;
            return maxValue[element];

        }
    }
}
