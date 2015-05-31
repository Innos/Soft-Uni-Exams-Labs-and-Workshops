using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


class TextTransformer
{
    static void Main(string[] args)
    {
        string input;
        StringBuilder sb = new StringBuilder();
        while((input = Console.ReadLine()) != "burp")
        {
            sb.Append(input);
        }
        string text = sb.ToString();
        string pattern = @"(?:\$(?<result>[^$%&']+?)\$|%(?<result>[^$%&']+?)%|&(?<result>[^$%&']+?)&|'(?<result>[^$%&']+?)')";
        text = Regex.Replace(text, @"\n", "");
        text = Regex.Replace(text,@"\s+"," ");
        MatchCollection matches = Regex.Matches(text, pattern);
        StringBuilder result = new StringBuilder();
        foreach (Match match in matches)
        {
            char sign = match.Value.First();
            int offset = 0;
            char[] res = match.Groups["result"].Value.ToCharArray();
            switch(sign)
            {
                case '$': offset = 1; break;
                case '%': offset = 2; break;
                case '&': offset = 3; break;
                case '\'': offset = 4; break;
            }
            for (int i = 0; i < res.Length; i++)
            {
                if(i % 2 == 0)
                {
                    res[i] = (char)(res[i] + offset);
                }
                else
                {
                    res[i] = (char)(res[i] - offset);
                }
                result.Append(res[i]);
            }
            result.Append(' ');
        }
        Console.WriteLine(result.ToString());
    }
}

