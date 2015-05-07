using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;


class Numerology
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ');
        string[] birthday = input[0].Split('.');
        int day = int.Parse(birthday[0]);
        int month = int.Parse(birthday[1]);
        int year = int.Parse(birthday[2]);
        BigInteger sum = day * month * year;
        if (month % 2 == 1)
        {
            sum = sum * sum;
        }
        sum = sum + CalculateSumOfName(input[1]);
        while(sum>13)
        {
            sum = CalculateSumOfName(sum.ToString());
        }
        Console.WriteLine(sum);

    }
    public static int CalculateSumOfName(string name)
    {
        int sumOfName = 0;
        foreach (var letter in name)
        {
            if (letter >= '0' && letter <= '9')
            {
                sumOfName = sumOfName + int.Parse(letter.ToString());
            }
            else
            {
                if (Char.IsUpper(letter))
                {
                    sumOfName = sumOfName + (letter - 'A' + 1) * 2;
                }
                else
                {
                    sumOfName = sumOfName + (letter - 'a' + 1);
                }
            }

        }
        return sumOfName;
    }
}
