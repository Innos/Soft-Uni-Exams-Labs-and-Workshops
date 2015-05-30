using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class CoupleFrequency
{
    static void Main(string[] args)
    {
        int allCouples = 0;
        Dictionary<string, int> couples = new Dictionary<string, int>();
        string input = Console.ReadLine();
        int[] nums = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        for (int i = 1; i < nums.Length; i++)
        {
            string couple = nums[i - 1] + " " + nums[i];
            if(!couples.ContainsKey(couple))
            {
                couples.Add(couple, 0);
            }
            couples[couple]++;
            allCouples++;
        }
        foreach (var pair in couples)
        {
            double percent = (pair.Value / (double)allCouples) * 100; 
            Console.WriteLine("{0} -> {1:F2}%",pair.Key, percent );
        }
    }
}

