using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Disk
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int r = int.Parse(Console.ReadLine());
        for (int rows = (N/2); rows >= -(N/2); rows--)
        {
            for (int cols = -(N/2); cols <= (N/2); cols++)
            {
                if((rows*rows + cols*cols)<= r*r)
                {
                    Console.Write('*');
                }
                else
                {
                    Console.Write('.');
                }
            }
            Console.WriteLine();
        }
    }
}

