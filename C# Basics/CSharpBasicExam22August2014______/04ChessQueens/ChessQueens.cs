using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ChessQueens
{
    static void Main(string[] args)
    {
        int solutions = 0;
        int size = int.Parse(Console.ReadLine());
        int distance = int.Parse(Console.ReadLine());
        for (int x1 = 'a'; x1 <'a' + size; x1++)
        {
            for (int y1 = 1; y1 <= size; y1++)
            {
                for (int x2 = 'a'; x2 <'a' + size; x2++)
                {
                    for (int y2 = 1; y2 <= size; y2++)
                    {
                        int dx = Math.Abs(x1 - x2);
                        int dy = Math.Abs(y1 - y2);
                        if((dx == distance+1 && y1==y2)
                            ||(dy== distance+1 && x1 == x2) 
                            ||(dx== distance+1 && dy == distance+1))
                        {
                            Console.WriteLine("{0}{1} - {2}{3}",(char)x1,y1,(char)x2,y2);
                            solutions++;
                        }
                    }
                }
            }
        }
        if (solutions == 0)
        {
            Console.WriteLine("No valid positions");
        }
    }
}

