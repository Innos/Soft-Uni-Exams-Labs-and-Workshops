using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class MelonsAndWatermelons
{
    static void Main(string[] args)
    {
        int melons = 0;
        int watermelons = 0;
        int start = int.Parse(Console.ReadLine());
        int duration = int.Parse(Console.ReadLine());
        for (int i = 1; i <= duration; i++)
        {
            switch(start)
            {
                case 1: watermelons += 1; break;
                case 2: melons += 2; break;
                case 3: watermelons += 1; melons += 1; break;
                case 4: watermelons += 2; break;
                case 5: watermelons += 2; melons += 2; break;
                case 6: watermelons += 1; melons += 2; break;
            }
            start++;
            if(start > 7)
            {
                start = 1;
            }
        }
        if(watermelons == melons)
        {
            Console.WriteLine("Equal amount: {0}",watermelons);
        }
        else if(watermelons > melons)
        {
            Console.WriteLine("{0} more watermelons",watermelons-melons);
        }
        else if (melons > watermelons)
        {
            Console.WriteLine("{0} more melons",melons- watermelons);
        }
    }
}

