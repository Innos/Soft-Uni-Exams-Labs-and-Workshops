using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        int valueLetters = 0;
        int valueNumbers = 0;
        int valueSymbols = 0;
        int lines = int.Parse(Console.ReadLine());
        for (int i = 0; i < lines; i++)
        {
            char[] input = Console.ReadLine().ToCharArray();
            foreach(var symbol in input)
            {
                if ((symbol >= 'A' && symbol <= 'Z') || (symbol >= 'a' && symbol <= 'z'))
                {
                    valueLetters = valueLetters + (Char.ToLower(symbol) - 'a' + 1) * 10;
                }
                else if (symbol >= '0' && symbol <= '9')
                {
                    valueNumbers = valueNumbers + (int.Parse(symbol.ToString())) * 20;
                }
                else if (Char.IsWhiteSpace(symbol))
                {
                }
                else
                {
                    valueSymbols = valueSymbols + 200;
                }
                   
            }
        }
        Console.WriteLine(valueLetters);
        Console.WriteLine(valueNumbers);
        Console.WriteLine(valueSymbols);
    }
}

