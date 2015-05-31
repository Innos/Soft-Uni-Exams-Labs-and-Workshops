using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


class OfficeStuff
{
    static void Main(string[] args)
    {
        int lines = int.Parse(Console.ReadLine());
        SortedDictionary<string, Dictionary<string, int>> orders = new SortedDictionary<string, Dictionary<string, int>>();
        for (int i = 0; i < lines; i++)
        {
            string input = Console.ReadLine();
            string[] tokens = input.Split(new char[] { ' ','|','-' }, StringSplitOptions.RemoveEmptyEntries);
            string company = tokens[0];
            int amount = int.Parse(tokens[1]);
            string product = tokens[2];
            if(!orders.ContainsKey(company))
            {
                orders.Add(company, new Dictionary<string, int>());
            }
            if(!orders[company].ContainsKey(product))
            {
                orders[company].Add(product, 0);
            }
            orders[company][product] = orders[company][product] + amount;
        }
        StringBuilder sb = new StringBuilder();
        foreach (var order in orders)
        {
            var sub = order.Value.Select(product=> product.Key + "-" + product.Value.ToString()).Aggregate((x, y) => x + ", " + y);
            sb.AppendLine(String.Format("{0}: {1}", order.Key, sub));
        }
        Console.Write(sb.ToString());
    }
}

