using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;


class SumOfAllValues
{
    static void Main(string[] args)
    {
        Console.SetIn(new StreamReader(Console.OpenStandardInput(8192)));

        string keyString = Console.ReadLine();
        string text = Console.ReadLine();

        string startKeyPattern = @"^[^\W0-9]+(?=\d)";
        string endKeyPattern = @"(?<=\d)[^\W0-9]+$";

        string startKey = Regex.Match(keyString, startKeyPattern).Value;
        string endKey = Regex.Match(keyString, endKeyPattern).Value;

         if(startKey == String.Empty || endKey == String.Empty )
        {
            Console.WriteLine("<p>A key is missing</p>");
            return;
        }

        string matcher = startKey + @"(\d*?\.*?\d+?)" + endKey;
        MatchCollection matches = Regex.Matches(text, matcher);

        double sum = 0;
        foreach (Match match in matches)
        {
            sum += double.Parse(match.Groups[1].Value);
        }
        if(sum == 0)
        {
            Console.WriteLine("<p>The total value is: <em>nothing</em></p>");
            
        }
        else
        {
            Console.WriteLine("<p>The total value is: <em>{0}</em></p>", sum);
        }
    }
}

