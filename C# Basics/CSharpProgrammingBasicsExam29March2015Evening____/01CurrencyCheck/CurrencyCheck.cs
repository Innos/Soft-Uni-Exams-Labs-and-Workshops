using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class CurrencyCheck
{
    static void Main(string[] args)
    {
        decimal[] prices = new decimal[5];
        double ruble = double.Parse(Console.ReadLine());
        double dollars = double.Parse(Console.ReadLine());
        double euro = double.Parse(Console.ReadLine());
        double leva2 = double.Parse(Console.ReadLine());
        double leva = double.Parse(Console.ReadLine());
        prices[0] = (decimal)(ruble / 100 * 3.5);
        prices[1] = (decimal)(dollars * 1.5);
        prices[2] = (decimal)(euro * 1.95);
        prices[3] = (decimal)(leva2 / 2);
        prices[4] = (decimal)(leva);
        Console.WriteLine("{0:F2}",prices.Min());
    }
}

