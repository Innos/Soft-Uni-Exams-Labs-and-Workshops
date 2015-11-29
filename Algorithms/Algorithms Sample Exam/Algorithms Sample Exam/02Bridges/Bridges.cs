namespace _02Bridges
{
    using System;
    using System.Linq;

    public class Bridges
    {
        private static int[,] lbs;

        private static int[] north;
        private static int[] south;

        public static void Main(string[] args)
        {
            north = Console.ReadLine().Split().Select(int.Parse).ToArray();
            south = Console.ReadLine().Split().Select(int.Parse).ToArray();
            lbs = new int[north.Length, south.Length];

            for (int i = 0; i < north.Length; i++)
            {
                for (int j = 0; j < south.Length; j++)
                {
                    lbs[i, j] = -1;
                }
            }
            CalculateBridges(north.Length - 1, south.Length - 1);
            Console.WriteLine(lbs[north.Length - 1, south.Length - 1]);
        }

        private static int CalculateBridges(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                return 0;
            }

            if (lbs[x, y] == -1)
            {
                int northMax = CalculateBridges(x, y - 1);
                int southMax = CalculateBridges(x - 1, y);
                if (north[x] == south[y])
                {
                    lbs[x, y] = Math.Max(1 + northMax, 1 + southMax);
                }
                else
                {
                    lbs[x, y] = Math.Max(northMax, southMax);
                }
            }

            return lbs[x, y];
        }
    }
}
