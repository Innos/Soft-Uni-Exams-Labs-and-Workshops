using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Nums
{
    static void Main(string[] args)
    {
        int start = int.Parse(Console.ReadLine());
        int end = int.Parse(Console.ReadLine());
        for (int i = start; i <= end; i++)
        {
            if(i % 2 == 0)
            {
                Console.WriteLine("{0:F3}",Math.Sqrt(i));
            }
            else
            {
                Console.WriteLine("{0:F3}",Math.Pow(i,2));
            }
        }
    }
}

