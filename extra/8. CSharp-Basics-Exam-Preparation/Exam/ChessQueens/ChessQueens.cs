using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessQueens
{
    class ChessQueens
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());

            char[] letters = new char[n];
            for (int i = 0; i < letters.Length; i++)
            {
                letters[i] = (char)('a' + i);
            }
            bool isExist = false;

            for (int x1 = 0; x1 < n; x1++)
            {
                for (int y1 = 0; y1 < n; y1++)
                {
                    for (int x2 = 0; x2 < n; x2++)
                    {
                        for (int y2 = 0; y2 < n; y2++)
                        {

                            bool meetX = (x1 == (x2 + (d + 1)) && (y1 == y2)) || (x1 == (x2 - (d + 1)) && (y1 == y2));
                            bool meetY = (y1 == (y2 + (d + 1)) && (x1 == x2)) || (y1 == (y2 - (d + 1)) && (x1 == x2));

                            //bool meetY = y1 == (Math.Abs(y2 - (d+1))) && (x1==x2);
                            bool meetDiagonal1 = (x1 == x2 - (d + 1)) && (y1 == (y2 - (d + 1)));
                            bool meetDiagonal2 = (x1 == x2 + (d + 1)) && (y1 == (y2 - (d + 1)));
                            bool meetDiagonal3 = (x1 == x2 - (d + 1)) && (y1 == (y2 + (d + 1)));
                            bool meetDiagonal4 = (x1 == x2 + (d + 1)) && (y1 == (y2 + (d + 1)));

                            bool meetDiagonal = meetDiagonal1 || meetDiagonal2 || meetDiagonal3 || meetDiagonal4;

                            if (meetX || meetY || meetDiagonal)
                            {
                                Console.WriteLine("{0}{1} - {2}{3}", letters[x1], y1+1, letters[x2], y2+1);
                                isExist = true;
                            }
                        }
                    }
                }
            }

            if (!isExist)
            {
                Console.WriteLine("No valid positions");
            }
        }
    }
}
