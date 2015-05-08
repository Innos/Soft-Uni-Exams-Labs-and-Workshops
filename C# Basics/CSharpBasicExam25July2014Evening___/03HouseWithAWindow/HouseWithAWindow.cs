using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class HouseWithAWindow
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int width = N * 2 - 1;
        int height = N * 2 + 2;
        for (int i = 0; i < height; i++)
        {
            if(i == 0)
            {
                Console.WriteLine("{0}*{0}",new string('.',N-1));
            }
            else if ( i < N)
            {
                int midspace = i * 2 - 1;
                Console.WriteLine("{0}*{1}*{0}",new string('.',(width-2-midspace)/2),new string('.',midspace));
            }
            else if (i == N || i == height-1)
            {
                Console.WriteLine("{0}",new string('*',width));
            }
            else if ((i > N + N / 4) && (i < height - 1 - N / 4))
            {
                Console.WriteLine("*{0}{1}{0}*", new string('.',(width - 2 - (N - 3))/2), new string('*',(N - 3)));
            }
            else if ( i < height)
            {
                Console.WriteLine("*{0}*",new string('.',(width-2)));
            }
        }
    }
}

