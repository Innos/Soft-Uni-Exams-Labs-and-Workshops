using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int height = (3 * n / 2) - 1;
        int width = 3 * n;
        for (int row = 0; row < height; row++)
        {
            if(row == 0)
            {
                Console.WriteLine("{0}{1}{0}",new string('.',n),new string('*',n));
            }
            else if(row<n/2)
            {
                Console.WriteLine("{0}*{1}*{0}",new string('.',n-row),new string('.',width - 2 - (n-row)*2));
            }
            else if(row == n/2)
            {
                Console.WriteLine("{0}{1}{0}",new string('*',n-(row-1)),new string('.',width-(n-(row-1))*2));
            }
            else if(row == n-1)
            {
                Console.WriteLine("{0}",new string('*',width));
            }
            else if(row < n-1)
            {
                Console.WriteLine("*{0}*",new string('.',width-2));
            }
            else if(row == height-1)
            {
                Console.WriteLine("{0}{1}{2}{1}{0}",new string('.',n/2),new string('*',n/2+1),new string('.',width-(n+1)*2));
            }
            else if(row < height-1)
            {
                Console.WriteLine("{0}*{1}*{2}*{1}*{0}",new string('.',n/2),new string('.',n/2-1),new string('.',width-(n+1)*2));
            }
        }
    }
}

