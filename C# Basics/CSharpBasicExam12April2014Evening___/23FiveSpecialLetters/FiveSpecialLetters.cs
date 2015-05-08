using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class FiveSpecialLetters
{
    static void Main(string[] args)
    {
        int solutions = 0;
        int start = int.Parse(Console.ReadLine());
        int end = int.Parse(Console.ReadLine());
        char[] words = {'a','b','c','d','e'};
        for (int i1 = 0; i1 < 5; i1++)
        {
            for (int i2 = 0; i2 < 5; i2++)
            {
                for (int i3 = 0; i3 < 5; i3++)
                {
                    for (int i4 = 0; i4 < 5; i4++)
                    {
                        for (int i5 = 0; i5 < 5; i5++)
                        {
                            string letter = "";
                            if(i5 != i4 && i5 != i3 && i5 != i2 && i5 != i1)
                            {
                                letter = words[i5] + letter;
                            }
                            if(i4 != i3 && i4 != i2 && i4 != i1)
                            {
                                letter = words[i4] + letter;
                            }
                            if(i3 != i2 && i3 != i1)
                            {
                                letter = words[i3] + letter;
                            }
                            if(i2 != i1)
                            {
                                letter = words[i2] + letter;
                            }
                            letter = words[i1] + letter;
                            int weight = CalculateWeight(letter);
                            if(start <= weight && weight <= end)
                            {
                                Console.Write("{0}{1}{2}{3}{4} ",words[i1],words[i2],words[i3],words[i4],words[i5]);
                                solutions++;
                            }
                        }
                    }
                }
            }
        }
        if(solutions == 0)
        {
            Console.WriteLine("No");
        }
    }
    private static int CalculateWeight(string letter)
    {
        int weight = 0;
        int index = 1;
        foreach (var character in letter)
        {
            switch (character)
            {
                case 'a': weight = weight + (5 * index); index++; break;
                case 'b': weight = weight + (-12 * index); index++; break;
                case 'c': weight = weight + (47 * index); index++; break;
                case 'd': weight = weight + (7 * index); index++; break;
                case 'e': weight = weight + (-32 * index); index++; break;
            }
        }
        return weight;
    }
}

