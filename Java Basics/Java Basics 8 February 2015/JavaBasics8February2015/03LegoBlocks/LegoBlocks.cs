using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class LegoBlocks
{
    static void Main(string[] args)
    {
        bool fit = true;
        int numberOfBlocks = 2;
        List<List<int>> lego = new List<List<int>>();
        int rows = int.Parse(Console.ReadLine());
        for (int block = 0; block < numberOfBlocks; block++)
        {
            for (int row = 0; row < rows; row++)
            {
                if (block == 0)
                {
                    lego.Add(new List<int>(Console.ReadLine().Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)));
                }
                else
                {
                    lego[row].AddRange(Console.ReadLine().Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Reverse());
                }
            }
        }
        int Count = lego[0].Count;
        foreach (var row in lego)
        {
            if (row.Count != Count)
            {
                fit = false;
                break;
            }
        }
        if (fit)
        {
            lego.ForEach(row => Console.WriteLine("[{0}]", String.Join(", ", row)));
        }
        else
        {
            int cellCount = 0;
            lego.ForEach(x => cellCount += x.Count);
            Console.WriteLine("The total number of cells is: {0}",cellCount);
        }
    }
}

