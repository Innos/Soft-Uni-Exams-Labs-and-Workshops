using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class HayvanNumbers
{
    static void Main(string[] args)
    {
        int solutions = 0;
        int sum = int.Parse(Console.ReadLine());
        int diff = int.Parse(Console.ReadLine());
        for (int num1 = 555; num1 <= 999; num1++)
        {
            int num2 = num1 + diff;
            int num3 = num2 + diff;
            if((GetSumOfDigits(num1) + GetSumOfDigits(num2)+ GetSumOfDigits(num3) == sum) && num3 <= 999 
                && isViable(num1) && isViable(num2) && isViable(num3))
            {
                Console.WriteLine("{0}{1}{2}",num1,num2,num3);
                solutions++;
            }
        }
        if(solutions == 0)
        {
            Console.WriteLine("No");
        }
    }

    private static int GetSumOfDigits(int num)
    {
        int sum = 0;
        while (num > 0)
        {
            sum = sum + (num % 10);
            num = num / 10;
        }
        return sum;
    }
    private static bool isViable(int num)
    {
        bool isViable = true;
        string number = num.ToString();
        foreach(var digit in number)
        {
            if(digit < '5' || digit > '9')
            {
                isViable = false;
            }
        }
        return isViable;
    }
}

