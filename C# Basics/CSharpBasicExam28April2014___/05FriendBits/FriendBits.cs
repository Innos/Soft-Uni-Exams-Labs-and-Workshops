using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class FriendBits
{
    static void Main(string[] args)
    {
        uint f = 0;
        uint a = 0;
        uint num = uint.Parse(Console.ReadLine());
        for (int i = 31; i >= 0; i--)
        {
            uint bitCheck = (num >> i) & 1;
            if ((i + 1 <= 31 && (bitCheck) == ((num >> i + 1) & 1)) || (i - 1 >= 0 && (bitCheck) == ((num >> i - 1) & 1)))
            {
                f = f << 1;
                f = f | bitCheck;
            }
            else
            {
                a = a << 1;
                a = a | bitCheck;
            }
        }
        Console.WriteLine(f);
        Console.WriteLine(a);
    }
}

