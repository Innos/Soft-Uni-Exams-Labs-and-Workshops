using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;


class ChangeEvenBits
{
    static void Main(string[] args)
    {
        int bitsChanged = 0;
        int n = int.Parse(Console.ReadLine());
        int[] nums = new int[n];
        for (int i = 0; i < n; i++)
        {
            nums[i] = int.Parse(Console.ReadLine());
        }
        BigInteger L = BigInteger.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            int len = Convert.ToString(nums[i], 2).Length;
            for (int l = 0; l < len; l++)
            {
                BigInteger oldL = L;
                L = L | (1 << (l * 2));
                if (L != oldL) bitsChanged++;
            }
        }
        Console.WriteLine(L);
        Console.WriteLine(bitsChanged);
    }
}

