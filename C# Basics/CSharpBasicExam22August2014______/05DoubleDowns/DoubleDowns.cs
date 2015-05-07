using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class DoubleDowns
{
    static void Main(string[] args)
    {
        int rightDiagonalCouples = 0;
        int leftDiagonalCouples = 0;
        int verticalCouples = 0;
        uint num1 =0;
        uint num2 = 0;
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n - 1; i++)
        {
            if(i == 0)
            {
                num1 = uint.Parse(Console.ReadLine());
                num2 = uint.Parse(Console.ReadLine());
            }
            else
            {
                num1 = num2;
                num2 = uint.Parse(Console.ReadLine());
            }
            for (int l = 0; l < 32; l++)
            {
                uint bit1 = (num1 >> l) & 1;
                uint prevBit = (num2 >> l - 1) & 1;
                uint nextBit = (num2 >> l + 1) & 1;
                uint bit2 = (num2 >> l) & 1;
                if (bit1 == 1 && bit1 == prevBit) rightDiagonalCouples++;
                if (bit1 == 1 && bit1 == nextBit) leftDiagonalCouples++;
                if (bit1 == 1 && bit1 == bit2) verticalCouples++;
            }
        }
        Console.WriteLine(rightDiagonalCouples);
        Console.WriteLine(leftDiagonalCouples);
        Console.WriteLine(verticalCouples);
    }
}

