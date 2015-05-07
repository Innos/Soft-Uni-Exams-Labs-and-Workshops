using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class BitSwap
{
    static void Main(string[] args)
    {
        long num = long.Parse(Console.ReadLine());
        long mask1 = (num >> 24) & 1;
        long mask2 = (num >> 3) & 1;
        num = num & ~(1 << 24);
        num = num & ~(1 << 3);
        num = num | (mask1 << 3);
        num = num | (mask2 << 24);
        Console.WriteLine(num);
    }
}

