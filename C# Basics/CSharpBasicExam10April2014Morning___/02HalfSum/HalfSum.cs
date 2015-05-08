using System;

class HalfSum
{
    static void Main(string[] args)
    {
        int sum1 = 0;
        int sum2 = 0;
        int numberCount = int.Parse(Console.ReadLine());
        for (int i = 1; i <= numberCount; i++)
        {
            int currentNumber = int.Parse(Console.ReadLine());
            sum1 = sum1 + currentNumber;
        }
        for (int i = 1; i <= numberCount; i++)
        {
            int currentNumber = int.Parse(Console.ReadLine());
            sum2 = sum2 + currentNumber;
        }
        if (sum1 == sum2)
        {
            Console.WriteLine("Yes, sum={0}",sum1);
        }
        else
        {
            int difference = Math.Abs(sum1 - sum2);
            Console.WriteLine("No, diff={0}", difference);
        }
    }
}

