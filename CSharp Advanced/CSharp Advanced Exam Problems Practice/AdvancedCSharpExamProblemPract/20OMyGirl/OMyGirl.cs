using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


class OMyGirl
{
    static void Main(string[] args)
    {
        string key = Console.ReadLine();
        string input;
        StringBuilder sb = new StringBuilder();
        while ((input = Console.ReadLine()) != "END")
        {
            sb.Append(input);
        }
        string text = sb.ToString();
        StringBuilder keyBuilder = new StringBuilder();
        for (int i = 0; i < key.Length; i++)
        {
            //first or last element
            if (i == 0 || i == key.Length - 1)
            {
                if(!Char.IsLetterOrDigit(key[i]))
                {
                    keyBuilder.Append(@"\").Append(key[i]);
                }
                else
                {
                    keyBuilder.Append(key[i]);
                }
            }
            else
            {
                if (!Char.IsLetterOrDigit(key[i]))
                {
                    keyBuilder.Append(@"\").Append(key[i]);
                }
                else if (Char.IsLetter(key[i]) && Char.IsLower(key[i]))
                {
                    keyBuilder.Append("[a-z]*");
                }
                else if (Char.IsLetter(key[i]) && Char.IsUpper(key[i]))
                {
                    keyBuilder.Append("[A-Z]*");
                }
                else if (Char.IsDigit(key[i]))
                {
                    keyBuilder.Append(@"\d*");
                }
            }  
        }
        string pattern = keyBuilder.ToString() + @"(.{2,6})" + keyBuilder.ToString();
        MatchCollection matches = Regex.Matches(text, pattern);
        StringBuilder adress = new StringBuilder();
        foreach (Match match in matches)
        {
            adress.Append(match.Groups[1].Value);
        }
        Console.WriteLine(adress.ToString());
    }
}

