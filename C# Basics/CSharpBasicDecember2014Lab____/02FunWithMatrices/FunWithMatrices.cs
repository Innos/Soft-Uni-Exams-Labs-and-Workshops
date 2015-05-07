using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class FunWithMatrices
{
    static void Main(string[] args)
    {
        int index = 0;
        double[,] matrix = new double[4, 4];
        double initialValue = double.Parse(Console.ReadLine());
        double step = double.Parse(Console.ReadLine());
        for (int row = 0; row < 4; row++)
        {
            for (int col = 0; col < 4; col++)
            {
                matrix[row, col] = initialValue + index * step;
                index++;
            }
        }
        string input = Console.ReadLine();
        while (!(input.Contains("Game Over!")))
        {
            int row = int.Parse(input.Split(' ')[0]);
            int col = int.Parse(input.Split(' ')[1]);
            double num = double.Parse(input.Split(' ')[3]);
            if (input.Contains("multiply"))
            {
                matrix[row, col] = matrix[row, col] * num;
            }
            else if (input.Contains("sum"))
            {
                matrix[row, col] = matrix[row, col] + num;
            }
            else if (input.Contains("power"))
            {
                matrix[row, col] = Math.Pow(matrix[row, col], num);
            }
            input = Console.ReadLine();
        }
        double[] rowValue = new double[4];
        double[] colValue = new double[4];
        double leftDiagonalValue = 0;
        double rightDiagonalValue = 0;
        for (int row = 0; row < 4; row++)
        {
            for (int col = 0; col < 4; col++)
            {
                rowValue[row] = rowValue[row] + matrix[row, col];
                colValue[row] = colValue[row] + matrix[col, row];
            }
            leftDiagonalValue = leftDiagonalValue + matrix[row, row];
            rightDiagonalValue = rightDiagonalValue + matrix[row, 3 - row];
        }
        double indexRow = Array.FindIndex(rowValue, x => x == rowValue.Max());
        double indexCol = Array.FindIndex(colValue, x => x == colValue.Max());
        double max1 = Math.Max(rowValue.Max(),colValue.Max());
        double max2 = Math.Max(leftDiagonalValue,rightDiagonalValue);
        double maxLine = Math.Max(max1,max2);
        if(maxLine == rowValue.Max())
        {
            Console.WriteLine("ROW[{0}] = {1:0.00}",indexRow,maxLine);
        }
        else if(maxLine == colValue.Max())
        {
            Console.WriteLine("COLUMN[{0}] = {1:0.00}",indexCol,maxLine);
        }
        else if(maxLine == leftDiagonalValue)
        {
            Console.WriteLine("LEFT-DIAGONAL = {0:0.00}",maxLine);
        }
        else if(maxLine == rightDiagonalValue)
        {
            Console.WriteLine("RIGHT-DIAGONAL = {0:0.00}",maxLine);
        }
    }
}

