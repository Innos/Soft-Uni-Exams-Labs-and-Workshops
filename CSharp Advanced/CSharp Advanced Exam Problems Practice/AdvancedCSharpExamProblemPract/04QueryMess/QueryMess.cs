using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


class QueryMess
{
    static void Main(string[] args)
    {
        Dictionary<string, List<string>> pairs = new Dictionary<string, List<string>>();
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            input = Regex.Replace(input, @"(%20|\+)", " ");
            input = Regex.Replace(input, @"\s+", " ");
            string pattern = @"([^=&?]+)=([^&]+)";
            Match m = Regex.Match(input, pattern);
            while (m.Success)
            {
                string key = m.Groups[1].Value.Trim();
                string value = m.Groups[2].Value.Trim();
                if (!pairs.ContainsKey(key))
                {
                    pairs.Add(key, new List<string>());
                }
                pairs[key].Add(value);
                m = m.NextMatch();
            }
            foreach (var entry in pairs)
            {
                Console.Write("{0}=[{1}]", entry.Key, String.Join(", ", entry.Value));
            }
            pairs.Clear();
            Console.WriteLine();
        }
    }
}

