using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class SieveOfErathosthenes
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<int> nums = new List<int>(Enumerable.Range(0, n+1));
        int p = 2;
        int limit = (int)Math.Sqrt(n);
        nums[0] = -1;
        nums[1] = -1;
            for (p = 2; p <= limit;p++)
            {
                if(nums[p] == -1)
                {
                    continue;
                }
                else
                {
                    for (int i = 2; i * p <= n; i++)
                    {
                        nums[i * p] = -1;
                    }
                }
               
            }
        Console.WriteLine(string.Join(", ",nums.Where(x=> x != -1)));
    }
}

