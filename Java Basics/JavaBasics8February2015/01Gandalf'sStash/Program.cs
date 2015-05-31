using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _01Gandalf_sStash
{
    class Program
    {
        static void Main(string[] args)
        {
            int mood = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            string keywords = @"[^\w-[_]](cram|lembas|apple|melon|honeycake|mushrooms)[^\w-[_]]";
            Regex r = new Regex(keywords, RegexOptions.IgnoreCase);
            Match m = r.Match(input);
            while(m.Success)
            {
                int mood = 
                    switch(m.Value)
                    {
                        case"cram" : mood += 2; break;
                            case"lembas" : mood += 2; break;
                            case"apple" : mood += 2; break;
                            case"melon" : mood += 2; break;
                            case"honeycake" : mood += 2; break;
                            case"mushrooms" : mood -= 10; break;
                    }
            }
        }
    }
}
