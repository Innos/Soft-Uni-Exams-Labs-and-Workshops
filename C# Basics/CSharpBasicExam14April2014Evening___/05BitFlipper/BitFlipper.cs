using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class BitFlipper
{
    static void Main(string[] args)
    {
        ulong number = ulong.Parse(Console.ReadLine());
        for (int bit = 61; bit >= 0; bit--)
        {
            ulong sequence = (number >> bit) & 7;
            if (sequence == 7)
            {
                ulong mask = ~((ulong)7 << bit);
                number = number & mask;
                bit = bit - 2;
            }
            else if(sequence == 0)
            {
                ulong mask = ((ulong)7 << bit);
                number = number | mask;
                bit = bit - 2;
            }
        }
        Console.WriteLine(number);
    }
}

