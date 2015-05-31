using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class MirrorNumbers
{
    static void Main(string[] args)
    {
        bool hasSolution = false;
        int count = int.Parse(Console.ReadLine());
        int[] nums = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        for (int i = 0; i < count; i++)
        {
            for (int l = i+1; l < count; l++)
            {
                int reversed = int.Parse(String.Join("",nums[i].ToString().Reverse()));
                if(reversed == nums[l] && nums[i] != nums[l])
                {
                    Console.WriteLine("{0}<!>{1}",nums[i],nums[l]);
                    hasSolution = true;
                }
            }
        }
        if(!hasSolution)
        {
            Console.WriteLine("No");
        }
    }
}

