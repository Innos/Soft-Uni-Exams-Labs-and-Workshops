using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class JumpingSums
{
    static void Main(string[] args)
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        int jumps = int.Parse(Console.ReadLine());
        int[] sums = new int[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            int currentIndex = i;
            int currentValue = input[i];
            for (int l = 0; l <= jumps; l++)
            {
                sums[i] = sums[i] + currentValue;
                currentIndex = (currentIndex + currentValue) % input.Length;
                currentValue = input[currentIndex];
            }
        }
        Console.WriteLine("max sum = {0}",sums.Max());
    }
}

