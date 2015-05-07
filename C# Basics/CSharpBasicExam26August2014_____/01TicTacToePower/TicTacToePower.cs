using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class TicTacToePower
{
    static void Main(string[] args)
    {
        int x = int.Parse(Console.ReadLine());
        int y = int.Parse(Console.ReadLine());
        int value = int.Parse(Console.ReadLine());
        int[,] index = new int[3,3];
        int[,] val = new int[3,3];
        for (int i = 0; i < 3; i++)
        {
            for (int l = 0; l < 3; l++)
            {
                index[i, l] = (i*3 + l) + 1;
                val[i, l] = value + (i*3 + l);
            }
        }
        long result = (long)Math.Pow(val[y, x], index[y, x]);
        Console.WriteLine(result);
    }
}

