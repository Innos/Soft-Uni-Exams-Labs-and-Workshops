using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class BitCopy
{
    static void Main(string[] args)
    {
        int num = int.Parse(Console.ReadLine());
        int position = int.Parse(Console.ReadLine());
        int mask = (num >> position) & 1;
        num = num & ~(1 << 2);
        num = num | (mask << 2);
        Console.WriteLine(num);
    }
}

