using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class TravellerBob
{
    static void Main(string[] args)
    {
        string year = Console.ReadLine();
        int contractMonths = int.Parse(Console.ReadLine());
        int familyMonths = int.Parse(Console.ReadLine());
        int normalMonths = 12 - familyMonths - contractMonths;
        int cTravelsPerMonth = 12;
        int cTravels = contractMonths * cTravelsPerMonth;
        int fTravels = familyMonths * 4;
        decimal nTravels = normalMonths * cTravelsPerMonth * (3 / 5m);
        decimal totalTravels = cTravels + fTravels + nTravels;
        if(year == "leap")
        {
            totalTravels = totalTravels * 1.05m;
        }
        Console.WriteLine((int)totalTravels);
    }
}

