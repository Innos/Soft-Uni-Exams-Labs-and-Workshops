using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class OddOrEvenCounter
{
    static void Main(string[] args)
    {
        int counter = 0;
        int pattern  = 0;
        List<int>setCount = new List<int>();
        int sets = int.Parse(Console.ReadLine());
        int numbersInSet = int.Parse(Console.ReadLine());
        string type = Console.ReadLine();
        switch (type)
        {
            case "odd": pattern = 1; break;
            case "even": pattern = 0; break;
        }
        for (int i = 0; i < sets; i++)
        {
            counter = 0;
            for (int l = 0; l < numbersInSet; l++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num % 2 == pattern)
                {
                    counter++;
                }
            }
            if (counter > 0) setCount.Add(counter);
        }
        if(setCount.Count == 0)
        {
            Console.WriteLine("No");
        }
        else
        {
            var result = setCount.Select((x, i) => new { Value = x, Set = i + 1 })
    .OrderByDescending(s => s.Value)
    .First();

            string answer = "";
            switch (result.Set)
            {
                case 1: answer = "First"; break;
                case 2: answer = "Second"; break;
                case 3: answer = "Third"; break;
                case 4: answer = "Fourth"; break;
                case 5: answer = "Fifth"; break;
                case 6: answer = "Sixth"; break;
                case 7: answer = "Seventh"; break;
                case 8: answer = "Eighth"; break;
                case 9: answer = "Ninth"; break;
                case 10: answer = "Tenth"; break;
            }
            Console.WriteLine("{0} set has the most {1} numbers: {2}",answer,type,result.Value);
        }       
    }
}

