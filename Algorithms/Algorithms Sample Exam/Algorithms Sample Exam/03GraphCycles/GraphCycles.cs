namespace _03GraphCycles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GraphCycles
    {
        private static List<int>[] graph;

        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            graph = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                string[] parameters =
                Console.ReadLine().Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
                int parent = int.Parse(parameters[0].Trim());
                graph[parent] = new List<int>();
                if (parameters.Length > 1)
                {
                    int[] numbers = parameters[1].Trim().Split().Select(int.Parse).Distinct().ToArray();
                    for (int j = 0; j < numbers.Length; j++)
                    {
                        graph[parent].Add(numbers[j]);
                    }
                }

            }

            int cycles = 0;
            for (int el1 = 0; el1 < n; el1++)
            {
                graph[el1].Sort();
                foreach (var child1 in graph[el1])
                {
                    if (el1 < child1)
                    {
                        graph[child1].Sort();
                        foreach (var child2 in graph[child1])
                        {
                            if (el1 < child2 && child2 != child1)
                            {
                                if (graph[child2].Contains(el1))
                                {
                                    cycles++;
                                    Console.WriteLine("{{{0} -> {1} -> {2}}}", el1, child1, child2);
                                }
                            }
                        }
                    }
                }
            }

            if (cycles == 0)
            {
                Console.WriteLine("No cycles found");
            }
        }
    }
}
