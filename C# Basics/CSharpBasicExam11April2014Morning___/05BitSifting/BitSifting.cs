using System;

class BitSifting
{
    static void Main(string[] args)
    {
        ulong number = ulong.Parse(Console.ReadLine());
        int sieves = int.Parse(Console.ReadLine());
        for (int i = 1; i <= sieves; i++)
        {
            ulong currentSieve = ulong.Parse(Console.ReadLine());
            number = number & ~(currentSieve);
        }
        Console.WriteLine(SparseBitCount(number));
    }

    static int SparseBitCount(ulong num)
    {
        int count = 0;
        while (num != 0)
        {
            count++;
            num &= (num - 1);
        }
        return count;
    }
}

