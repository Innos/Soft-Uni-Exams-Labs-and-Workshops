using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class XBits
{
    static void Main(string[] args)
    {
        int XBits = 0;
        int[] numbers = new int[8];
        for (int i = 0; i < 8; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }
        for (int i = 0; i < numbers.Length-2; i++)
			{
                for (int bit = 29; bit >= 0; bit--)
                {
                    int startBits = (numbers[i] >> bit) & 7;
                    int midBits = (numbers[i+1] >> bit) & 7;
                    int endBits = (numbers[i + 2] >> bit) & 7;
                    if(startBits == 5 && midBits == 2 && endBits == 5)
                    {
                        XBits++;
                    }
                }
			}
        Console.WriteLine(XBits);
    }
}

