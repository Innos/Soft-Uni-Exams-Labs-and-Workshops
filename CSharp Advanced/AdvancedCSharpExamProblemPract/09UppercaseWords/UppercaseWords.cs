using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Security;


class UppercaseWords
{
    static void Main(string[] args)
    {
        string input;
        List<string> text = new List<string>();
        string pattern = @"(?<![a-zA-Z])[A-Z]+(?![a-zA-Z])";
        MatchEvaluator evaluator = new MatchEvaluator(Replacer);
        while((input = Console.ReadLine()) != "END")
        {
            input = Regex.Replace(input, pattern, evaluator);
            text.Add(input);
        }
        foreach (var row in text)
        {
            Console.WriteLine(SecurityElement.Escape(row));
        }
    }
    static string Replacer(Match match)
    {
        string word = "";
        if(IsPalindrome(match.Value))
        {
            word = DoubleUp(match.Value);
        }
        else
        {
            word = String.Concat(match.Value.Reverse());
        }
        return word;
    }

    static bool IsPalindrome(string text)
    {
        string reverse = String.Concat(text.Reverse());
        if (reverse == text)
        {
            return true;
        }
        return false;
    }
    static string DoubleUp(string text)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < text.Length; i++)
        {
            sb.Append(text[i]);
            sb.Append(text[i]);
        }
        return sb.ToString();
    }
}

