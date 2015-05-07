using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


class LargestProductOfDigits
{
    static void Main(string[] args)
    {
        int max = 0;
        char[] input = Console.ReadLine().ToCharArray();
        int[] digits = Array.ConvertAll(input, c => (int)Char.GetNumericValue(c));
        for (int i = 0; i < digits.Length-5; i++)
        {
            int currentProduct = digits[i] * digits[i + 1] * digits[i + 2] * digits[i + 3] * digits[i + 4] * digits[i + 5];
            if (currentProduct > max)
            {
                max = currentProduct;
            }
        }
        Console.WriteLine(max);
    }
}

