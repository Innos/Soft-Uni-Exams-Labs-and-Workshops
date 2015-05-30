using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;


class TextGravity
{
    static void Main(string[] args)
    {
        int lineLength = int.Parse(Console.ReadLine());
        string text = Console.ReadLine();
        StringBuilder sb = new StringBuilder(text);
        while (sb.Length % lineLength != 0)
        {
            sb.Append(" ");
        }
        text = sb.ToString();
        int rows = text.Length / lineLength;
        char[,] matrix = new char[rows, lineLength];
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < lineLength; col++)
            {
                matrix[row, col] = text[col + lineLength * row];
            }
        }
        TextDrop(matrix);
        Print(matrix);

    }

    static void TextDrop(char[,] matrix)
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

    static void Print(char[,] matrix)
    {
        Console.Write("<table>");
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            Console.Write("<tr>");
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("<td>{0}</td>", SecurityElement.Escape(matrix[row, col].ToString()));
            }
            Console.Write("</tr>");
        }
        Console.Write("</table>");
    }
}

