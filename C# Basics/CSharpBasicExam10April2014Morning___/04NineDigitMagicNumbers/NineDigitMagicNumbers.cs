using System;



class NineDigitMagicNumbers
{
    static void Main(string[] args)
    {
        int sum = int.Parse(Console.ReadLine());
        int diff = int.Parse(Console.ReadLine());
        int resultCounter = 0;
        for (int i = 111; i <= 777; i++)
        {
            int num1 = i;
            int num2 = i + diff;
            int num3 = num2 + diff;
            if((SumOfDigits(num1) + SumOfDigits(num2) + SumOfDigits(num3) == sum) && isCorrect(num1) && isCorrect(num2) && isCorrect(num3) && num3 <=777)
            {
                Console.WriteLine("{0}{1}{2}",num1,num2,num3);
                resultCounter++;
            }
        }
        if(resultCounter == 0)
        {
            Console.WriteLine("No");
        }
    }
    private static int SumOfDigits(int num)
    {
        int sum = 0;
        while (num > 0)
        {
            sum = sum + (num % 10);
            num = num / 10;
        }
        return sum;
    }
    private static bool isCorrect(int num)
    {
        string digits = num.ToString();
        foreach (var digit in digits)
        {
            if (digit < '1' || digit > '7')
            {
                return false;
            }
        }
        return true;
    }
}

