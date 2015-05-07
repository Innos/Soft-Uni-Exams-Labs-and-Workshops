using System;
using System.Linq;

class SumOfElements
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        long sum = 0;
        bool solution = false;
        string[] numbers = input.Split(' ');
        long[] numbersInInt = new long[numbers.Length];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbersInInt[i] = long.Parse(numbers[i]);
            sum += numbersInInt[i];
        }
        foreach (long element in numbersInInt)
        {
            if (sum == element * 2)
            {
                Console.WriteLine("Yes, sum={0}", element);
                solution = true;
                break;
            }
        }
        if (solution == false)
        {
            Console.WriteLine("No, diff={0}", Math.Abs(sum - 2*numbersInInt.Max()));
        }
    }                   
}

