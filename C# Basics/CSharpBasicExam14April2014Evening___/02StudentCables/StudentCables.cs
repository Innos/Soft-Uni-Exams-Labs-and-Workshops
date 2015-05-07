using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class StudentCables
{
    static void Main(string[] args)
    {
        int usableCables = 0;
        int totalLength = 0;
        int cables = int.Parse(Console.ReadLine());
        for (int i = 0; i < (cables*2); i+=2)
        {
            int length = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            if(length < 20 && type == "centimeters")
            {
            }
            else if(type == "meters")
            {
                totalLength += (length * 100);
                usableCables++;
            }
            else
            {
                totalLength += length;
                usableCables++;
            }
        }
        totalLength = totalLength - (3 * (usableCables-1));
        Console.WriteLine(totalLength/504);
        Console.WriteLine(totalLength%504);
    }
}

