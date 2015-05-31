using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


class ValidUsername
{
    static void Main(string[] args)
    {
        int max = 0;
        string first = "";
        string secind = "";
        int sum = 0;
        string input = Console.ReadLine();
        string pattern = @"\b[a-zA-Z][\w]{2,24}\b";
        Match m = Regex.Match(input, pattern);
        while(m.NextMatch().Success)
        {
            sum = 0;
            sum = m.Value.Length + m.NextMatch().Value.Length;
            if(sum > max)
            {
                max = sum;
                first = m.Value;
                secind = m.NextMatch().Value;
            }
            m = m.NextMatch();
        }
        Console.WriteLine(first);
        Console.WriteLine(secind);
    }
}

