using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class MagicSUm
{
    static void Main(string[] args)
    {
        bool hasSolution = false;
        int maxSum = int.MinValue;
        int[] maxNums = new int[3];
        int divider = int.Parse(Console.ReadLine());
        List<int> numbers = new List<int>();
        string input = Console.ReadLine();
        while(input != "End")
        {
            numbers.Add(int.Parse(input));
            input = Console.ReadLine();
        }
        for (int n1 = 0; n1 < numbers.Count; n1++)
        {
            for (int n2 = n1 + 1; n2 < numbers.Count; n2++)
            {
                for (int n3 = n2+1; n3 < numbers.Count; n3++)
                {
                    int sum = numbers[n1] + numbers[n2] + numbers[n3];
                    if(sum % divider == 0 && sum > maxSum)
                    {
                        maxSum = sum;
                        maxNums[0] = numbers[n1];
                        maxNums[1] = numbers[n2];
                        maxNums[2] = numbers[n3];
                        hasSolution = true;
                    }
                }
            }
        }
        if(hasSolution)
        {
            Console.WriteLine("({0} + {1} + {2}) % {3} = 0",maxNums[0],maxNums[1],maxNums[2],divider);
        }
        else
        {
            Console.WriteLine("No");
        }
    }
}

