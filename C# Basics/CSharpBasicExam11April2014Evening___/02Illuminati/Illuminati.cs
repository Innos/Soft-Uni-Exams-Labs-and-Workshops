using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Illuminati
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        Console.WriteLine(CalculateVowelsAndWeight(input)[0]);
        Console.WriteLine(CalculateVowelsAndWeight(input)[1]);
    }
    private static int[] CalculateVowelsAndWeight(string input)
    {
        int[] vowels = new int[2];
        foreach (char symbol in input)
        {
            switch(symbol)
            {
                case 'a':
                case 'A': vowels[0]++; vowels[1] += 65; break;
                case 'e':
                case 'E': vowels[0]++; vowels[1] += 69; break;
                case 'i':
                case 'I': vowels[0]++; vowels[1] += 73; break;
                case 'o':
                case 'O': vowels[0]++; vowels[1] += 79; break;
                case 'u':
                case 'U': vowels[0]++; vowels[1] += 85; break;
            }
        }
        return vowels;
    }
}

