using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


class TheNumbers
{
    static void Main(string[] args)
    {
        List<string> result = new List<string>();
        string message = Console.ReadLine();
        string pattern = @"\d+";
        MatchCollection matches = Regex.Matches(message, pattern);
        foreach (Match match in matches)
        {
            result.Add(String.Format("0x{0:X4}",long.Parse(match.Value)));
        }
        Console.WriteLine("{0}",String.Join("-",result));
    }
}

