using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class PythagoreanNumbers
{
    static void Main(string[] args)
    {
        bool solution = false;
        int count = int.Parse(Console.ReadLine());
        List<int> numbers = new List<int>();
        for (int i = 0; i < count; i++)
        {
            numbers.Add(int.Parse(Console.ReadLine()));
        }
        for (int a = 0; a < numbers.Count; a++)
        {
            for (int b = 0; b < numbers.Count; b++)
            {
                for (int c = 0; c < numbers.Count; c++)
                {
                    if (numbers[a]<=numbers[b] && (numbers[a] * numbers[a] + numbers[b] * numbers[b] == numbers[c] * numbers[c]))
                    {
                        Console.WriteLine("{0}*{0} + {1}*{1} = {2}*{2}", numbers[a], numbers[b], numbers[c]);
                        solution = true;
                    }
                }
            }
        }
        if (!solution)
        {
            Console.WriteLine("No");
        }
    }
}

