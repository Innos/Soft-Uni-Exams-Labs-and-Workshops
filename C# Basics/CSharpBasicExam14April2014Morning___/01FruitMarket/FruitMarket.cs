using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class FruitMarket
{
    static void Main(string[] args)
    {
        double bananaPrice = 1.80;
        double cucumberPrice = 2.75;
        double tomatoPrice = 3.20;
        double orangePrice = 1.60;
        double applePrice = 0.86;
        double sales = 0;
        double discount = 1;
        string day = Console.ReadLine();
        switch (day)
        {
            case "Friday": discount = 0.9; break;
            case "Sunday": discount = 0.95; break;
            case "Tuesday":
                bananaPrice *= 0.8;
                orangePrice *= 0.8;
                applePrice *= 0.8; break;
            case "Wednesday":
                cucumberPrice *= 0.9;
                tomatoPrice *= 0.9; break;
            case "Thursday": bananaPrice *= 0.7; break;
        }
        for (int i = 0; i < 3; i++)
        {
            double quantity = double.Parse(Console.ReadLine());
            string product = Console.ReadLine();
            switch (product)
            {
                case "banana": sales = sales + (quantity * bananaPrice); break;
                case "cucumber": sales = sales + (quantity * cucumberPrice); break;
                case "tomato": sales = sales + (quantity * tomatoPrice); break;
                case "orange": sales = sales + (quantity * orangePrice); break;
                case "apple": sales = sales + (quantity * applePrice); break;
            }
        }
        Console.WriteLine("{0:0.00}",sales*discount);
    }
}

