using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Eclipse
{
    static void Main(string[] args)
    {
        int height = int.Parse(Console.ReadLine());
        for (int i = 1; i <= height; i++)
        {
            if(i == 1 || i == height)
            {
                string frame = new string('*', height * 2 - 2);
                string side = string.Format("{0}{1}{0}", ' ', frame);
                string space = new string(' ', height - 1);
                Console.WriteLine("{0}{1}{0}",side,space);
            }
            else if(i>1 && i < height)
            {
                string lense = new string('/', height * 2 - 2);
                string side = string.Format("{0}{1}{0}", '*', lense);
                string bridge = new string(' ', height - 1);
                if(i == height/2 + 1)
                {
                    bridge = new string('-', height - 1);
                }
                Console.WriteLine("{0}{1}{0}",side,bridge);
            }
        }
    }
}

