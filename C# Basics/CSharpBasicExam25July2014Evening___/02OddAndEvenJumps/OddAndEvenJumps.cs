using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class OddAndEvenJumps
{
    static void Main(string[] args)
    {
        int oddCounter = 0;
        int evenCounter = 0;
        long oddSum = 0;
        long evenSum = 0;
        string input = Console.ReadLine().Replace(" ", "").ToLower();
        int oddjump = int.Parse(Console.ReadLine());
        int evenjump = int.Parse(Console.ReadLine());
        for (int i = 0; i < input.Length; i++)
        {
            if(i%2 ==0)
            {
                oddCounter++;
                if(oddCounter % oddjump == 0)
                {
                    oddSum = oddSum * input[i];
                }
                else
                {
                    oddSum = oddSum + input[i];
                }
            }
            else
            {
                evenCounter++;
                if(evenCounter % evenjump == 0)
                {
                    evenSum = evenSum * input[i];
                }
                else
                {
                    evenSum = evenSum + input[i];
                }
            }
        }
        Console.WriteLine("Odd: {0}",Convert.ToString(oddSum,16).ToUpper());
        Console.WriteLine("Even: {0}", Convert.ToString(evenSum,16).ToUpper());
    }
}

