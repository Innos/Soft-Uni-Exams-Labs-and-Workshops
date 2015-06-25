using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleDowns
{
    class DoubleDowns
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }
            int rightDiagonal = 0;
            int leftDiagonal = 0;
            int vertical = 0;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                int n1 = numbers[i];
                int n2 = numbers[i + 1];
                for (int j = 0; j < 32; j++)
                {
                    int mask = 1 << j;
                    bool upperNumberMatch = (n1 & mask) > 0;
                    if (upperNumberMatch && (n2 & mask) > 0)
                    {
                        vertical++;
                    }
                    if (upperNumberMatch && (n2 & mask<<1) > 0)
                    {
                        leftDiagonal++;
                    }
                    if (upperNumberMatch && (n2 & mask>>1) > 0)
                    {
                        rightDiagonal++;
                    }
                }
            }
            Console.WriteLine(rightDiagonal);
            Console.WriteLine(leftDiagonal);
            Console.WriteLine(vertical);
        }
    }
}
