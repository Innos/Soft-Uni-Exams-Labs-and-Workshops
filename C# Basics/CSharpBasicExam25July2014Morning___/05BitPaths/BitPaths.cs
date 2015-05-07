using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class BitPaths
{
    static void Main(string[] args)
    {
        int[] numbers = new int[8];
        int lines = int.Parse(Console.ReadLine());
        for (int i = 0; i < lines; i++)
        {
            List<int> input = Array.ConvertAll(Console.ReadLine().Split(','),int.Parse).ToList();
            int rows = 0;
            int cols = input[0];
            input.RemoveAt(0);
            numbers[rows] ^= (1 << (3 - cols));
            foreach (var item in input)
            {
                rows++;
                cols = cols + item;
                numbers[rows] ^= (1 << (3 - cols));
            }
        }
        string binary = Convert.ToString(numbers.Sum(), 2);
        Console.WriteLine(binary);
        string hexadecimal = Convert.ToString(numbers.Sum(), 16).ToUpper();
        Console.WriteLine(hexadecimal);
    }
}

