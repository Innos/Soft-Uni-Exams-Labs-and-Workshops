using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class CompoundInterest
{
    static void Main(string[] args)
    {
        decimal priceTV = decimal.Parse(Console.ReadLine());
        decimal years = decimal.Parse(Console.ReadLine());
        decimal interestBank = decimal.Parse(Console.ReadLine());
        decimal interestFriend = decimal.Parse(Console.ReadLine());
        decimal bankLoan = priceTV * (decimal)Math.Pow((double)(1 + interestBank), (double)years);
        decimal friendLoan = priceTV * (1 + interestFriend);
        if (friendLoan <= bankLoan)
        {
            Console.WriteLine("{0:F2} Friend", friendLoan);
        }
        else
        {
            Console.WriteLine("{0:F2} Bank", bankLoan);
        }
            
    }
}

