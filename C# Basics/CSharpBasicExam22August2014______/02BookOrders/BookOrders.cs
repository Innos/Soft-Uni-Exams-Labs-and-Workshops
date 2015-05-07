using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class BookOrders
{
    static void Main(string[] args)
    {
        int totalBooks = 0;
        decimal totalPrice = 0;
        decimal discount = 0;
        int orders = int.Parse(Console.ReadLine());
        for (int i = 0; i < orders; i++)
        {
            int packets = int.Parse(Console.ReadLine());
            int bookPerPacket = int.Parse(Console.ReadLine());
            decimal price = decimal.Parse(Console.ReadLine());

            if (packets < 10) discount = 1;
            else if (packets >= 10 && packets < 20) discount = 0.95M;
            else if (packets >= 20 && packets < 30) discount = 0.94M;
            else if (packets >= 30 && packets < 40) discount = 0.93M;
            else if (packets >= 40 && packets < 50) discount = 0.92M;
            else if (packets >= 50 && packets < 60) discount = 0.91M;
            else if (packets >= 60 && packets < 70) discount = 0.90M;
            else if (packets >= 70 && packets < 80) discount = 0.89M;
            else if (packets >= 80 && packets < 90) discount = 0.88M;
            else if (packets >= 90 && packets < 100) discount = 0.87M;
            else if (packets >= 100 && packets < 110) discount = 0.86M;
            else if (packets >= 110) discount = 0.85M;
            totalBooks = totalBooks + packets * bookPerPacket;
            totalPrice = totalPrice + (packets * bookPerPacket) * (price * discount);

        }
        Console.WriteLine(totalBooks);
        Console.WriteLine("{0:F2}",totalPrice);
    }
}

