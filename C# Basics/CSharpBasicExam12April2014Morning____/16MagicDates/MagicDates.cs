using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class MagicDates
{
    static void Main(string[] args)
    {
        int solutions = 0;
        int startYear = int.Parse(Console.ReadLine());
        int endYear = int.Parse(Console.ReadLine());
        int magicWeight = int.Parse(Console.ReadLine());
        DateTime start = new DateTime(startYear, 1, 1);
        DateTime end = new DateTime(endYear, 12, 31);
        while(DateTime.Compare(start,end)<= 0)
        {
            int weight = 0;
            string datenumber = start.ToString("ddMMyyyy");
            int[] number = datenumber.Select(digit => int.Parse(digit.ToString())).ToArray();
            for (int i = 0; i < number.Length; i++)
            {
                for (int l = i+1; l < number.Length; l++)
                {
                    weight = weight + (number[i] * number[l]);
                }
            }
            if(weight == magicWeight)
            {
                Console.WriteLine(start.ToString("dd-MM-yyyy"));
                solutions++;
            }
            start = start.AddDays(1);
        }
        if(solutions == 0)
        {
            Console.WriteLine("No");
        }
    }
}

