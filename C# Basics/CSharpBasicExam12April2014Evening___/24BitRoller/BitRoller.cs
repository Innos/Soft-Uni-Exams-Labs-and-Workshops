using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class BitRoller
{
    static void Main(string[] args)
    {
        uint number = uint.Parse(Console.ReadLine());
        int frozenPosition = int.Parse(Console.ReadLine());
        int rolls = int.Parse(Console.ReadLine());
        uint frozenBit = (number >> frozenPosition) & 1;
        uint rotatedNumber = 0;
        uint modifiedNumber = 0;
        for (int i = 18; i >= 0; i--)
        {
            if(i != frozenPosition)
            {
                uint mask = (number >> i) & 1;
                rotatedNumber = rotatedNumber << 1;
                rotatedNumber = rotatedNumber | mask;
            }
        }
        for (int l = 0; l < rolls; l++)
        {
            uint mask = rotatedNumber & 1;
            rotatedNumber = (rotatedNumber >> 1) | (mask << 17);
        }
        for (int k = 18; k >= 0; k--)
        {
            if(k == frozenPosition)
            {
                modifiedNumber = (modifiedNumber << 1) | frozenBit;
            }
            else if(k > frozenPosition)
            {
                modifiedNumber = (modifiedNumber << 1) | ((rotatedNumber >> k - 1) & 1);
            }
            else if (k < frozenPosition)
            {
                modifiedNumber = (modifiedNumber << 1) | ((rotatedNumber >> k) & 1);
            }
        }
        Console.WriteLine(modifiedNumber);
    }
}

