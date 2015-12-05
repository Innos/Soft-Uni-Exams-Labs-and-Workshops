namespace _02StringsDP
{
    using System;

    public class StringsDp
    {
        private static int[,] LPF;

        private static int max;

        private static string first;

        private static string second;

        public static void Main(string[] args)
        {
            string[] strings = { "team", "tree", "treant", "demi", "lich" };
            LPF = new int[33, 33];
            for (int i = 0; i < 33; i++)
            {
                LPF[0, i] = 0;
                LPF[i, 0] = 0;
            }
            for (int i = 0; i < strings.Length; i++)
            {
                for (int j = i + 1; j < strings.Length; j++)
                {
                    FindLargestPrefix(strings[i], strings[j]);
                }
            }
            Console.WriteLine("Max:{0} First: {1} Second: {2}", max, first, second);
        }

        private static void FindLargestPrefix(string wordA, string wordB)
        {
            for (int i = 1; i <= wordA.Length; i++)
            {
                for (int j = 1; j <= wordB.Length; j++)
                {
                    if (wordA[i - 1] == wordB[j - 1])
                    {
                        LPF[i, j] = LPF[i - 1, j - 1] + 1;
                        if (LPF[i, j] > max)
                        {
                            max = LPF[i, j];
                            first = wordA;
                            second = wordB;
                        }
                    }
                    else
                    {
                        LPF[i, j] = 0;
                    }
                }
            }
        }
    }
}
