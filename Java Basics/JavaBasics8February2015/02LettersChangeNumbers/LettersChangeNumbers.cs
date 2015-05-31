using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


class LettersChangeNumbers
{
    static void Main(string[] args)
    {
        decimal sum = 0;
        string input = Console.ReadLine();
        input = Regex.Replace(input, @"\s"," ");
        string[] strings = input.Split(new char[]{' '},StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < strings.Length; i++)
        {
            char firstLetter = strings[i].First();
            char lastLetter = strings[i].Last();
            decimal number = decimal.Parse(strings[i].Substring(1,strings[i].Length-2));
            if(Char.IsUpper(firstLetter))
            {
                number = number / ((firstLetter - 'A') + 1);
            }
            else
            {
                number = number * ((firstLetter - 'a') + 1);
            }
            if(Char.IsUpper(lastLetter))
            {
                number = number - ((lastLetter - 'A') + 1);
            }
            else
            {
                number = number + ((lastLetter - 'a') + 1);
            }
            sum += number;
        }
        Console.WriteLine("{0:F2}",sum);
    }
}

