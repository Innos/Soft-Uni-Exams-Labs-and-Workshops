using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;


class BitBuilder
{
    static void Main(string[] args)
    {
        BigInteger newNum = 0;
        BigInteger mask = 0;
        BigInteger num = BigInteger.Parse(Console.ReadLine());

        while (true)
        {
            int pos;
            string position = Console.ReadLine();
            if(position != "quit")
            {
                pos = int.Parse(position);
            }
            else
            {
                break;
            }
            string command = Console.ReadLine();
            switch (command)
            {
                case "flip":
                    num = num ^ (long)1 << pos;
                    break;

                case "remove":
                    newNum = 0;
                    mask = 0;
                    for (int bit = 63; bit >= 0; bit--)
                    {
                        if (bit != pos)
                        {
                            mask = (num >> bit) & 1;
                            newNum = newNum << 1;
                            newNum = newNum | mask;
                        }
                    }
                    num = newNum;
                    break;

                case "insert":
                    newNum = 0;
                    mask = 0;
                    for (int bit = 63; bit >= 0; bit--)
                    {
                        mask = (num >> bit) & 1;
                        newNum = newNum << 1;
                        newNum = newNum | mask;
                        if (bit == pos)
                        {
                            newNum = newNum << 1;
                            newNum = newNum | 1;
                        }
                    }
                    num = newNum;
                    break;
            }
        }
        Console.WriteLine(num);
    }
}

