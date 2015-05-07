using System;

class BitsUp
{
    static void Main(string[] args)
    {
        int counter = 0;
        int sequences = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());
        for (int i = 1; i <= sequences; i++)
        {
            int number = int.Parse(Console.ReadLine());
            for (sbyte bit = 7; bit >= 0; bit--)
            {
                if (step == 1 && counter > 0 || counter % step == 1)
                {
                    number = number | (1 << bit);
                }
                counter++;
            }
            Console.WriteLine(number);
        }
    }
}

