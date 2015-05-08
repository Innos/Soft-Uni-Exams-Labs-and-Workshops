using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class EcnryptedMatrix
{
    static void Main(string[] args)
    {
        string result = "";
        string input = Console.ReadLine();
        string direction = Console.ReadLine();
        int[] number = new int[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            number[i] = (input[i] % 10);
        }
        for (int i = 0; i < number.Length; i++)
        {
            int digit = number[i];
            if (digit % 2 == 0)
            {
                digit = number[i] * number[i];
            }
            else
            {
                if (i == 0 && i == number.Length - 1)
                {
                    digit = number[i] + 0;
                }
                else if (i == 0)
                {
                    digit = number[i] + 0 + number[i + 1];
                }
                else if (i == number.Length - 1)
                {
                    digit = number[i] + 0 + number[i - 1];
                }
                else
                {
                    digit = number[i] + number[i + 1] + number[i - 1];
                }
            }
            result = result + digit.ToString();
        }
        int size = result.Length;
        if (direction == "/")
        {
            for (int rows = 0; rows < size; rows++)
            {
                for (int cols = 0; cols < size; cols++)
                {
                    if (rows + cols == size - 1)
                    {
                        Console.Write("{0} ", result[cols]);
                    }
                    else
                    {
                        Console.Write("{0} ", 0);
                    }
                }
                Console.WriteLine();
            }
        }
        else if (direction == "\\")
        {
            for (int rows = 0; rows < size; rows++)
            {
                for (int cols = 0; cols < size; cols++)
                {
                    if (rows == cols)
                    {
                        Console.Write("{0} ", result[cols]);
                    }
                    else
                    {
                        Console.Write("{0} ", 0);
                    }
                }
                Console.WriteLine();
            }
        }

    }
}

