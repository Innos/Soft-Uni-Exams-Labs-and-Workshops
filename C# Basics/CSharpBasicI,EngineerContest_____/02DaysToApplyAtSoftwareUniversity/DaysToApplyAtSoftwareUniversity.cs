using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class DaysToApplyAtSoftwareUniversity
{
    static void Main(string[] args)
    {
        string name = Console.ReadLine();
        DateTime semesterStart = new DateTime(2015,4,28);
        int days = (semesterStart.Subtract(DateTime.Now)).Days;
        Console.WriteLine("{0}, you have only {1} days to apply for the spring semester at Software University!",name,0);
    }
}

