using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class TorrentPirate
{
    static void Main(string[] args)
    {
        int totalSize = int.Parse(Console.ReadLine());
        int ticketPrice = int.Parse(Console.ReadLine());
        int wifeSpending = int.Parse(Console.ReadLine());
        decimal movies = totalSize / 1500m;
        decimal time = (totalSize /2m )/3600m;
        decimal cinemaPrice = ticketPrice * movies;
        decimal wifePrice = time * wifeSpending;
        if(cinemaPrice < wifePrice)
        {
            Console.WriteLine("cinema -> {0:F2}lv",cinemaPrice);
        }
        else
        {
            Console.WriteLine("mall -> {0:F2}lv",wifePrice);
        }
    }
}

