using System;

class OddOrEvenSum
{
    static void Main(string[] args)
    {
        int sumOdd = 0;
        int sumEven = 0;
        int sequenceLength = int.Parse(Console.ReadLine());
        for (int i = 1; i <= sequenceLength*2; i++)
        {
            if ( i % 2 == 1)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                sumOdd += currentNumber;
            }
            else if(i % 2 == 0)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                sumEven += currentNumber;
            }
        }
        if (sumOdd == sumEven)
        {
            Console.WriteLine("Yes, sum={0}", sumOdd);
        }
        else
        {
            Console.WriteLine("No, diff={0}", Math.Abs(sumOdd - sumEven));
        }
    }
}

