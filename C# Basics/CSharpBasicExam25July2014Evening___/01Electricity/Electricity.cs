using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Electricity
{
    static void Main(string[] args)
    {
        double lampConsumption = 100.53;
        double compConsumption = 125.90;
        int lamps = 0;
        int computers = 0;
        int floors = int.Parse(Console.ReadLine());
        int flats = int.Parse(Console.ReadLine());
        int hours = int.Parse(Console.ReadLine().Split(':')[0]);
        //int minutes = int.Parse(Console.ReadLine().Split(':')[1]);
        if(hours >= 14 && hours < 19)
        {
            lamps = 2;
            computers = 2;
        }
        else if(hours >= 19 && hours < 24 )
        {
            lamps = 7;
            computers = 6;
        }
        else if(hours >= 0 && hours < 9)
        {
            lamps = 1;
            computers = 8;
        }
        double wats = (floors * flats) * (lamps * lampConsumption) + (floors * flats) * (computers * compConsumption);
        Console.WriteLine("{0:0} Watts",Math.Truncate(wats));
    }
}

