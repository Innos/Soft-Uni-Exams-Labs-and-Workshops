using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class BookProblem
{
    static void Main(string[] args)
    {
        int pages = int.Parse(Console.ReadLine());
        int campDays = int.Parse(Console.ReadLine());
        int pagesPerDay = int.Parse(Console.ReadLine());
        int normalDays = ((30 - campDays) >= 0) ? (30 - campDays) : 0;
        int pagesPerMonth = normalDays * pagesPerDay;
        if(normalDays == 0)
        {
            Console.WriteLine("never");
        }
        else
        {
            decimal monthsNeeded = pages / (decimal)pagesPerMonth;
            Console.WriteLine("{0} years {1} months", (int)(monthsNeeded / 12), Math.Ceiling(monthsNeeded % 12));
        }
    }
}

