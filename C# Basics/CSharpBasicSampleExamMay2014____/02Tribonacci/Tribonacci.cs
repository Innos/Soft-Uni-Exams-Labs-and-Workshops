using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;


class Tribonacci
{
    static void Main(string[] args)
    {
        BigInteger elementN = 0;
        BigInteger element1 = BigInteger.Parse(Console.ReadLine());
        BigInteger element2 = BigInteger.Parse(Console.ReadLine());
        BigInteger element3 = BigInteger.Parse(Console.ReadLine());
        int N = int.Parse(Console.ReadLine());
        if(N == 1)
        {
            Console.WriteLine(element1);
        }
        else if(N == 2)
        {
            Console.WriteLine(element2);
        }
        else if(N == 3)
        {
            Console.WriteLine(element3);
        }
        else
        {
            for (int i = 4; i <= N; i++)
            {
                elementN = element1 + element2 + element3;
                element1 = element2;
                element2 = element3;
                element3 = elementN;
            }
            Console.WriteLine(elementN);
        }
    }
}

