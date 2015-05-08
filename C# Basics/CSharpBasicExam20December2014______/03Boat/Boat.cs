using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Boat
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int boatHeight = (n - 1) / 2;
        int boatWidth = n * 2;
        int leftSpace = n-1;
        int sail = 1;
        for (int i = 0; i < n; i++)
        {
            if(i == n/2)
            {
                Console.WriteLine("{0}{1}",new string('*',sail),new string('.',n));
            }
            else if( i < n/2)
            {
                Console.WriteLine("{0}{1}{2}",new string('.',leftSpace),new string('*',sail),new string('.',n));
                leftSpace -= 2;
                sail += 2;
            }
            else
            {
                leftSpace += 2;
                sail -= 2;
                Console.WriteLine("{0}{1}{2}", new string('.', leftSpace), new string('*', sail), new string('.', n));
            }
        }
        leftSpace = 0;
        for (int i = 0; i < boatHeight; i++)
        {
            Console.WriteLine("{0}{1}{0}",new string('.',leftSpace),new string('*',boatWidth));
            leftSpace++;
            boatWidth -= 2;
        }
    }
}

