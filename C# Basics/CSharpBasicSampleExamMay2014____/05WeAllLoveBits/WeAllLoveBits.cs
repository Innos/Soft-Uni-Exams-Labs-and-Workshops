using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class WeAllLoveBits
{
    static void Main(string[] args)
    {
        int newNumber = 0;
        int reversedNumber = 0;
        int invertedNumber = 0;
        int sequences = int.Parse(Console.ReadLine());
        for (int i = 0; i < sequences; i++)
        {
            int num = int.Parse(Console.ReadLine());
            invertedNumber = Invert(num);
            reversedNumber = Reverse(num);
            newNumber = (num ^ invertedNumber) & reversedNumber;
            Console.WriteLine(newNumber);
        }
    }
    private static int Invert(int number)
    {
        int power = 0;
        int num = number;
        while(num > 0)
        {
            num = num / 2;
            power++;

        }
        int newNumber = number ^ ((int)Math.Pow(2,power)-1);
        return newNumber;
    }
    private static int Reverse(int number)
    {
        int newNumber = 0;
        int power = 0;
        int num = number;
        while (num > 0)
        {
            num = num / 2;
            power++;

        }
        for (int i = 0; i < power; i++)
        {
            int mask = (number >> i) & 1;
            newNumber = newNumber << 1;
            newNumber = newNumber | mask;
        }
        return newNumber;
    }
}

