using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class SprialMatrix
{
    static void Main(string[] args)
    {
        int counter = 0;
        int size = int.Parse(Console.ReadLine());
        int[,] matrix = new int[size, size];
        char[] word = Console.ReadLine().ToLower().ToCharArray();
        int[] wordValues = Array.ConvertAll(word, c => (c - 'a' + 1) * 10);
        int rows = 0;
        int cols = 0;
        string direction = "right";
        for (int i = 0; i < size * size; i++)
        {
            if (direction == "right" && (cols + 1>= size || matrix[rows, cols+1] != 0))
            {
                direction = "down";
            }
            else if (direction == "down" && (rows + 1>= size || matrix[rows + 1, cols] != 0))
            {
                direction = "left";
            }
            else if (direction == "left" && (cols - 1< 0 || matrix[rows, cols- 1] != 0))
            {
                direction = "up";
            }
            else if (direction == "up" && (rows - 1< 0 || matrix[rows - 1, cols] != 0))
            {
                direction = "right";
            }


            if (direction == "right")
            {
                matrix[rows, cols] = wordValues[counter++ % wordValues.Length];
                cols += 1;
            }
            else if (direction == "down")
            {
                matrix[rows, cols] = wordValues[counter++ % wordValues.Length];
                rows += 1;
            }
            else if (direction == "left")
            {
                matrix[rows, cols] = wordValues[counter++ % wordValues.Length];
                cols -= 1;
            }
            else if (direction == "up")
            {
                matrix[rows, cols] = wordValues[counter++ % wordValues.Length];
                rows -= 1;
            }
        }
        int[] sums = new int[size];
        for (int i = 0; i < size; i++)
        {
            for (int l = 0; l < size; l++)
            {
                sums[i] = sums[i] + matrix[i,l];
            }
        }
        Console.WriteLine("{0} - {1}",Array.IndexOf(sums,sums.Max()),sums.Max());
    }
}

