using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Star
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int width = 2 * n + 1;
        int heigth = 2 * n - (n / 2 - 1);
        for (int i = 0; i <= n/2; i++)
        {
            if(i == 0 )
            {
                Console.WriteLine("{0}*{0}", new string('.',n));
            }
            else if(i < n/2)
            {
                int midSpace = i*2 -1;
                Console.WriteLine("{0}*{1}*{0}", new string('.',(width - 2 - midSpace)/2),new string('.',midSpace));
            }
            else if(i == n/2)
            {
                int midSpace = n - 1;
                Console.WriteLine("{0}{1}{0}",new string('*',(width-midSpace)/2),new string('.',midSpace));
            }
        }
        for (int i = 1; i < n/2; i++)
        {
            Console.WriteLine("{0}*{1}*{0}",new string('.',i),new string('.',width-2-i*2));
        }
        for (int i = n/2; i >0; i--)
        {
            if(i == n/2)
            {
                Console.WriteLine("{0}*{1}*{1}*{0}", new string('.', i), new string('.', n / 2 - 1));
            }
            else
            {
                Console.WriteLine("{0}*{1}*{2}*{1}*{0}", new string('.', i), new string('.', n / 2 - 1), new string('.', (n / 2 - i) * 2 - 1));
            }
        }
         Console.WriteLine("{0}{1}{0}",new string('*',n/2+1),new string('.',width-(n/2+1)*2));
    }
}

