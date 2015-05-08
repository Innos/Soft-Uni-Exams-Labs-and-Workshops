using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ProgrammerDNA
{
    static void Main(string[] args)
    {
        char[] DNA = { 'A', 'B', 'C', 'D', 'E', 'F', 'G' };
        int length = int.Parse(Console.ReadLine());
        char startingLetter = char.Parse(Console.ReadLine());
        int blockSize = 7;
        int counter = Array.FindIndex(DNA, x => x == startingLetter);
        for (int rows = 0; rows < length; rows++)
        {
            int rowBlock = rows % blockSize;
            if (rowBlock <= blockSize / 2)
            {
                int lettersOnLine = (rowBlock * 2) + 1;
                string sideSpace = new string('.', (blockSize - lettersOnLine) / 2);
                string letters = "";
                for (int i = 0; i < lettersOnLine; i++)
                {
                    letters = letters + DNA[counter % DNA.Length];
                    counter++;
                }
                Console.WriteLine("{0}{1}{0}", sideSpace, letters);
            }
            else if (rowBlock > blockSize / 2)
            {
                int lettersOnLine = ((blockSize - 1) - rowBlock) * 2 + 1;
                string sideSpace = new string('.', (blockSize - lettersOnLine) / 2);
                string letters = "";
                for (int i = 0; i < lettersOnLine; i++)
                {
                    letters = letters + DNA[counter % DNA.Length];
                    counter++;
                }
                Console.WriteLine("{0}{1}{0}", sideSpace, letters);
            }
        }
    }
}

