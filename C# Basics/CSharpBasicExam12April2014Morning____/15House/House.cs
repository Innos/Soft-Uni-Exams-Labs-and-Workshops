using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class House
{
    static void Main(string[] args)
    {
        int width = int.Parse(Console.ReadLine());
        for (int i = 1; i <= width; i++)
        {
            if(i == 1)
            {
                string space = new string('.', (width - 1) / 2);
                Console.WriteLine("{0}*{0}",space);
            }
            else if (i == (width + 1) / 2)
            {
                string roof = new string('*', width);
                Console.WriteLine(roof);
            }
            else if (i < (width + 1) / 2)
            {
                int atticspace = (i - 1) * 2 - 1;
                string attic = new string('.', atticspace);
                string roof = string.Format("*{0}*",attic);
                string space = new string('.', (width - (atticspace+2)) / 2);
                Console.WriteLine("{0}{1}{0}", space, roof);
            }
            else
            {
                int wallspace = width / 4;
                string space = new string('.', wallspace);
                string interior = new string('.', (width - 2) - (wallspace * 2));
                if(i == width)
                {
                    interior = new string('*', (width - 2) - (wallspace * 2));
                }
                Console.WriteLine("{0}*{1}*{0}",space,interior);
            }
        }
    }
}

