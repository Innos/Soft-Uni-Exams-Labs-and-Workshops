using System;

public class ScotlandFlag
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int counterLeft = 0;
        int counterMiddle = n - 2;
        int counterRight = 0;
        char letter = 'A';

        for (int i = 0; i < n / 2; i++)
        {
            Console.Write(new string('~', counterLeft));
            counterLeft++;
            Console.Write(letter);
            letter = GetNextLetter(letter);
            Console.Write(new string('#', counterMiddle));
            counterMiddle -= 2;
            Console.Write(letter);
            letter = GetNextLetter(letter);
            Console.Write(new string('~', counterRight));
            counterRight++;
            Console.WriteLine();
        }

        Console.Write(new string('-', counterLeft));
        Console.Write(letter);
        letter = GetNextLetter(letter);
        Console.Write(new string('-', counterRight));
        Console.WriteLine();

        counterLeft = (n / 2) - 1;
        counterMiddle = 1;
        counterRight = (n / 2) - 1;

        for (int i = 0; i < n / 2; i++)
        {
            Console.Write(new string('~', counterLeft));
            counterLeft--;
            Console.Write(letter);
            letter = GetNextLetter(letter);
            Console.Write(new string('#', counterMiddle));
            counterMiddle += 2;
            Console.Write(letter);
            letter = GetNextLetter(letter);
            Console.Write(new string('~', counterRight));
            counterRight--;
            Console.WriteLine();
        }
    }

    static char GetNextLetter(char letter)
    {
        letter++;
        if (letter > 'Z')
        {
            letter = 'A';
        }
        return letter;
    }
}
