using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class PandaScotlandFlag
{
    static void Main(string[] args)
    {
        int counter = 0;
        char[] letter = new char[]{'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};
        int length = int.Parse(Console.ReadLine());
        for (int rows = 0; rows < length; rows++)
        {
            if(rows == length/2)
            {
                Console.WriteLine("{0}{1}{0}",new string('-',length/2),letter[counter++%26]);
            }
            else if(rows < length/2)
            {
                Console.WriteLine("{0}{1}{2}{3}{0}", new string('~', rows), letter[counter++ % 26], new string('#', length - rows * 2 - 2), letter[counter++ % 26]);

            }
            else if(rows > length/2)
            {
                int size = (length - 1) - rows;
                Console.WriteLine("{0}{1}{2}{3}{0}", new string('~', size), letter[counter++ % 26], new string('#', length - size * 2 - 2), letter[counter++ % 26]);
            }
        }
    }
}

