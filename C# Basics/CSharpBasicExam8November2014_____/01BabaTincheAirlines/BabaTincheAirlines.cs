using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class BabaTincheAirlines
{
    static void Main(string[] args)
    {
        int firstSeats = 12;
        int businessSeats = 28;
        int economySeats = 50;
        int firstClassPrice = 7000;
        int businessClassPrice = 3500;
        int economyClassPrice = 1000;
        int[] firstClass = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        int[] businessClass = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        int[] economyClass = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        int firstRegulars = firstClass[0] - firstClass[1];
        int businessRegulars = businessClass[0] - businessClass[1];
        int economyRegulars = economyClass[0] - economyClass[1];
        decimal firstTotal = firstRegulars * firstClassPrice + (decimal)(firstClass[1] * firstClassPrice * 0.3) + (decimal)(firstClass[2] * firstClassPrice*0.005);
        decimal businessTotal = businessRegulars * businessClassPrice + (decimal)(businessClass[1] * businessClassPrice * 0.3) + (decimal)(businessClass[2] * businessClassPrice * 0.005);
        decimal economyTotal = economyRegulars * economyClassPrice + (decimal)(economyClass[1] * economyClassPrice * 0.3) + (decimal)(economyClass[2] * economyClassPrice * 0.005);
        decimal profit = firstTotal + businessTotal + economyTotal;
        decimal max = (decimal)(firstSeats * firstClassPrice * 1.005) + (decimal)(businessSeats * businessClassPrice * 1.005) + (decimal)(economySeats * economyClassPrice * 1.005);
        Console.WriteLine((int)profit);
        Console.WriteLine((int)max-(int)profit);
    }
}

