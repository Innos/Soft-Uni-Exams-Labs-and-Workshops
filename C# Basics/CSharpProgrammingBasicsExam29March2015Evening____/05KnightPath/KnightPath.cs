using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class KnightPath
{
    static void Main(string[] args)
    {
        int row = 0;
        int col = 0;
        int[] board = new int[8];
        board[row] = 1;
        string input = Console.ReadLine();
        while (input != "stop")
        {
            int rowtemp = row;
            int coltemp = col;
            switch (input)
            {
                case "left up": col += 2; row -= 1; break;
                case "left down": col += 2; row += 1; break;
                case "right up": col -= 2; row -= 1; break;
                case "right down": col -= 2; row += 1; break;
                case "up left": row -= 2; col += 1; break;
                case "up right": row -= 2; col -= 1; break;
                case "down left": row += 2; col += 1; break;
                case "down right": row += 2; col -= 1; break;
            }
            if (row > 7 || row < 0 || col > 7 || col < 0)
            {
                row = rowtemp;
                col = coltemp;
            }
            else
            {
                board[row] = board[row] ^ (1 << col);
            }
            input = Console.ReadLine();
        }
        var empty = true;
        foreach (var num in board)
        {
            if (num != 0)
            {
                empty = false;
                Console.WriteLine(num);
            }
        }
        if (empty)
        {
            Console.WriteLine("[Board is empty]");
        }
    }
}

