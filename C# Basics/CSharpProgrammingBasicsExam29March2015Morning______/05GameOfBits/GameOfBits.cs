using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class GameOfBits
{
    static void Main(string[] args)
    {
        uint number = uint.Parse(Console.ReadLine());
        string command = Console.ReadLine();
        while (command != "Game Over!")
        {
            uint newNumber = 0;
            for (int bit = 31; bit >= 0; bit--)
            {
                if (command == "Odd" && bit % 2 == 0)
                {
                    uint mask = (number >> bit) & 1;
                    newNumber = newNumber << 1;
                    newNumber = newNumber | mask;
                }
                else if (command == "Even" && bit % 2 == 1)
                {
                    uint mask = (number >> bit) & 1;
                    newNumber = newNumber << 1;
                    newNumber = newNumber | mask;
                }
            }
            number = newNumber;
            command = Console.ReadLine();
        }
        Console.WriteLine("{0} -> {1}",number,Count1Bits(number));
    }
    static int Count1Bits(uint num)
    {
        int oneBits = 0;
        while (num > 0)
        {
            num = num & (num - 1);
            oneBits++;
        }
        return oneBits;
    }
}

