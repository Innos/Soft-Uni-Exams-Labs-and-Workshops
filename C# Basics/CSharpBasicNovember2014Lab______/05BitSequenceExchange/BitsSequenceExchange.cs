using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class BitsSequenceExchange
{
    static void Main(string[] args)
    {
        long num = long.Parse(Console.ReadLine());
        long mask1 = (num >> 3) & 7;
        long mask2 = (num >> 24) & 7;
        num = num & ~(7 << 3) & ~(7 << 24);
        num = num | (mask2 << 3) | (mask1 << 24);
        Console.WriteLine(num);
    }
}

