using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class SandGlass
{
    static void Main(string[] args)
    {
        int width = int.Parse(Console.ReadLine());
        for (int i = 0; i < width; i++)
        {
            if (i <= width / 2)
            {
                int hourglassPieces = width - (i * 2);
                string hourglass = new string('*', hourglassPieces);
                string space = new string('.', (width - hourglassPieces)/2);
                Console.WriteLine("{0}{1}{0}", space, hourglass);
            }
            else if (i > width / 2)
            {
                int hourglassPieces = width - ((width - (i+1)) * 2);
                string hourglass = new string('*', hourglassPieces);
                string space = new string('.', (width - hourglassPieces)/2);
                Console.WriteLine("{0}{1}{0}", space, hourglass);
            }
        }
    }
}

