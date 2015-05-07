using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ByteParty
{
    static void Main(string[] args)
    {
        int sequences = int.Parse(Console.ReadLine());
        int[] numbers = new int[sequences];
        for (int i = 0; i < sequences; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }
        string input = Console.ReadLine();
        while (!(input == "party over"))
        {
            int action = int.Parse(input.Split(' ')[0]);
            int position = int.Parse(input.Split(' ')[1]);
            int mask = 1 << position;
            for (int i = 0; i < sequences; i++)
            {
                if (action == -1)
                {
                    numbers[i] = numbers[i] ^ mask;
                }
                if (action == 0)
                {
                    numbers[i] = numbers[i] & ~(mask);
                }
                if(action == 1)
                {
                    numbers[i] = numbers[i] | mask;
                }
            }
            input = Console.ReadLine();
        }
        for (int i = 0; i < sequences; i++)
        {
            Console.WriteLine(numbers[i]);
        }
    }
}

