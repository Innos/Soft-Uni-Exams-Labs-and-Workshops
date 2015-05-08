using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class WineGlass
{
    static void Main(string[] args)
    {
        int width = int.Parse(Console.ReadLine());
        for (int rows = 1; rows <= width; rows++)
        {
            if (rows <= width / 2)
            {
                string wine = new string('*', width - rows * 2);
                string space = new string('.', rows - 1);
                Console.WriteLine("{0}\\{1}/{0}", space, wine);
            }
            else if (rows > width / 2)
            {
                if (width < 12)
                {
                    if (rows == width)
                    {
                        string bottom = new string('-', width);
                        Console.WriteLine(bottom);
                    }
                    else
                    {
                        string sideSpace = new string('.', (width / 2) - 1);
                        Console.WriteLine("{0}||{0}", sideSpace);
                    }
                }
                else if (width >= 12)
                {
                    if (rows >= width - 1)
                    {
                        string bottom = new string('-', width);
                        Console.WriteLine(bottom);
                    }
                    else
                    {
                        string sideSpace = new string('.', (width / 2) - 1);
                        Console.WriteLine("{0}||{0}", sideSpace);
                    }
                }
            }
        }
    }
}

