using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class HalfByteSwapper
{
    static void Main(string[] args)
    {
        long[] number = new long[4];
        for (int i = 0; i < number.Length; i++)
        {
            number[i] = long.Parse(Console.ReadLine());
        }
        string command1 = Console.ReadLine();
        string command2 = "";
        if (command1 != "End")
        {
            command2 = Console.ReadLine();
        }
        while (command1 != "End")
        {
            int num1 = int.Parse(command1.Split(' ')[0]);
            int halfByte1 = int.Parse(command1.Split(' ')[1]);
            int num2 = int.Parse(command2.Split(' ')[0]);
            int halfByte2 = int.Parse(command2.Split(' ')[1]);
            long mask1 = (number[num1] >> (halfByte1 * 4)) & 15;
            long mask2 = (number[num2] >> (halfByte2 * 4)) & 15;
            number[num1] = number[num1] & ~(15 << halfByte1 * 4);
            number[num2] = number[num2] & ~(15 << halfByte2 * 4);
            number[num1] = number[num1] | (mask2 << halfByte1 * 4);
            number[num2] = number[num2] | (mask1 << halfByte2 * 4);

            command1 = Console.ReadLine();
            if (command1 == "End") break;
            command2 = Console.ReadLine();
        }
        foreach (var num in number)
        {
            Console.WriteLine(num);
        }
    }
}

