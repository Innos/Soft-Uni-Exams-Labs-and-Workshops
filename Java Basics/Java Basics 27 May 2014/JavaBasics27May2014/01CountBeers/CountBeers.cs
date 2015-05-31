using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class CountBeers
{
    static void Main(string[] args)
    {
        int stacks = 0;
        int beerAmount = 0;
        string input = Console.ReadLine();
        while (input != "End")
        {
            int number = int.Parse(input.Split(' ')[0]);
            string type = input.Split(' ')[1];
            if (type.Contains("stacks"))
            {
                beerAmount = beerAmount + (number * 20);
            }
            else
            {
                beerAmount = beerAmount + number;
            }
            input = Console.ReadLine();
        }
        stacks = beerAmount / 20;
        beerAmount = beerAmount % 20;
        Console.WriteLine("{0} stacks + {1} beers",stacks,beerAmount);
        Console.ReadLine();
    }
}

