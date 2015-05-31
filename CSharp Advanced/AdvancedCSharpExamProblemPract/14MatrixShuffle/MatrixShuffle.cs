using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


class MatrixShuffle
{
    static void Main(string[] args)
    {
        int size = int.Parse(Console.ReadLine());
        string text = Console.ReadLine();
        char[,] matrix = new char[size, size];
        string direction = "right";
        int row = 0;
        int col = 0;
        for (int i = 0; i < text.Length; i++)
        {
            if (direction == "right" && (col >= size || matrix[row, col] != '\0'))
            {
                direction = "down";
                col -= 1;
                row += 1;
            }
            else if (direction == "down" && (row >= size || matrix[row, col] != '\0'))
            {
                direction = "left";
                row -= 1;
                col -= 1;
            }
            else if (direction == "left" && (col < 0 || matrix[row, col] != '\0'))
            {
                direction = "up";
                col += 1;
                row -= 1;
            }
            else if (direction == "up" && (row < 0 || matrix[row, col] != '\0'))
            {
                direction = "right";
                row += 1;
                col += 1;
            }
            matrix[row, col] = text[i];
            switch (direction)
            {
                case "right": col++; break;
                case "down": row++; break;
                case "left": col--; break;
                case "up": row--; break;
            }
        }

        string first = "";
        string second = "";
        for (int rows = 0; rows < size; rows++)
        {
            for (int cols = 0; cols < size; cols++)
            {
                if (rows % 2 == 0)
                {
                    if (cols % 2 == 0)
                    {
                        first = first + matrix[rows, cols];
                    }
                    else
                    {
                        second = second + matrix[rows, cols];
                    }
                }
                else
                {
                    if (cols % 2 == 0)
                    {
                        second = second + matrix[rows, cols];
                    }
                    else
                    {
                        first = first + matrix[rows, cols];
                    }
                }
            }
        }
        string sentence = first + second;
        string pattern = @"[\W0-9_]*";
        string textToCheck = Regex.Replace(sentence, pattern, "").ToLower();
        if(IsPalindrome(textToCheck))
        {
            Console.WriteLine("<div style='background-color:#4FE000'>{0}</div>",sentence);
        }
        else
        {
            Console.WriteLine("<div style='background-color:#E0000F'>{0}</div>",sentence);
        }

    }
    static bool IsPalindrome(string textToCheck)
    {
        if(textToCheck == String.Join("",textToCheck.Reverse()))
        {
            return true;
        }
        return false;
    }
}

