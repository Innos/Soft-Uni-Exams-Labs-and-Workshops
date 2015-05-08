using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class PiggyBank
{
    static void Main(string[] args)
    {
        int tankPrice = int.Parse(Console.ReadLine());
        int partyDays = int.Parse(Console.ReadLine());
        int normalDays = 30 - partyDays;
        int moneyGrowth = normalDays * 2 - partyDays * 5;
        decimal requiredMonths = 0;
        if (moneyGrowth < 0)
        {
            Console.WriteLine("never");
        }
        else
        {
            requiredMonths = Math.Ceiling((decimal)tankPrice / (decimal)moneyGrowth);
            int years = (int)(requiredMonths / 12);
            int months = (int)(requiredMonths % 12);
            Console.WriteLine("{0} years, {1} months",years,months);
        }
    }
}

