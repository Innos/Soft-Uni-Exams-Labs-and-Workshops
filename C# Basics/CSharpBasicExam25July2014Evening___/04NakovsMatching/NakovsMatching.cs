using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class NakovsMatching
{
    static void Main(string[] args)
    {
        int solutions = 0;
        string a = Console.ReadLine().Replace(" ","");
        string b = Console.ReadLine().Replace(" ","");
        int limit = int.Parse(Console.ReadLine());
        for (int i = 1; i < a.Length; i++)
        {
            for (int l = 1; l < b.Length; l++)
            {
                string aLeft = a.Substring(0, i);
                string aRight = a.Substring(i);
                string bLeft = b.Substring(0, l);
                string bRight = b.Substring(l);
                int nakovs = Math.Abs(CalculateWeight(aLeft) * CalculateWeight(bRight) - CalculateWeight(aRight) * CalculateWeight(bLeft));
                if(nakovs <= limit)
                {
                    Console.WriteLine("({0}|{1}) matches ({2}|{3}) by {4} nakovs",aLeft,aRight,bLeft,bRight,nakovs);
                    solutions++;
                }
            }
        }
        if(solutions ==0)
        {
            Console.WriteLine("No");
        }
    }
    private static int CalculateWeight(string word)
    {
        int weight = 0;
        foreach (var letter in word)
        {
            weight = weight + letter;
        }
        return weight;
    }
}

