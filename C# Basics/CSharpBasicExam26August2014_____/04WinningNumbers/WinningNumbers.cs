using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class WinningNumbers
{
    static void Main(string[] args)
    {
        int solutions = 0;
        int letSum = 0;
        string input = Console.ReadLine().ToLower();
        foreach(var letter in input)
        {
            letSum += (letter - 'a' + 1);
        }
        for (int x1 = 0; x1 <= 9; x1++)
        {
            for (int x2 = 0; x2 <= 9; x2++)
            {
                for (int x3 = 0; x3 <= 9; x3++)
                {
                    for (int y1 = 0; y1 <= 9; y1++)
                    {
                        for (int y2 = 0; y2 <= 9; y2++)
                        {
                            for (int y3 = 0; y3 <= 9; y3++)
                            {
                                int productX = x1 * x2 * x3;
                                int productY = y1 * y2 * y3;
                                if (productX == productY && productY == letSum)
                                {
                                    Console.WriteLine("{0}{1}{2}-{3}{4}{5}",x1,x2,x3,y1,y2,y3);
                                    solutions++;
                                }
                            }
                        } 
                    }
                }
            }
        }
        if(solutions == 0)
        {
            Console.WriteLine("No");
        }
    }
    public static int ProductOfDigits(int num)
    {
        string number = num.ToString();
        int product = 0;
        foreach (var digit in number)
        {
            product *= int.Parse(digit.ToString());
        }
        return product;
    }
}

