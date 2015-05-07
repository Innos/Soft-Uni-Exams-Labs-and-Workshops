using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class RockLq
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int width = 3 * n;
        int height = 2 * n;
        int sideSpace = n;
        int midSpace = n;

        Console.WriteLine("{0}{1}{0}", new string('.', sideSpace), new string('*', midSpace));
        midSpace = n - 2;

        for (int i = 1; i < n / 2 + 1; i++)
        {
            sideSpace -= 2;
            midSpace += 4;
            Console.WriteLine("{0}*{1}*{0}", new string('.', sideSpace), new string('.', midSpace));

        }
        sideSpace = n-2;
        midSpace = n;

        Console.WriteLine("*{0}*{1}*{0}*",new string('.',sideSpace),new string('.',midSpace));
        int betweenSpace = 1;

        for (int i = 0; i < n/2-1; i++)
        {
            sideSpace -= 2;
            Console.WriteLine("*{0}*{1}*{2}*{1}*{0}*",new string('.',sideSpace),new string('.',betweenSpace),new string('.',midSpace));
            betweenSpace += 2;
        }
        sideSpace = n-1;
        midSpace = n;
        for (int i = 1; i < n; i++)
        {
            Console.WriteLine("{0}*{1}*{0}",new string('.',sideSpace), new string('.',midSpace));
            sideSpace -= 1;
            midSpace += 2;
        }

        Console.WriteLine("{0}",new string('*',width));
    }
}

