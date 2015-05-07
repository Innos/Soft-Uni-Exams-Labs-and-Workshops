using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Cinema
{
    static void Main(string[] args)
    {
        double price = 0;
        string type = Console.ReadLine();
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());
        switch(type)
        {
            case "Premiere": price = 12.00;break;
            case "Normal": price = 7.50; break;
            case "Discount": price = 5.00; break;
        }
        Console.WriteLine("{0:F2} leva",rows*cols*price);
    }
}
