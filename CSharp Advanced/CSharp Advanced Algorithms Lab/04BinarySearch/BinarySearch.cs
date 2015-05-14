using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class BinarySearch
{
    static void Main(string[] args)
    {
        List<int> nums = Console.ReadLine().Split(new char[]{' '},StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        nums.Sort();
        int search = int.Parse(Console.ReadLine());
        var linear = LinearSearch(nums, search);
        var binary = BinarySearching(nums, search);
        Console.WriteLine(binary);
    }

    static int LinearSearch(List<int> nums, int search)
    {
        for (int i = 0; i < nums.Count; i++)
        {
            if(nums[i] == search)
            {
                return i;
            }
        }
        return -1;
    }

    static int BinarySearching(List<int> nums, int search)
    {
        
        int min = 0;
        int max = nums.Count - 1;
        while (max - min != 1)
        {
            int mid = min + ((max - min) / 2);
            if (nums[mid] == search)
            {
                while (mid -1 >= 0 && nums[mid - 1] == nums[mid])
                {
                    mid = mid - 1;
                }
                return mid;
            }
            else if (nums[mid] > search)
            {
                max = mid;
            }
            else if (nums[mid] < search)
            {
                min = mid;
            }
            if (max - min == 1)
            {
                break;
            }
        }
        
        return -1;
    }
}

