using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class CheatSheet
{
    static void Main(string[] args)
    {
        long rows = long.Parse(Console.ReadLine());
        long cols = long.Parse(Console.ReadLine());
        long rowStart = long.Parse(Console.ReadLine());
        long colStart = long.Parse(Console.ReadLine());
        for (long i = rowStart; i < rowStart + rows; i++)
        {
            for (long l = colStart; l < colStart + cols; l++)
            {
                if(l == colStart+cols - 1)
                {
                    Console.WriteLine("{0}",i*l);
                }
                else
                {
                    Console.Write("{0} ", i * l);
                }
            }
        }
    }
}

