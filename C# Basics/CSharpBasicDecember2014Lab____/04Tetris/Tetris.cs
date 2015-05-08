using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Tetris
{
    static void Main(string[] args)
    {
        int I = 0;
        int L = 0;
        int J = 0;
        int O = 0;
        int Z = 0;
        int S = 0;
        int T = 0;
        string input = Console.ReadLine();
        int rows = int.Parse(input.Split(' ')[0]);
        int cols = int.Parse(input.Split(' ')[1]);
        char[,] field = new char[rows, cols];
        for (int row = 0; row < rows; row++)
        {
            string line = Console.ReadLine();
            for (int col = 0; col < cols; col++)
            {
                field[row, col] = line[col];
            }
        }
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if ((row + 3 < rows) && (field[row, col] == 'o' && field[row + 1, col] == 'o' 
                    && field[row + 2, col] == 'o' && field[row + 3, col] == 'o'))
                {
                    I++;
                }
                if ((col + 1 < cols && row + 2 < rows) && (field[row, col] == 'o' && field[row + 1, col] == 'o' 
                    && field[row + 2, col] == 'o' && field[row + 2, col + 1] == 'o'))
                {
                    L++;
                }
                if ((col != 0 && row + 2 < rows) && (field[row, col] == 'o' && field[row + 1, col] == 'o' 
                    && field[row + 2, col] == 'o' && field[row + 2, col - 1] == 'o'))
                {
                    J++;
                }
                if ((col + 1 < cols && row + 1 < rows) && (field[row, col] == 'o' && field[row, col + 1] == 'o' 
                    && field[row + 1, col] == 'o' && field[row + 1, col + 1] == 'o'))
                {
                    O++;
                }
                if ((col + 2 < cols && row + 1 < rows) && (field[row, col] == 'o' && field[row, col + 1] == 'o' 
                    && field[row + 1, col + 1] == 'o' && field[row + 1, col + 2] == 'o'))
                {
                    Z++;
                }
                if ((col + 1 < cols && col - 1 >= 0 && row + 1 < rows) && (field[row, col] == 'o' && field[row, col + 1] == 'o' 
                    && field[row + 1, col] == 'o' && field[row + 1, col - 1] == 'o'))
                {
                    S++;
                }
                if ((col + 2 < cols && row + 1 < rows) && (field[row, col] == 'o' && field[row, col + 1] == 'o' 
                    && field[row, col + 2] == 'o' && field[row + 1, col + 1] == 'o'))
                {
                    T++;
                }
            }
        }
        Console.Write("I:{0}, L:{1}, J:{2}, O:{3}, Z:{4}, S:{5}, T:{6}",I,L,J,O,Z,S,T);
    }
}

