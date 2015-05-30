using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;


class ClearingCommands
{
    static void Main(string[] args)
    {
        List<char[]> matrix = new List<char[]>();
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            matrix.Add(input.ToCharArray());
        }
        for (int row = 0; row < matrix.Count; row++)
        {
            for (int col = 0; col < matrix[row].Length; col++)
            {
                int rChange = 0;
                int cChange = 0;
                if (matrix[row][col] == '<' ||
                    matrix[row][col] == '>' ||
                    matrix[row][col] == '^' ||
                    matrix[row][col] == 'v')
                {
                    switch (matrix[row][col])
                    {
                        case '>': rChange = 0; cChange = 1; break;
                        case '<': rChange = 0; cChange = -1; break;
                        case '^': rChange = -1; cChange = 0; break;
                        case 'v': rChange = 1; cChange = 0; break;
                    }
                    Clean(matrix, row, col, rChange, cChange);
                }
            }
        }
        foreach (var item in matrix)
        {
            string line = String.Join("", item);
            line = SecurityElement.Escape(line);
            Console.WriteLine("<p>{0}</p>", line);
        }
    }
    static void Clean(List<char[]> matrix, int row, int col, int rChange, int cChange)
    {
        while (row + rChange < matrix.Count && row + rChange >= 0 &&
            col + cChange < matrix[row].Length && col + cChange >= 0 &&
            matrix[row + rChange][col + cChange] != 'v' &&
            matrix[row + rChange][col + cChange] != '^' &&
            matrix[row + rChange][col + cChange] != '<' &&
            matrix[row + rChange][col + cChange] != '>')
        {
            row = row + rChange;
            col = col + cChange;
            matrix[row][col] = ' ';
        }
    }
}

