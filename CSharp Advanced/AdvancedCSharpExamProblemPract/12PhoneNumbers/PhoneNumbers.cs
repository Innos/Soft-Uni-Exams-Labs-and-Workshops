using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


class PhoneNumbers
{
    static void Main(string[] args)
    {
        string pattern = @"([A-Z][a-zA-Z]*)[^a-zA-Z\+]*?(\+?\d[0-9)(,.\-\/ ]*\d)";
        string input;
        string text = "";
        List<string> result = new List<string>();
        while((input = Console.ReadLine()) != "END")
        {
            text = text + input;
        }
        MatchCollection matches = Regex.Matches(text, pattern);
        foreach (Match match in matches)
        {
            string name = match.Groups[1].Value;
            string number = match.Groups[2].Value;
            number = Regex.Replace(number, @"[^\d+]", "");
            result.Add(String.Format("<li><b>{0}:</b> {1}</li>", name, number));
        }
        if(result.Count == 0)
        {
            Console.WriteLine("<p>No matches!</p>");
        }
        else
        {
            Console.WriteLine("<ol>{0}</ol>",String.Join("",result));
        }
        
    }
}

