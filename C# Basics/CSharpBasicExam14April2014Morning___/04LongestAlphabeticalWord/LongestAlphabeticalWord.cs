using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class LongestAlphabeticalWord
{
    static void Main(string[] args)
    {
        int index = 0;
        string input = Console.ReadLine();
        char[] word = input.Select(letter => letter).ToArray();
        int width = int.Parse(Console.ReadLine());
        char[,] square = new char[width, width];
        for (int rows = 0; rows < width; rows++)
        {
            for (int cols = 0; cols < width; cols++)
            {
                square[rows, cols] = word[index % word.Length];
                index++;
            }
        }
        string longestWord = "";
        for (int rows = 0; rows < width; rows++)
        {
            for (int cols = 0; cols < width; cols++)
            {
                for (int i = 0; i < 4; i++) //Direction check for words 0 - right 1 - down 2 - left 3 - up
                {
                    string currentWord = square[rows,cols].ToString();
                    int row = rows;
                    int col = cols;
                    if (i == 0)
                    {
                        col++;
                        while (row < width && row >= 0 && col < width && col >= 0 && square[row, col] > currentWord.Last())
                        {
                            currentWord = currentWord + square[row, col];
                            col++;
                        }
                    }
                    else if (i == 1)
                    {
                        row++;
                        while (row < width && row >= 0 && col < width && col >= 0 && square[row, col] > currentWord.Last())
                        {
                            currentWord = currentWord + square[row, col];
                            row++;
                        }
                    }
                    else if (i == 2)
                    {
                        col--;
                        while (row < width && row >= 0 && col < width && col >= 0 && square[row, col] > currentWord.Last())
                        {
                            currentWord = currentWord + square[row, col];
                            col--;
                        }
                    }
                    else if (i == 3)
                    {
                        row--;
                        while (row < width && row >= 0 && col < width && col >= 0 && square[row, col] > currentWord.Last())
                        {
                            currentWord = currentWord + square[row, col];
                            row--;
                        }
                    }
                    if(currentWord.Length > longestWord.Length)
                    {
                        longestWord = currentWord;
                    }
                    else if(currentWord.Length == longestWord.Length && isAlphabeticallySmaller(currentWord,longestWord))
                    {
                        longestWord = currentWord;
                    }
                }
            }
        }
        Console.WriteLine(longestWord);

    }

    private static bool isAlphabeticallySmaller(string word, string longestWord)
    {
        bool smaller = true;
        for (int i = 0; i < word.Length; i++)
        {
            if (word[i] > longestWord[i])
            {
                smaller = false;
            }
        }
        return smaller;
    }
}

