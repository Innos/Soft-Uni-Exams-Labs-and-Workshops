using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Headphones
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int width = n * 2 + 1;
        int height = n * 2;

        Console.WriteLine("{0}{1}{0}", new string('-', n/2),new string('*',n+2));

        for (int i = 1; i < n; i++)
        {
            Console.WriteLine("{0}*{1}*{0}",new string('-',n/2),new string('-',n));
        }

        int midspace = n;
        int sidespace = n / 2;
        int headphones = 1;
        for (int i = 0; i < n; i++)
        {
            if(i < n/2)
            {
                Console.WriteLine("{0}{1}{2}{1}{0}",new string('-',sidespace),new string('*',headphones),new string('-',midspace));
                sidespace -= 1;
                midspace -= 2;
                headphones += 2;
            }
            else if( i == n/2)
                Console.WriteLine("{0}{1}{2}{1}{0}", new string('-', sidespace), new string('*', headphones), new string('-', midspace));
            else
            {
                sidespace +=1;
                midspace += 2;
                headphones -=2;
                Console.WriteLine("{0}{1}{2}{1}{0}",new string('-',sidespace),new string('*',headphones),new string('-',midspace));
            }
        }
    }
}

