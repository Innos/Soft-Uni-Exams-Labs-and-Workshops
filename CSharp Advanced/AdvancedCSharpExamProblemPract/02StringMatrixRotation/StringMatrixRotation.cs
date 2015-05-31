using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class StringMatrixRotation
{
    static void Main(string[] args)
    {
        int maxLength = 0;
        List<string> matrix = new List<string>();
        string input = Console.ReadLine();
        int degrees = (int.Parse(input.Split('(',')')[1]) % 360);
        string line = Console.ReadLine();
        while(line != "END")
        {
            int length = line.Length;
            if(length > maxLength)
            {
                maxLength = length;
            }

            matrix.Add(line);
            line = Console.ReadLine();
        }

        for (int i = 0; i < matrix.Count; i++)
        {
            matrix[i] = matrix[i].PadRight(maxLength,' ');
        }

        switch(degrees)
        {
            case 0 :
                for (int row = 0; row < matrix.Count; row++)
                {
                    for (int col = 0; col < maxLength; col++)
                    {
                        Console.Write(matrix[row][col]); 
                    }
                    Console.WriteLine();
                }
                break;

            case 90:
                for (int col = 0; col < maxLength; col++)
                {
                    for (int row = matrix.Count - 1; row >= 0; row--)
                    {
                        Console.Write(matrix[row][col]);
                    }
                    Console.WriteLine();
                }
                break;

            case 180:
                for (int row = matrix.Count - 1; row >=0; row--)
                {
                    for (int col = maxLength - 1; col >= 0; col--)
                    {
                        Console.Write(matrix[row][col]);
                    }
                    Console.WriteLine();
                }
                break;

            case 270:
                for (int col = maxLength - 1; col >= 0; col--)
                {
                    for (int row = 0; row < matrix.Count; row++)
                    {
                        Console.Write(matrix[row][col]);
                    }
                    Console.WriteLine();
                }
                break;
        }

    }
}

