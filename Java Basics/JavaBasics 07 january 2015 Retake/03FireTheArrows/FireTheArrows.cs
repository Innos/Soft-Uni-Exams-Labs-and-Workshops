using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class FireTheArrows
{
    static bool hasMoved = true;

    static void Main(string[] args)
    {
        List<char[]> matrix = new List<char[]>();
        int lines = int.Parse(Console.ReadLine());
        string input;
        for (int i = 0; i < lines; i++)
        {
            input = Console.ReadLine();
            matrix.Add(input.ToCharArray());
        }
        while (hasMoved)
        {
            hasMoved = false;
            for (int row = 0; row < lines; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == '<' ||
                        matrix[row][col] == '>' ||
                        matrix[row][col] == '^' ||
                        matrix[row][col] == 'v')
                    {
                        Move(matrix, row, col, matrix[row][col]);
                    }
                }
            }
        }
        Console.WriteLine();
        for (int row = 0; row < matrix.Count; row++)
        {
            for (int col = 0; col < matrix[row].Length; col++)
            {
                Console.Write(matrix[row][col]);
            }
            Console.WriteLine();
        }
    }
    static void Move(List<char[]> field, int row, int col, char arrow)
    {
        char cell;
        switch (arrow)
        {
            case '<':
                if (CanMove(field, row, col - 1))
                {
                    hasMoved = true;
                    cell = field[row][col];
                    field[row][col] = 'o';
                    field[row][col - 1] = cell;
                }
                break;
            case '>':
                if (CanMove(field, row, col + 1))
                {
                    hasMoved = true;
                    cell = field[row][col];
                    field[row][col] = 'o';
                    field[row][col + 1] = cell;
                }
                break;
            case '^':
                if (CanMove(field, row - 1, col))
                {
                    hasMoved = true;
                    cell = field[row][col];
                    field[row][col] = 'o';
                    field[row - 1][col] = cell;
                }
                break;
            case 'v':
                if (CanMove(field, row + 1, col))
                {
                    hasMoved = true;
                    cell = field[row][col];
                    field[row][col] = 'o';
                    field[row + 1][col] = cell;
                }
                break;
        }
    }
    static bool CanMove(List<char[]> field, int row, int col)
    {
        char[] forbiddenSymbols = { '<', '>', '^', 'v' };
        if (row >= 0 && row < field.Count &&
            col >= 0 && col < field[row].Length &&
            !forbiddenSymbols.Contains(field[row][col]))
        {
            return true;
        }
        return false;
    }
}

