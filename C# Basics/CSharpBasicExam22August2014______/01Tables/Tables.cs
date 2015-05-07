using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Tables
{
    static void Main(string[] args)
    {
        long oneLegPackets = long.Parse(Console.ReadLine());
        long twoLegPackets = long.Parse(Console.ReadLine());
        long threeLegPackets = long.Parse(Console.ReadLine());
        long fourLegPackets = long.Parse(Console.ReadLine());
        long tabletops = long.Parse(Console.ReadLine());
        long tablesNeeded = long.Parse(Console.ReadLine());
        long totalLegs = oneLegPackets * 1 + twoLegPackets * 2 + threeLegPackets * 3 + fourLegPackets * 4;
        long maxTables = Math.Min(tabletops, totalLegs / 4);
        if(maxTables == tablesNeeded)
        {
            Console.WriteLine("Just enough tables made: {0}",maxTables);
        }
        else if(maxTables< tablesNeeded)
        {
            Console.WriteLine("less: {0}",maxTables-tablesNeeded);
            if (tablesNeeded - tabletops < 0) tabletops = tablesNeeded;
            if (tablesNeeded * 4 - totalLegs < 0) totalLegs = tablesNeeded * 4;
            Console.WriteLine("tops needed: {0}, legs needed: {1}",tablesNeeded-tabletops,tablesNeeded*4-totalLegs);
        }
        else if(maxTables > tablesNeeded)
        {
            Console.WriteLine("more: {0}",maxTables-tablesNeeded);
            Console.WriteLine("tops left: {0}, legs left: {1}",tabletops-tablesNeeded,totalLegs-tablesNeeded*4);
        }
    }
}

