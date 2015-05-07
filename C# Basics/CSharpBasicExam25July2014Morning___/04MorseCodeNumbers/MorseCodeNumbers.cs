using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class MorseCodeNumbers
{
    static void Main(string[] args)
    {
        int solutions = 0;
        string[] morse = new string[] { "-----", ".----", "..---", "...--", "....-", "....." };
        int n = int.Parse(Console.ReadLine());
        int nSum = n / 1000 + (n / 100) % 10 + (n / 10) % 10 + n % 10;
        for (int i1 = 0; i1 < 6; i1++)
        {
            for (int i2 = 0; i2 < 6; i2++)
            {
                for (int i3 = 0; i3 < 6; i3++)
                {
                    for (int i4 = 0; i4 < 6; i4++)
                    {
                        for (int i5 = 0; i5 < 6; i5++)
                        {
                            for (int i6 = 0; i6 < 6; i6++)
                            {
                                int morseProduct = i1 * i2 * i3 * i4 * i5 * i6;
                                if(morseProduct == nSum)
                                {
                                    Console.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}|",morse[i1],morse[i2],morse[i3],morse[i4],morse[i5],morse[i6]);
                                    solutions++;
                                }
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
}

