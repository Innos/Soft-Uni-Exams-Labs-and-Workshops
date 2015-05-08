using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


class TextBombardment
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        int lineWidth = int.Parse(Console.ReadLine());
        string input2 = Console.ReadLine();

        //setting length of the string to be divisible by lineWidth
        if (input.Length % lineWidth != 0)
        {
            input = input.PadRight(((input.Length / lineWidth) + 1) * lineWidth);
        }

        //puting the text into a single char array
        char[] lines = input.ToCharArray();

        //putting bombs into an int array
        int[] bombs = Array.ConvertAll(input2.Split(' '), int.Parse);

        //for each bomb we check (bomb's value == column value to be hit)
        foreach (var bomb in bombs)
        {
            //boolean to check if the bomb hit an empty space after a letter
            bool hitLetter = false;

            //we check the all collumns = bomb for all the rows (i.e. check all 3rd collumns in all rows)
            for (int rows = 0; rows < lines.Length / lineWidth; rows++)
            {
                if (!Char.IsWhiteSpace(lines[rows * lineWidth + bomb]))
                {
                    //pseudo multi array counting which number would correspond to the same column on a next row in a multidimensional array
                    // multiply rows * lineWidth and add columns value
                    lines[rows * lineWidth + bomb] = ' ';
                    hitLetter = true;
                }
                // if bomb hits an empty space after it has hit a letter we break the cycle for this bomb
                else if (hitLetter)
                {
                    break;
                }
            }
        }
        Console.WriteLine("{0}", String.Join("", lines));
    }
}

