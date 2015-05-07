using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class BitLock
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        int[] numbers = Array.ConvertAll(input.Split(' '), int.Parse);
        string command = Console.ReadLine();
        while (command != "end")
        {
            int row;
            string[] inp = command.Split(' ');
            bool isRotate = Int32.TryParse(inp[0], out row);
            if (isRotate)
            {
                string direction = inp[1];
                int rotations = int.Parse(inp[2]);
                for (int i = 0; i < rotations; i++)
                {
                    if (direction == "left")
                    {
                        int mask = (numbers[row] >> 11) & 1;
                        numbers[row] = numbers[row] & ~(1 << 11);
                        numbers[row] = numbers[row] << 1;
                        numbers[row] = numbers[row] | mask;
                    }
                    else
                    {
                        int mask = numbers[row] & 1;
                        numbers[row] = numbers[row] >> 1;
                        numbers[row] = numbers[row] | (mask << 11);
                    }
                }

            }
            else
            {
                int ones = 0;
                int col = int.Parse(inp[1]);
                foreach (var number in numbers)
                {
                    int bit = (number >> col) & 1;
                    if (bit == 1) ones++;
                }
                Console.WriteLine(ones);
            }
            command = Console.ReadLine();
        }
        foreach (var number in numbers)
        {
            Console.Write("{0} ",number);
        }
    }
}

