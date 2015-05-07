using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class NewHouse
{
    static void Main(string[] args)
    {
        int height = int.Parse(Console.ReadLine());
        for (int i = 1; i <= height; i = i + 2)
        {
            string space = new string('-', (height - i) / 2);
            string roof = new string('*', i);
            Console.WriteLine("{0}{1}{0}", space, roof);
        }
        for (int i = 1; i <= height; i++)
        {
            string row = new string('*', height - 2);
            Console.WriteLine("{0}{1}{0}", '|', row);
        }
    }
}

