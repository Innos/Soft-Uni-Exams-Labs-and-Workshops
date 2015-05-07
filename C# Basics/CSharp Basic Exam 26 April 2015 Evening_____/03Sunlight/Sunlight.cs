using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Sunlight
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int width = n * 3;
        for (int i = 0; i < n; i++)
        {
            if(i == 0)
            {
                Console.WriteLine("{0}*{0}",new string('.',n+n/2));
            }
            else
            {
                int midSpace = (n+n/2) - i -1;
                Console.WriteLine("{0}*{1}*{1}*{0}",new string('.',i),new string('.',midSpace));
            }
        }
        for (int i = 0; i < n; i++)
        {
            if(i == n/2)
            {
                Console.WriteLine("{0}",new string('*',width));
            }
            else
            {
                Console.WriteLine("{0}{1}{0}",new string('.',n),new string('*',n));
            }
        }
        for (int i = n-1; i >= 0; i--)
        {
            if(i == 0)
            {
                Console.WriteLine("{0}*{0}", new string('.', n + n / 2));
            }
            else
            {
                int midSpace = (n + n / 2) - i - 1;
                Console.WriteLine("{0}*{1}*{1}*{0}", new string('.', i), new string('.', midSpace));
            }
        }
    }
}

