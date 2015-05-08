using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class GameOfLife
{
    static int fieldSize = 10;
    static int topBorder = fieldSize - 1;
    static int botBorder = 0;

    static void Main(string[] args)
    {
        int[,] finishedField = new int[fieldSize, fieldSize];
        int[,] numbers = new int[fieldSize,fieldSize];
        int pairs = int.Parse(Console.ReadLine());
        //Seeding the numbers array while parsing the input data
        for (int i = 0; i < pairs; i++)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = topBorder - int.Parse(Console.ReadLine());
            numbers[rows,cols] = 1;
        }
        for (int rows = 0; rows < fieldSize; rows++)
        {
            for (int cols = topBorder; cols >= 0; cols--)
            {
                int liveCells = 0;
                liveCells += GetCellValue(numbers, rows, cols, -1, 0);
                liveCells += GetCellValue(numbers, rows, cols, 1, 0);
                liveCells += GetCellValue(numbers, rows, cols, 0, -1);
                liveCells += GetCellValue(numbers, rows, cols, 0, 1);
                liveCells += GetCellValue(numbers, rows, cols, -1, -1);
                liveCells += GetCellValue(numbers, rows, cols, -1, 1);
                liveCells += GetCellValue(numbers, rows, cols, 1, -1);
                liveCells += GetCellValue(numbers, rows, cols, 1, 1);
                //Seeding the new matrix
                if (liveCells == 3 || liveCells == 2 && numbers[rows,cols] == 1)
                {
                    finishedField[rows, cols] = 1;
                }
                else if(liveCells == 3 && numbers[rows,cols] == 0)
                {
                    finishedField[rows, cols] = 1;
                }
            }
        }
        int columns = 0;
        foreach (var cell in finishedField)
        {
            columns++;
            Console.Write("{0}",cell);
            if (columns == 10)
            {
                Console.WriteLine(); 
                columns = 0;
            }
        }
    }

    static int GetCellValue(int[,] matrix ,int rows, int cols, int rowChange, int colChange)
    {
        int value = 0;
        rows += rowChange;
        cols += colChange;
        if(rows >= botBorder && rows <= topBorder && cols >= botBorder && cols <= topBorder && matrix[rows,cols] == 1)
        {
            value = 1;
        }
        return value;
    }
}

