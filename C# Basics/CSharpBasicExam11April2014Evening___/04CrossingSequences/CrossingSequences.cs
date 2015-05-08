using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class CrossingSequences
{
    static void Main(string[] args)
    {
        int solutions = 0;
        int index1 = 2;
        int index2 = 1;
        int[] tribonacci = new int[4];
        tribonacci[0] = int.Parse(Console.ReadLine());
        tribonacci[1] = int.Parse(Console.ReadLine());
        tribonacci[2] = int.Parse(Console.ReadLine());
        int sequence = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());
        while(tribonacci[index1] + tribonacci[index1-1] + tribonacci[index1-2] <= 1000000)
        {
            index1++;
            Array.Resize(ref tribonacci, tribonacci.Length + 1);
            tribonacci[index1] = tribonacci[index1 - 1] + tribonacci[index1 - 2] + tribonacci[index1 - 3];
        }
        while(sequence + (step*(index2/2)) <= 1000000)
        {
            sequence = sequence + (step * (index2/2));
            index2++;
            if(tribonacci.Contains(sequence))
            {
                Console.WriteLine(sequence);
                solutions++;
                break;
            }
        }
        if(solutions == 0)
        {
            Console.WriteLine("No");
        }
    }
}

