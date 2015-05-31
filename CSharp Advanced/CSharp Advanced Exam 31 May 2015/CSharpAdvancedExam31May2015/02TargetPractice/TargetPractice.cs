using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class TargetPractice
{
    static void Main(string[] args)
    {
        string[] dimensions = Console.ReadLine().Split();
        int rows = int.Parse(dimensions[0]);
        int cols = int.Parse(dimensions[1]);
        string snake = Console.ReadLine();
        string[] shotParameters = Console.ReadLine().Split();
        int impactRow = int.Parse(shotParameters[0]);
        int impactCol = int.Parse(shotParameters[1]);
        int radius = int.Parse(shotParameters[2]);
        char[,] matrix = new char[rows, cols];

        FillStairs(matrix, snake);
        ShotHit(matrix, impactRow, impactCol, radius);
        SnakeFall(matrix);
        Print(matrix);
    }
    static void FillStairs(char[,] matrix, string snake)
    {
        int counter = 0;
        bool Inverted = true;
        for (int row = matrix.GetUpperBound(0); row >= 0 ; row--)
        {
            if (Inverted)
            {
                for (int col = matrix.GetUpperBound(1); col >= 0; col--)
                {
                    matrix[row, col] = snake[counter++ % snake.Length];
                }
                Inverted = !Inverted;
            }
            else
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = snake[counter++ % snake.Length];
                }
                Inverted = !Inverted;
            }
        }
    }
    static void ShotHit(char[,]matrix, int impactRow, int impactCol, int radius)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int a = row - impactRow;
                int b = col - impactCol;
                if(a*a + b*b <= radius*radius)
                {
                    matrix[row, col] = ' ';
                }
            }
        }
    }
    static void SnakeFall(char[,]matrix)
    {
        int curRow = 0;
        for (int row = matrix.GetUpperBound(0); row > 0; row--)
        {
            for (int col = matrix.GetUpperBound(1); col >= 0; col--)
            {
                curRow = row;
                while (Char.IsWhiteSpace(matrix[row, col]) && curRow > 0)
                {
                    matrix[row, col] = matrix[--curRow, col];
                    matrix[curRow, col] = ' ';
                }
            }
        }
    }

    static void Print(char[,]matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row,col]);
            }
            Console.WriteLine();
        }
    }
}

