using System;

class CatchTheBits
{
    static void Main(string[] args)
    {
        byte bits = 0;
        int newNumber = 0;
        int sequences = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());
        int counter = 0;
        for (int i = 1; i <= sequences; i++)
        {
            int number = int.Parse(Console.ReadLine());
            for (int bit = 7; bit >= 0; bit--)
            {
                if (step == 1 && counter > 0 || counter % step == 1)
                {
                    newNumber = newNumber << 1;
                    newNumber = newNumber | (number >> bit) & 1;
                    bits++;
                    if (bits == 8)
                    {
                        Console.WriteLine(newNumber);
                        bits = 0;
                        newNumber = 0;
                    }
                }
                counter++;
            }
        }
        if (bits > 0)
        {
            newNumber = newNumber << (8 - bits);
            Console.WriteLine(newNumber);
        }
    }
}

