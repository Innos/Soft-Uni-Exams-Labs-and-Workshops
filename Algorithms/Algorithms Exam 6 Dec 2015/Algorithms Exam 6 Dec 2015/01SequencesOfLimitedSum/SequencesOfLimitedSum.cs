using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01SequencesOfLimitedSum
{
    public class SequencesOfLimitedSum
    {
        private static int sum;

        private static int currentSum = 0;

        private static List<int> numbers; 

        private static StringBuilder result;

        public static void Main(string[] args)
        {
            sum = int.Parse(Console.ReadLine());
            numbers = new List<int>();
            result = new StringBuilder();
            Permute(0);
            Console.WriteLine(result.ToString());
        }

        private static void Permute(int loop)
        {
            if (currentSum <= sum && loop > 0)
            {
                for (int i = 0; i < numbers.Count-1; i++)
                {
                    result.Append(numbers[i]);
                    result.Append(" ");
                }
                result.Append(numbers[numbers.Count - 1]);
                result.AppendLine();

            }

            if (loop <= sum)
            {
                for (int i = 1; i <= sum-currentSum; i++)
                {
                    currentSum += i;
                    numbers.Add(i);
                    Permute(loop + 1);
                    currentSum -= i;
                    numbers.RemoveAt(numbers.Count-1);
                }
            }
        }
    }
}
