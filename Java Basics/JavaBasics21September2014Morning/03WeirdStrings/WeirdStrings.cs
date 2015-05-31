using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


class WeirdStrings
{
    static void Main(string[] args)
    {
        int maxSum = int.MinValue;
        string first = "";
        string second = "";
        string text = Console.ReadLine();
        string removePattern = @"[\\\/)(\s|]*";
        string matchPattern = @"[a-zA-Z]+";
        text = Regex.Replace(text, removePattern,"");
        Regex matcher = new Regex(matchPattern);
        Match match = matcher.Match(text);
        while (match.NextMatch().Success)
        {
            int weight1 = GetWeight(match.Value);
            int weight2 = GetWeight(match.NextMatch().Value);
            if(weight1 + weight2 >= maxSum)
            {
                maxSum = weight1 + weight2;
                first = match.Value;
                second = match.NextMatch().Value;
            }
            match = match.NextMatch();
        }
        Console.WriteLine(first);
        Console.WriteLine(second);
    }

    static int GetWeight(string match)
    {
        match = match.ToLower();
        int sum = 0;
        for (int i = 0; i < match.Length; i++)
        {
            sum += ((match[i] - 'a') + 1);
        }
        return sum;
    }
}

