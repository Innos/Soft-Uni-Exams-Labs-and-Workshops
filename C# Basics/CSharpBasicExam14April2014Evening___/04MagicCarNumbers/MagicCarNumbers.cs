using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class MagicCarNumbers
{
    static void Main(string[] args)
    {
        int solutions = 0;
        char[] letters = { 'A', 'B', 'C', 'E', 'H', 'K', 'M', 'P', 'T', 'X' };
        int magicWeight = int.Parse(Console.ReadLine());
        for (int a = 0; a < 10; a++)
        {
            for (int b = 0; b < 10; b++)
            {
                for (int c = 0; c < 10; c++)
                {
                    for (int d = 0; d < 10; d++)
                    {
                        for (int X = 0; X < 10; X++)
                        {
                            for (int Y = 0; Y < 10; Y++)
                            {
                                int weight = a + b + c + d + CalculateWeight(letters[X]) + CalculateWeight(letters[Y]) + 40;
                                if (weight == magicWeight && ViableNumber(a, b, c, d))
                                {
                                    solutions++;
                                }
                            }
                        }
                    }
                }
            }
        }
        Console.WriteLine(solutions);
    }
    private static int CalculateWeight(char letter)
    {
        switch (letter)
        {
            case 'A': return 10;
            case 'B': return 20;
            case 'C': return 30;
            case 'E': return 50;
            case 'H': return 80;
            case 'K': return 110;
            case 'M': return 130;
            case 'P': return 160;
            case 'T': return 200;
            case 'X': return 240;
        }
        return 0;
    }
    private static bool ViableNumber(int a, int b, int c, int d)
    {
        if((a == b && a == c && a == d) ||
            (b == c && c == d) ||
            (a == b && a == c) ||
            (a == b && c == d) ||
            (a == c && b == d) ||
            (a == d && b == c))
        {
            return true;
        }
        return false;
    }
}

