using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tables
{
    class Tables
    {
        static void Main(string[] args)
        {
            long bundle1 = long.Parse(Console.ReadLine());
            long bundle2 = 2 * long.Parse(Console.ReadLine());
            long bundle3 = 3 * long.Parse(Console.ReadLine());
            long bundle4 = 4 * long.Parse(Console.ReadLine());
            long tableTops = long.Parse(Console.ReadLine());
            long tablesToBeMade = long.Parse(Console.ReadLine());

            long totalLegs = bundle1 + bundle2 + bundle3 + bundle4;
            long tablesMade = Math.Min(tableTops, totalLegs / 4);

            if (tablesMade > tablesToBeMade)
            {
                long legsLeft = totalLegs - tablesToBeMade * 4;
                long topsLeft = tableTops - tablesToBeMade;

                Console.WriteLine("more: {0}", tablesMade - tablesToBeMade);
                Console.WriteLine("tops left: {0}, legs left: {1}", topsLeft, legsLeft);
            }
            else if (tablesMade < tablesToBeMade)
            {
                long topsNeeded;
                long legsNeeded;
                if (tablesToBeMade >= tableTops)
                {
                    topsNeeded = tablesToBeMade - tableTops;
                }
                else
                {
                    topsNeeded = 0;
                }
                if (tablesToBeMade * 4 >= totalLegs)
                {
                    legsNeeded = tablesToBeMade * 4 - totalLegs;
                }
                else
                {
                    legsNeeded = 0;
                }
                Console.WriteLine("less: {0}", tablesMade - tablesToBeMade);
                Console.WriteLine("tops needed: {0}, legs needed: {1}", topsNeeded, legsNeeded);
            }
            else
            {
                Console.WriteLine("Just enough tables made: {0}", tablesMade);
            }

        }
    }
}
