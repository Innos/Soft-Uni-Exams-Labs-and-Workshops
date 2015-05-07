using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class SequenceOfKNumbers
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ');
        int k = int.Parse(Console.ReadLine());
        for (int i = 0; i < input.Length; i++)
        {
            if((input.Length - i)<k)
            {
                Console.Write(input[i] + " ");
            }
            else
            {
                for (int l = 1; l < k; l++)
                {
                    if (i + l >= input.Length)
                    {
                        break;
                    }
                    else
                    {
                        if (input[i] != input[i + l])
                        {
                            Console.Write(input[i] + " ");
                            break;
                        }
                        else if (l == k - 1)
                        {

                            i = i + (k - 1);
                        }
                    }

                }
            }
        }
    }
}

