using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class KingOfThieves
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        char type = char.Parse(Console.ReadLine());
        int growth = -1;
        int sideSpace = n / 2;
        for (int i = 0; i < n; i++)
        {
            if (i == n / 2) growth = 1;
            int midSpace = n - 2 * sideSpace;
            Console.WriteLine("{0}{1}{0}",new string('-',sideSpace),new string(type,midSpace));
            sideSpace += growth;
            
        }
    }
}

