using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;


class PetarsGame
{
    static void Main(string[] args)
    {
        BigInteger sum = 0;
        ulong start = ulong.Parse(Console.ReadLine());
        ulong end = ulong.Parse(Console.ReadLine());
        string replacement = Console.ReadLine();
        for (ulong i = start; i < end; i++)
        {
            if (i%5 == 0)
            {
                sum += i;
            }
            else if(i% 5 != 0)
            {
                sum += i % 5;
            }
        }
        string digit = "";
        string num = sum.ToString();
        if(sum % 2 == 1)
        {
            digit = num.Last().ToString();
            num = num.Replace(digit, replacement);
        }
        else
        {
            digit = num.First().ToString();
            num = num.Replace(digit, replacement);
        }
        foreach (var character in num)
        {
            Console.Write(character);
        }
    }

}

