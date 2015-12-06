namespace _02Bridges
{
    using System;
    using System.Linq;

    public class Bridges
    {
        public static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] bridges = new int[numbers.Length];
            bool[] used = new bool[numbers.Length];
            for (int i = 1; i < numbers.Length; i++)
            {
                bridges[i] = bridges[i - 1];
                for (int j = i - 1; j >= 0; j--)
                {
                    if (numbers[i] == numbers[j])
                    {
                        if (bridges[i] < bridges[j] + 1)
                        {
                            bridges[i] = bridges[j] + 1;
                            used[j] = true;
                            used[i] = true;
                            break;
                        }
                    }
                }
            }
            int bridgesCount = bridges[bridges.Length - 1];
            if (bridgesCount == 0)
            {
                Console.WriteLine("No bridges found");
            }
            else if (bridgesCount == 1)
            {
                Console.WriteLine("1 bridge found");
            }
            else if (bridgesCount > 1)
            {
                Console.WriteLine("{0} bridges found", bridgesCount);
            }
            for (int i = 0; i < used.Length; i++)
            {
                if (used[i])
                {
                    Console.Write(numbers[i]);
                }
                else
                {
                    Console.Write("X");
                }
                Console.Write(" ");
            }
        }
    }
}
