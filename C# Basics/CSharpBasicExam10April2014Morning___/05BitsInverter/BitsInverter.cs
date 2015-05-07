using System;



class BitsInverter
{
    static void Main(string[] args)
    {
        int sequences = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());
        int index = 0;
        for (int i = 1; i <= sequences; i++)
        {
            int number = int.Parse(Console.ReadLine());
            for(int bit = 7; bit >= 0; bit--)
            {
                index++;
                if(step == 1 || index % step == 1)
                {
                    number = number ^ (1 << bit);
                }

            }
            Console.WriteLine(number);
        }
    }
}

