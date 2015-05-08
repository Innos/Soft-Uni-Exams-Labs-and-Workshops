using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class BiggestTriple
{
    static void Main(string[] args)
    {
        int max = int.MinValue;
        double size = 3;
        string input = Console.ReadLine();
        if (input == "")
        {
            return;
        }
        int[] numbers = Array.ConvertAll(input.Split(' '), int.Parse);
        int[] maxSequence = new int[0];
        for (int i = 0; i < (numbers.Length / size); i++)
        {
            int lastSequenceLength = numbers.Length - (i * (int)size);
            int[] sequence = new int[(int)size];
            if (lastSequenceLength < 3)
            {
                Array.Resize(ref sequence, lastSequenceLength);
                Array.Copy(numbers, i * (int)size, sequence, 0, lastSequenceLength);
            }
            else
            {
                Array.Copy(numbers, i * (int)size, sequence, 0, (int)size);
            }
            if (sequence.Sum() > max)
            {
                max = sequence.Sum();
                maxSequence = sequence;
            }
        }
        for (int i = 0; i < maxSequence.Length; i++)
        {
            Console.Write(maxSequence[i] + " ");
        }
    }
}

