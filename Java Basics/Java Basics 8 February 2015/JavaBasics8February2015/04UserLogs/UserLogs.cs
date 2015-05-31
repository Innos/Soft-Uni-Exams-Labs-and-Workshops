using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


class UserLogs
{
    static void Main(string[] args)
    {
        string IPPattern = @"(?<=IP=).*?(?=\s)";
        string usernamePattern = @"(?<=user=)(.*?)$";
        SortedDictionary<string, Dictionary<string, int>> users = new SortedDictionary<string, Dictionary<string, int>>();
        string input = Console.ReadLine();
        while(input != "end")
        {
            string username = Regex.Match(input, usernamePattern).Value;
            string IP = Regex.Match(input, IPPattern).Value;
            if(!users.ContainsKey(username))
            {
                users.Add(username, new Dictionary<string, int>());
            }
            if(!users[username].ContainsKey(IP))
            {
                users[username].Add(IP, 0);
            }
            users[username][IP] = users[username][IP] + 1;
            input = Console.ReadLine();
        }
        foreach (var user in users)
        {
            var sub = user.Value.Select(IP => IP.Key + " => " + IP.Value).Aggregate((x, y) => x + ", " + y);
            Console.WriteLine("{0}:",user.Key);
            Console.WriteLine("{0}.",sub);
        }
    }
}

