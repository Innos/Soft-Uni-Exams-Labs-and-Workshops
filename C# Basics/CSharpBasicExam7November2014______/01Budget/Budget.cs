using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Budget
{
    static void Main(string[] args)
    {
        int totalMoney = int.Parse(Console.ReadLine());
        int weekdaysOut = int.Parse(Console.ReadLine());
        int weekendsHome = int.Parse(Console.ReadLine());
        int normalWeekends = 4 - weekendsHome;
        int normalWeekdays = 22 - weekdaysOut;
        int weekdaysOutCost = (int)Math.Truncate(totalMoney*0.03m) + 10;
        int totalSpend = weekdaysOut * weekdaysOutCost + normalWeekends * 40 + 150 + normalWeekdays * 10;
        if(totalMoney > totalSpend)
        {
            Console.WriteLine("Yes, leftover {0}.",totalMoney-totalSpend);
        }
        else if( totalSpend> totalMoney)
        {
            Console.WriteLine("No, not enough {0}.",Math.Abs(totalSpend - totalMoney));
        }
        else if(totalMoney == totalSpend)
        {
            Console.WriteLine("Exact Budget.");
        }
    }
}

