using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class InsertionSort
{
    static void Main(string[] args)
    {
        List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
        for (int i = 1; i < nums.Count; i++)
        {
            int l = i;
            int x = nums[i];
            while (l > 0 && nums[l-1] > x)
            {
                    nums[l] = nums[l-1];
                    l = l - 1;
            }
            nums[l] = x;
        }
        Console.WriteLine(String.Join(" ",nums));
    }
}

