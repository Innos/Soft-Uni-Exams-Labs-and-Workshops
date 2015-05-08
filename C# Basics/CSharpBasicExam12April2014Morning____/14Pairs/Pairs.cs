using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Pairs
{
    static void Main(string[] args)
    {
        int counter = 0;
        string[] input = Console.ReadLine().Split(' ');
        int[] numbers = Array.ConvertAll(input, int.Parse);
        int[] sums = new int[numbers.Length / 2];
        for (int i = 0; i < numbers.Length; i = i + 2)
        {
            sums[counter] = numbers[i] + numbers[i + 1];
            counter++;
        }
        if(sums.Min() == sums.Max())
        {
            Console.WriteLine("Yes, value={0}",sums.Max());
        }
        else
        {
            int[] diff = new int[sums.Length - 1];
            counter = 0;
            for (int i = 1; i < sums.Length; i++)
            {
                diff[counter] = Math.Abs(sums[i] - sums[i-1]);
                counter++;
            }
            Console.WriteLine("No, maxdiff={0}",diff.Max());
        }
    }
}

