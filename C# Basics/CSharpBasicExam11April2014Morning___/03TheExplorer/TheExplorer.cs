using System;

class TheExplorer
{
    static void Main(string[] args)
    {
        int length = int.Parse(Console.ReadLine());
        for (int i = 1; i <= length; i++)
        {
            if (i == 1 || i == length)
            {
                int spaces = (length - 1) / 2;
                string space = new string('-', spaces);
                Console.WriteLine("{0}{1}{0}", space, '*');
            }
            else if (i <= ((length / 2) + 1))
            {
                int midSpaces = (i - 2) * 2 + 1;
                int sideSpaces = (length - 2 - midSpaces) / 2;
                string midSpace = new string('-', midSpaces);
                string sideSpace = new string('-', sideSpaces);
                Console.WriteLine("{0}{1}{2}{1}{0}",sideSpace,'*',midSpace);
            }
            else if (i > ((length / 2) + 1))
            {
                int sideSpaces = i - ((length / 2) + 1);
                int midSpaces = length - (2 * sideSpaces) - 2;
                string sideSpace = new string('-', sideSpaces);
                string midSpace = new string('-', midSpaces);
                Console.WriteLine("{0}{1}{2}{1}{0}",sideSpace,'*',midSpace);
            }
        }
    }
}

