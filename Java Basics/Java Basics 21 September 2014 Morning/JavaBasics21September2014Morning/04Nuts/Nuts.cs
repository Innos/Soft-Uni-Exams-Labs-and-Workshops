using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Nuts
{
    static void Main(string[] args)
    {
        SortedDictionary<string, Dictionary<string, int>> companies = new SortedDictionary<string, Dictionary<string, int>>();
        int lines = int.Parse(Console.ReadLine());
        for (int i = 0; i < lines; i++)
        {
            string[] tokens = Console.ReadLine().Split();
            string company = tokens[0];
            string nuts = tokens[1];
            int amount = int.Parse(tokens[2].Remove(tokens[2].Length - 2));
            if(!companies.ContainsKey(company))
            {
                companies.Add(company, new Dictionary<string, int>());
            }
            if(!companies[company].ContainsKey(nuts))
            {
                companies[company].Add(nuts, 0);
            }
            companies[company][nuts] = companies[company][nuts] + amount;
        }
        foreach (var company in companies)
        {
            var sub = company.Value.Select(x => x.Key + "-" + x.Value + "kg").Aggregate((x, y) => x + ", " + y);
            Console.WriteLine("{0}: {1}",company.Key, sub);
        }

    }
}

