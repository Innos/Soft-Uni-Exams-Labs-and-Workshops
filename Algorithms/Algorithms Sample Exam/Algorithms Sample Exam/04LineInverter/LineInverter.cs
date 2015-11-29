namespace _04LineInverter
{
    using System;
    using System.Linq;

    public class LineInverter
    {
        public static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            bool[,] board = new bool[size, size];
            for (int i = 0; i < size; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < size; j++)
                {
                    if (line[j] == 'W')
                    {
                        board[i, j] = true;
                    }
                }
            }

            int iteration = 0;
            int moves = size + size;
            while (true)
            {
                int[] whiteRows = new int[size];
                int[] whiteCols = new int[size];

                // iterate the board to find the white cells left in each row and col
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (board[i, j])
                        {
                            whiteRows[i]++;
                            whiteCols[j]++;
                        }
                    }
                }

                // amount of white cells in the row/col with most white cells
                int maxRowWhite = whiteRows.Max();
                int maxColWhite = whiteCols.Max();

                // exit condition 1 if the entire board is black
                if (maxRowWhite == 0 && maxColWhite == 0)
                {
                    Console.WriteLine(iteration);
                    break;
                }

                // invert row
                if (maxRowWhite >= maxColWhite)
                {
                    int rowIndex = IndexOfArray(whiteRows, maxRowWhite);
                    for (int i = 0; i < size; i++)
                    {
                        board[rowIndex, i] = !board[rowIndex, i];
                    }
                }
                else
                {
                    // invert col
                    int colIndex = IndexOfArray(whiteCols, maxColWhite);
                    for (int i = 0; i < size; i++)
                    {
                        board[i, colIndex] = !board[i, colIndex];
                    }
                }

                iteration++;

                // exit condition 2 if the board is not black after shifing every col or row once (i.e. no solution is possible)
                if (iteration >= moves)
                {
                    Console.WriteLine(-1);
                    break;
                }
            }
        }

        private static int IndexOfArray(int[] array, int value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
