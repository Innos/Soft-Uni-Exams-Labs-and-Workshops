using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _01Gandalf_sStash
{
    class GandalfsStash
    {
        static void Main(string[] args)
        {
            string pattern = @"[a-zA-Z]+";
            Regex reg = new Regex(pattern,RegexOptions.IgnoreCase);
            int mood = int.Parse(Console.ReadLine());
            string text = Console.ReadLine();
            MatchCollection matches = Regex.Matches(text, pattern);
            foreach (Match match in matches)
            {
                switch(match.Value.ToLower())
                {
                    case "cram": mood += 2; break;
                    case "lembas": mood += 3; break;
                    case "apple": mood += 1; break;
                    case "melon": mood += 1; break;
                    case "honeycake": mood += 5; break;
                    case "mushrooms": mood -= 10; break;
                    default: mood -= 1; break;
                }
            }
            Console.WriteLine(mood);
            if(mood < -5)
            {
                Console.WriteLine("Angry");
            }
            else if(mood >= -5 && mood < 0)
            {
                Console.WriteLine("Sad");
            }
            else if(mood >= 0 && mood <= 15)
            {
                Console.WriteLine("Happy");
            }
            else if(mood > 15)
            {
                Console.WriteLine("Special JavaScript mood");
            }
        }
    }
}
