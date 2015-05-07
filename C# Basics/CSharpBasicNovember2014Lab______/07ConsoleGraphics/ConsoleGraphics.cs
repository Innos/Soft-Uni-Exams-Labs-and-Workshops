using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ConsoleGraphics
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i <= n; i++)
        {
            if (i < 2)
            {
                Console.WriteLine("{0}",new string('*',n*2));
            }
            else
            {
                Console.WriteLine("{0}{1}{0}",new string('*',n/2+1),new string(' ',n-1));
            }
        }
        for (int i = 0; i < 2; i++)
        {
            Console.WriteLine("{0}",new string('~',n*2));
        }
    }
}

