using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static int maxSize = 0;
        static int startRow = 0;
        static int startCol = 0;
        static int endRow = 0;
        static int endCol = 0;

        static void Main(string[] args)
        {
            List<List<string>> matrix = new List<List<string>>();
            string input = Console.ReadLine();
            while (input != "END")
            {
                List<string> line = input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                matrix.Add(line);
                input = Console.ReadLine();
            }
            int topBorder = matrix[0].Count;
            for (int row1 = 0; row1 < matrix.Count; row1++)
            {
                for (int col1 = 0; col1 < topBorder; col1++)
                {
                    for (int row2 = matrix.Count - 1; row2 >= row1; row2--)
                    {
                        for (int col2 = topBorder - 1; col2 >= col1; col2--)
                        {
                            IsSquare(matrix, row1, col1, row2, col2);
                        }
                    }
                }
            }
            for (int i = 0; i < matrix.Count; i++)
            {
                for (int l = 0; l < topBorder; l++)
                {
                    if (i == startRow && (l >= startCol && l <= endCol) || i == endRow && (l >= startCol && l <= endCol) ||
                        l == startCol && (i >= startRow && i <= endRow) || l == endCol && (i >= startRow && i <= endRow))
                    {
                        matrix[i][l] = String.Format("[{0}]", matrix[i][l]);
                    }
                    Console.Write("{0,5}", matrix[i][l]);
                }
                Console.WriteLine();
            }

        }

        static void IsSquare(List<List<string>> matrix, int row1, int col1, int row2, int col2)
        {
            string element = matrix[row1][col1];
            for (int i = row1; i <= row2; i++)
            {
                if (matrix[i][col1] != element) return;

            }
            for (int i = row1; i <= row2; i++)
            {
                if (matrix[i][col2] != element) return;

            }
            for (int i = col1; i <= col2; i++)
            {
                if (matrix[row1][i] != element) return;

            }
            for (int i = col1; i <= col2; i++)
            {
                if (matrix[row2][i] != element) return;

            }
            int size = ((row2 - row1) + 1) * ((col2 - col1) + 1);
            if (size > maxSize)
            {
                maxSize = size;
                startRow = row1;
                startCol = col1;
                endRow = row2;
                endCol = col2;
            }

        }
    }
}
