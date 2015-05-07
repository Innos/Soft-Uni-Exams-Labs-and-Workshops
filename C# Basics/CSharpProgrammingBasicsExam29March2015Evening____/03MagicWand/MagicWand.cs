using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class MagicWand
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int width = n*3 + 2;

        Console.WriteLine("{0}*{0}",new string('.',width/2));

        for (int i = 0; i < (n/2+1); i++)
        {
            int midSpace = (i * 2) + 1;
            Console.WriteLine("{0}*{1}*{0}",
                new string('.',(width - 2 - midSpace)/2),
                new string('.', midSpace));
        }

        Console.WriteLine("{0}{1}{0}",new string('*',n),new string('.',n+2));

        for (int i = 1; i <= n/2; i++)
        {
            Console.WriteLine("{0}*{1}*{0}",new string('.',i),new string('.',width - 2 -i*2));
        }
        for (int i = n/2; i > 0; i--)
        {
            Console.WriteLine("{0}*{1}*{2}*{3}*{2}*{1}*{0}",
                new string('.',i-1),
                new string('.',n/2),
                new string('.',n/2-i),
                new string('.',n));
        }

        Console.WriteLine("{0}{1}*{2}*{1}{0}",
            new string('*',n/2+1),
            new string('.',n/2),
            new string('.',n));

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("{0}*{1}*{0}",
                new string('.',n),
                new string('.',n));
        }

        Console.WriteLine("{0}{1}{0}",
            new string('.',n),
            new string('*',n+2));
    }
}

