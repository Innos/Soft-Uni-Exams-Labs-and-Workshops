using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class WeirdCombinations
{
    static void Main(string[] args)
    {
        bool solution = false;
        int counter = -1;
        char[] input = Console.ReadLine().ToCharArray();
        int element = int.Parse(Console.ReadLine());
        for (int i1 = 0; i1 < input.Length; i1++)
        {
            for (int i2 = 0; i2 < input.Length; i2++)
            {
                for (int i3 = 0; i3 < input.Length; i3++)
                {
                    for (int i4 = 0; i4 < input.Length; i4++)
                    {
                        for (int i5 = 0; i5 < input.Length; i5++)
                        {
                            counter++;
                            if(counter == element)
                            {
                                Console.WriteLine("{0}{1}{2}{3}{4}",input[i1],input[i2],input[i3],input[i4],input[i5]);
                                solution = true;
                            }
                        }
                    }
                }
            }
        }
        if(!solution)
        {
            Console.WriteLine("No");
        }
    }
}

