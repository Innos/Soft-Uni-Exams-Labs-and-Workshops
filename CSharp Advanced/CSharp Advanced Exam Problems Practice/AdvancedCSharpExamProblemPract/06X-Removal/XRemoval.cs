using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class XRemoval
{
    static void Main(string[] args)
    {
        List<char[]> matrix = new List<char[]>();
        List<char[]> result = new List<char[]>();
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            matrix.Add(input.ToLower().ToCharArray());
            result.Add(input.ToCharArray());
        }
        for (int row = 0; row < matrix.Count; row++)
        {
            for (int col = 0; col < matrix[row].Length; col++)
            {
                DeleteX(matrix, result, row, col);
            }
        }
        Print(result);
    }

    static void DeleteX(List<char[]> matrix, List<char[]> result, int row, int col)
    {
        char element = matrix[row][col];
        if (row - 1 >= 0 &&
            col - 1 >= 0 &&
            row + 1 < matrix.Count &&
            col + 1 < matrix[row - 1].Length &&
            col + 1 < matrix[row + 1].Length &&
            matrix[row - 1].Length > col + 1 &&
            matrix[row + 1].Length > col + 1 &&
            matrix[row - 1][col - 1] == element &&
            matrix[row - 1][col + 1] == element &&
            matrix[row + 1][col - 1] == element &&
            matrix[row + 1][col + 1] == element)
        {
            result[row][col] = '\0';
            result[row - 1][col - 1] = '\0';
            result[row - 1][col + 1] = '\0';
            result[row + 1][col - 1] = '\0';
            result[row + 1][col + 1] = '\0';
        }
    }

    static void Print(List<char[]> result)
    {
        foreach (var line in result)
        {
            foreach (var symbol in line)
            {
                if (symbol != '\0')
                {
                    Console.Write(symbol);
                }
            }
            Console.WriteLine();
        }
    }
}

