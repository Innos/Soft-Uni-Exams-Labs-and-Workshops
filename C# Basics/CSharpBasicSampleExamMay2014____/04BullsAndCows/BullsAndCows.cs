using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class BullsAndCows
{
    static void Main(string[] args)
    {
        bool solutions = false;
        int givenNumber = int.Parse(Console.ReadLine());
        int bulls = int.Parse(Console.ReadLine());
        int cows = int.Parse(Console.ReadLine());
        for (int i = 1111; i <= 9999; i++)
        {
            if (CalculateBullsAndCows(i, givenNumber)[0] == bulls && CalculateBullsAndCows(i, givenNumber)[1] == cows && isViableNumber(i))
            {
                if(solutions)
                {
                    Console.Write(" ");
                }
                Console.Write(i);
                solutions = true;
            }
        }
        if (solutions == false)
        {
            Console.WriteLine("No");
        }
    }
    private static int[] CalculateBullsAndCows(int num, int num2)
    {
        int[] number = new int[4];
        int[] number2 = new int[4];
        bool[] isUsed = new bool[4];
        bool[] isBull = new bool[4];
        int[] bullsAndCows = new int[2];
        string givenNum = num2.ToString();
        for (int l = 3; l >= 0; l--)
        {
            number[l] = num % 10;
            num = num / 10;
            number2[l] = num2 % 10;
            num2 = num2 / 10;
            if (number[l] == number2[l])
            {
                bullsAndCows[0] = bullsAndCows[0] + 1;
                isUsed[l] = true;
                isBull[l] = true;
            }
        }
        for (int i = 0; i < 4; i++)
        {
            if (isBull[i] == false && number2.Contains(number[i]) && HasViableCow(number[i], number2, isUsed))
            {
                bullsAndCows[1] = bullsAndCows[1] + 1;
                int digit = number[i];
                for (int m = 0; m < 4; m++)
                {
                    if(digit == number2[m] && isUsed[m] == false)
                    {
                        isUsed[m] = true;
                        break;
                    }
                }
            }
        }
        return bullsAndCows;
    }
    private static bool HasViableCow(int digit, int[] num2, bool[] isUsed)
    {
        bool hasViable = false;
        for (int i = 0; i < 4; i++)
        {
            if (digit == num2[i] && isUsed[i] == false)
            {
                hasViable = true;
                break;
            }
        }
        return hasViable;
    }
    private static bool isViableNumber(int num)
    {
        bool isViable = true;
        string number = num.ToString();
        foreach(var digit in number)
        {
            if(digit < '1' || digit > '9')
            {
                isViable = false;
            }
        }
        return isViable;
    }
}

