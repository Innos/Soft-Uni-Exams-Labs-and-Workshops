using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Arrow
{
    static void Main(string[] args)
    {
        int width = int.Parse(Console.ReadLine());
        int height = width * 2 - 1;
        for (int i = 1; i <= height; i++)
        {
            if (i == 1)
            {
                string side = new string('.', width / 2);
                string middle = new string('#', width);
                Console.WriteLine("{0}{1}{0}", side, middle);
            }
            else if (i == width)
            {
                string side = new string('#', (width / 2 + 1));
                string middle = new string('.', width - 2);
                Console.WriteLine("{0}{1}{0}", side, middle);
            }
            else if(i == height)
            {
                string side = new string('.', i - width);
                Console.WriteLine("{0}#{0}",side);
            }
            else if (i < width)
            {
                string side = new string('.', width / 2);
                string middle = new string('.', width - 2);
                Console.WriteLine("{0}#{1}#{0}", side, middle);
            }
            else if (i > width)
            {
                int sidelength = i - width;
                string side = new string('.', sidelength);
                string middle = new string('.', (height - (sidelength * 2) - 2));
                Console.WriteLine("{0}#{1}#{0}",side,middle);
            }
        }
    }
}

