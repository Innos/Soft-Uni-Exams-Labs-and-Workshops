using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class PlusRemove
{

    static void Main(string[] args)
    {
        List<char[]> lines = new List<char[]>();
        List<char[]> result = new List<char[]>();
        string text = Console.ReadLine();
        while (text != "END")
        {
            //compiling the lines into a list, 2 lists one to keep the case correct
            lines.Add(text.ToLower().ToCharArray());
            result.Add(text.ToCharArray());
            text = Console.ReadLine();
        }

        //Itterating through each cell and checking if it makes a plus
        for (int row = 0; row < lines.Count; row++)
        {
            for (int col = 0; col < lines[row].Length; col++)
            {
                FindPluses(lines, result, row, col);
            }
        }
        Print(result);
    }

    static void FindPluses(List<char[]> lines, List<char[]> result, int row, int col)
    {
        char symbol = lines[row][col];

        if (row - 1 >= 0 &&
            row + 1 < lines.Count &&
            col - 1 >= 0 &&
            col + 1 < lines[row].Length
            && lines[row - 1].Length > col
            && lines[row + 1].Length > col
            && lines[row - 1][col] == symbol
            && lines[row + 1][col] == symbol
            && lines[row][col - 1] == symbol
            && lines[row][col + 1] == symbol)
        {
            result[row][col] = '\0';
            result[row - 1][col] = '\0';
            result[row + 1][col] = '\0';
            result[row][col - 1] = '\0';
            result[row][col + 1] = '\0';
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

