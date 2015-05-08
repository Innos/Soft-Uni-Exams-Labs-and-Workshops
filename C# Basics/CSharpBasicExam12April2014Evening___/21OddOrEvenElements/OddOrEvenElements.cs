using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class OddOrEvenElements
{
    static void Main(string[] args)
    {
        int oddCounter = 0;
        int evenCounter = 0;
        string input = Console.ReadLine();
        if(input == "")
        {
            Console.WriteLine("OddSum={0}, OddMin={0}, OddMax={0}, EvenSum={0}, EvenMin={0}, EvenMax={0}", "No");
            return;
        }
        decimal[] numbers = Array.ConvertAll(input.Split(' '), decimal.Parse);
        if(numbers.Length == 1)
        {
            Console.WriteLine("OddSum={0:G10}, OddMin={1:G10}, OddMax={2:G10}, EvenSum={3}, EvenMin={3}, EvenMax={3}", numbers.Sum(), numbers.Min(), numbers.Max(), "No");
        }
        else
        {
            decimal[] odd = new decimal[(int)Math.Ceiling(numbers.Length/2d)];
            decimal[] even = new decimal[numbers.Length/2];
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i % 2 == 0)
                {
                    odd[oddCounter] = numbers[i];
                    oddCounter++;
                }
                else
                {
                    even[evenCounter] = numbers[i];
                    evenCounter++;
                }
            }
            Console.WriteLine("OddSum={0:G10}, OddMin={1:G10}, OddMax={2:G10}, EvenSum={3:G10}, EvenMin={4:G10}, EvenMax={5:G10}", odd.Sum(), odd.Min(), odd.Max(), even.Sum(), even.Min(), even.Max());
        }
    }
}

