using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class BitsAtCrossroads
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        string crossroad = Console.ReadLine();
        uint[] numbers = new uint[n];
        int row;
        int bit;
        int crossRoads = 0;
        while (crossroad != "end")
        {
            row = int.Parse(crossroad.Split()[0]);
            bit = int.Parse(crossroad.Split()[1]);
            numbers[row] = numbers[row] | (((uint)1 << bit));
            //numbers automatically gets filled because arrays mutate when they are changed in a method
            int foundCrossroads = SeedCrossroad(numbers, row, bit);
            crossRoads++;
            crossRoads += foundCrossroads;
            //foreach (var item in numbers)
            //{
            //    Console.WriteLine(Convert.ToString((long)item, 2).PadLeft(n, '0'));
            //}
            crossroad = Console.ReadLine();
        }
        foreach (var number in numbers)
        {
            Console.WriteLine(number);
        }
        Console.WriteLine(crossRoads);
    }
    private static int SeedCrossroad(uint[] numbers, int row, int bit)
    {
        int foundCrossroads = 0;
        int topBorder = numbers.Length - 1;
        int tempRow = row;
        int tempBit = bit;
        int rChange = 1;
        int cChange = 1;
        for (int i = 0; i < 4; i++)
        {
            while (true)
            {
                tempRow += rChange;
                tempBit += cChange;
                if(tempRow < 0 || tempRow > topBorder || tempBit > topBorder || tempBit< 0)
                {
                    break;
                }
                if (((numbers[tempRow] >> tempBit) & 1) == 1)
                {
                    foundCrossroads++;
                }
                else
                {
                    numbers[tempRow] = numbers[tempRow] | ((uint)1 << tempBit);
                }
            }
            tempRow = row;
            tempBit = bit;
            if (i == 0) rChange = -1;
            else if (i == 1) cChange = -1;
            else if (i == 2) rChange = 1;
        }
        return foundCrossroads;
    }
}

