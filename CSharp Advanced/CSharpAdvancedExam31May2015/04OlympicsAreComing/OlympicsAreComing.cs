using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


class OlympicsAreComing
{
    static void Main(string[] args)
    {
        Dictionary<string,Dictionary<string,int>> statistics = new Dictionary<string,Dictionary<string,int>>();
        string input;
        while((input = Console.ReadLine()) != "report")
        {
            input = Regex.Replace(input, @"\s+", " ");
            string[] tokens = input.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            string name = tokens[0].Trim();
            string country = tokens[1].Trim();
            if(!statistics.ContainsKey(country))
            {
                statistics.Add(country, new Dictionary<string, int>());
            }
            if(!statistics[country].ContainsKey(name))
            {
                statistics[country].Add(name, 0);
            }
            statistics[country][name] = statistics[country][name] + 1;    
        }
        statistics = statistics.OrderByDescending(x => x.Value.Values.Sum()).ToDictionary(x=>x.Key,y => y.Value);
        foreach (var country in statistics)
        {
            Console.WriteLine("{0} ({1} participants): {2} wins",country.Key,country.Value.Keys.Count,country.Value.Values.Sum());
        }
    }
}

