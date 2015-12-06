namespace _03MessageSharing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    public class MessageSharing
    {
        public static void Main(string[] args)
        {
            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
            string[] names = Console.ReadLine()
                .Substring(8)
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < names.Length; i++)
            {
                graph.Add(names[i], new List<string>());
            }
            string[] pairs = Console.ReadLine()
                .Substring(13)
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < pairs.Length; i++)
            {
                string[] parameters = pairs[i].Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
                graph[parameters[0]].Add(parameters[1]);
                graph[parameters[1]].Add(parameters[0]);
            }

            string[] startingPeople = Console.ReadLine()
                .Substring(7)
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            List<string> startingIndexes = new List<string>();
            for (int i = 0; i < startingPeople.Length; i++)
            {
                startingIndexes.Add(startingPeople[i]);
            }
            SortedDictionary<string, int> distances = new SortedDictionary<string, int>();
            for (int i = 0; i < names.Length; i++)
            {
                distances.Add(names[i], -1);
            }
            Bfs(graph, startingIndexes, distances);
        }

        private static void Bfs(Dictionary<string, List<string>> graph, List<string> startingIndexes, SortedDictionary<string, int> distances)
        {
            Queue<string> queue = new Queue<string>();
            for (int i = 0; i < startingIndexes.Count; i++)
            {
                queue.Enqueue(startingIndexes[i]);
                distances[startingIndexes[i]] = 0;
            }

            while (queue.Count > 0)
            {
                string currentIndex = queue.Dequeue();

                foreach (var child in graph[currentIndex])
                {
                    if (distances[child] == -1)
                    {
                        distances[child] = distances[currentIndex] + 1;
                        queue.Enqueue(child);
                    }
                }
            }

            if (distances.ContainsValue(-1))
            {
                Console.WriteLine("Cannot reach: {0}", string.Join(", ", distances.Keys.Where(x => distances[x] == -1).ToList()));
            }
            else
            {
                int maxSteps = distances.Values.Max();
                Console.WriteLine("All people reached in {0} steps", maxSteps);
                Console.WriteLine("People at last step: {0}", string.Join(", ", distances.Keys.Where(x => distances[x] == maxSteps)));
            }
        }
    }
}
