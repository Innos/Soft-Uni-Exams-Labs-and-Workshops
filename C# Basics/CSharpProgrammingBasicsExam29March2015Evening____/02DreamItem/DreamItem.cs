using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class DreamItem
{
    static void Main(string[] args)
    {
        decimal money = 0;
        int daysWorking = 0;
        string[] input = Console.ReadLine().Split('\\');

        string month = input[0];
        decimal wage = decimal.Parse(input[1]);
        decimal hoursPerDay = decimal.Parse(input[2]);
        decimal itemPrice = decimal.Parse(input[3]);

        switch(month)
        {
            case "Feb": daysWorking = 18; break;
            case "Apr": 
            case "June":
            case "Sept":
            case "Nov": daysWorking = 20; break;
            default : daysWorking = 21; break;
        }
        money = daysWorking * hoursPerDay * wage;
        if (money > 700) money = money * 1.1m;
        if(money >= itemPrice)
        {
            Console.WriteLine("Money left = {0:F2} leva.", money - itemPrice);
        }
        else
        {
            Console.WriteLine("Not enough money. {0:F2} leva needed.",itemPrice - money);
        }
    }
}

