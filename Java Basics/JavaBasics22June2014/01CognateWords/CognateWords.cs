using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


class CognateWords
{
    static void Main(string[] args)
    {
        bool hasSolution = false;
        string pattern = @"[^a-zA-Z]+";
        string text = Console.ReadLine();
        text = Regex.Replace(text, pattern, " ").Trim();
        List<string> words = text.Split().ToList();
        StringBuilder sb = new StringBuilder();
        HashSet<string> result = new HashSet<string>();
        for (int word = 0; word < words.Count; word++)
        {
            for (int w1 = 0; w1 < words.Count; w1++)
            {
                for (int w2 = 0; w2 < words.Count; w2++)
                {
                    sb.Clear();
                    sb.Append(words[w1]).Append(words[w2]);
                    if(w1 != w2 && sb.ToString() == words[word])
                    {
                        result.Add(String.Format("{0}|{1}={2}", words[w1], words[w2], words[word]));
                        hasSolution = true;
                    }
                }
            }
        }
        if(!hasSolution)
        {
            Console.WriteLine("No");
        }
        else
        {
            foreach (var line in result)
            {
                Console.WriteLine(line);
            }
        }
    }
}

