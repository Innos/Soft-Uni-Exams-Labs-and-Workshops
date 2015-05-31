using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class PossibleTriangles
{
    static void Main(string[] args)
    {
        bool hasSolution = false;
        string input = Console.ReadLine();
        while(input != "End")
        {
            double a;
            double b;
            double c;
            double[] nums = Array.ConvertAll(input.Split(), double.Parse);
            if(nums[0] > nums[1])
            {
                a = nums[1];
                if(nums[0] > nums[2])
                {
                    b = nums[2];
                    c = nums[0];
                }
                else
                {
                    b = nums[0];
                    c = nums[2];
                }
            }
            else
            {
                a = nums[0];
                if (nums[1] > nums[2])
                {
                    b = nums[2];
                    c = nums[1];
                }
                else
                {
                    b = nums[1];
                    c = nums[2];
                }
            }
            if(a > b)
            {
                double temp = a;
                a = b;
                b = temp;
            }
            if(a + b > c)
            {
                Console.WriteLine("{0:F2}+{1:F2}>{2:F2}",a,b,c);
                hasSolution = true;
            }
            input = Console.ReadLine();
        }
        if(!hasSolution)
        {
            Console.WriteLine("No");
        }
    }
}

