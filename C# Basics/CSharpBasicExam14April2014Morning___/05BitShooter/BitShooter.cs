using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class BitShooter
{
    static void Main(string[] args)
    {
        ulong number = ulong.Parse(Console.ReadLine());
        for (int i = 1; i <= 3; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            int center = int.Parse(input[0]);
            int size = int.Parse(input[1]);
            for (int l = center - (size / 2); l <= center + (size / 2); l++)
            {
                if (l >= 0 && l < 64)
                {
                    ulong mask = ~((ulong)1 << l);
                    number = number & mask;
                }
            }
        }
        ulong left = number >> 32;
        ulong right = number & uint.MaxValue;
        Console.WriteLine("left: {0}", BitCount(left));
        Console.WriteLine("right: {0}", BitCount(right));
    }
    private static int BitCount(ulong num)
    {
        int count = 0;
        while (num != 0)
        {
            count++;
            num = num & (num - 1);
        }
        return count;
    }
}

