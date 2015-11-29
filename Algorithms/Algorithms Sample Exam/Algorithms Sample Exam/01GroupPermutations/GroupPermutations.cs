namespace _01GroupPermutations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class GroupPermutations
    {
        private static StringBuilder permutation = new StringBuilder();

        private static Dictionary<char, int> letterCount;

        public static void Main(string[] args)
        {
            string word = Console.ReadLine();
            letterCount = new Dictionary<char, int>();
            for (int i = 0; i < word.Length; i++)
            {
                if (!letterCount.ContainsKey(word[i]))
                {
                    letterCount.Add(word[i], 0);
                }

                letterCount[word[i]]++;
            }

            char[] uniqueWord = word.ToCharArray().Distinct().ToArray();
            GeneratePermutations(uniqueWord, 0);
        }

        private static void GeneratePermutations(char[] word, int currentElement)
        {
            if (currentElement == word.Length - 1)
            {
                Print(word);
            }
            else
            {
                for (int i = currentElement; i < word.Length; i++)
                {
                    Swap(ref word[i], ref word[currentElement]);
                    GeneratePermutations(word, currentElement + 1);
                    Swap(ref word[i], ref word[currentElement]);
                }
            }
        }

        private static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        private static void Print(char[] word)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < word.Length; i++)
            {
                result.Append(new string(word[i], letterCount[word[i]]));
            }
            Console.WriteLine(result.ToString());
        }
    }
}
