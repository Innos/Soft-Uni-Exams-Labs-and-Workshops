using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Plane
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int width = 3 * n;
        int heigth = (n * 3) - (n / 2);

       
        for (int i = 0; i <= n/2 + 2; i++)
        {
            if(i == 0 )
            {
                Console.WriteLine("{0}*{0}", new string('.', (width - 1) / 2));
            }
            else
            {
                int midSpace = i * 2 - 1;
                Console.WriteLine("{0}*{1}*{0}", new string('.', (width - 2 - midSpace) / 2), new string('.', midSpace));
            }
        }
        for (int i = n/2-1; i >0; i--)
        {
            int sideSpace = (i*2)-1; 
            Console.WriteLine("{0}*{1}*{0}",new string('.',sideSpace),new string('.',width-2-sideSpace*2));
        }
        Console.WriteLine("*{0}*{1}*{0}*",new string('.',n-2),new string('.',width-4-(n-2)*2));
        for (int i = n-4; i > 0; i-=2)
        {
            int secondSpace = n-3 -i;
            Console.WriteLine("*{0}*{1}*{2}*{1}*{0}*",new string('.',i),new string('.',secondSpace),new string('.',n));
        }
        for (int i = 1; i <= n; i++)
        {
            if(i == n)
            {
                Console.WriteLine("{0}",new string('*',width));
            }
            else
            {
                Console.WriteLine("{0}*{1}*{0}",new string('.',n-i),new string('.',width-2-(n-i)*2));
            }
        }
    }
}

