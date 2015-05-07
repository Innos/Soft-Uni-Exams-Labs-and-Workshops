using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class BitKiller
{
    static void Main(string[] args)
    {
        int counter = 0;
        int bitcounter = 0;
        int newNumber = 0;
        int sequence = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());
        for (int i = 1; i <= sequence; i++)
        {
            int number = int.Parse(Console.ReadLine());
            for (int bit = 7; bit >= 0; bit--)
            {
                if (!(step == 1 && counter > 0 || counter % step == 1))
                {
                    int bitValue = (number >> bit) & 1;
                    newNumber = newNumber << 1;
                    newNumber = newNumber | bitValue;
                    bitcounter++;
                    if (bitcounter == 8)
                    {
                        Console.WriteLine(newNumber);
                        newNumber = 0;
                        bitcounter = 0;
                    }
                }
                counter++;
            }
        }
        if (bitcounter > 0)
        {
            newNumber = newNumber << (8 - bitcounter);
            Console.WriteLine(newNumber);
        }
    }
}

