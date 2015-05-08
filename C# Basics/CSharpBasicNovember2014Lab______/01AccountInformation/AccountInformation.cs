using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class AccountInformation
{
    static void Main(string[] args)
    {
        string firstName = Console.ReadLine();
        string lastName = Console.ReadLine();
        string cliendID = Console.ReadLine();
        decimal accBalance = decimal.Parse(Console.ReadLine());
        Console.WriteLine("Hello, {0} {1}", firstName, lastName);
        Console.WriteLine("Client id: {0}", cliendID);
        Console.WriteLine("Total balance: {0:F2}", accBalance);
        Console.WriteLine("Active: {0}", accBalance >= 0 ? "yes" : "no");
    }
}

