using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


class SemanticHTML
{
    static void Main(string[] args)
    {
        List<string> html = new List<string>();
        string input;
        string divPattern = @"(?:(id\s*=\s*|class\s*=\s*))(?:""(?<result>[^\s]+)"")";
        string xDivPattern = @"(?:<!--\s*)(?<result>[^\s]+)(?:\s*-->)";
        while ((input = Console.ReadLine()) != "END")
        {
            if (input.Contains("/div"))
            {
                string HTMLClass = Regex.Match(input, xDivPattern).Groups["result"].Value;
                input = Regex.Replace(input, xDivPattern, "");
                input = Regex.Replace(input, "div", HTMLClass);
                input = Regex.Replace(input, @">\s*", ">");
            }
            else if (input.Contains("div"))
            {
                string HTMLClass = Regex.Match(input, divPattern).Groups["result"].Value;
                input = Regex.Replace(input, divPattern, "");
                input = Regex.Replace(input, "div", HTMLClass);
                input = Regex.Replace(input, @"(?<=<.*)\s+", " ");
                input = Regex.Replace(input, @"\s>", ">");
            }
            html.Add(input);
        }
        foreach (var line in html)
        {
            Console.WriteLine(line);
        }
    }
}

