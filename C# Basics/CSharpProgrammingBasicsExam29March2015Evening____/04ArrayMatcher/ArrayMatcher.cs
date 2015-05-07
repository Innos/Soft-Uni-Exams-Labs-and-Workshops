using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ArrayMatcher
{
    static void Main(string[] args)
    {
        List<char> result = new List<char>();
        string[] input = Console.ReadLine().Split('\\');

        string left = input[0];
        string right = input[1];
        string command = input[2];

        if(command == "join")
        {
            for (int i = 0; i < left.Length; i++)
            {
                if(right.Contains(left[i]))
                {
                    result.Add(left[i]);
                }
            }
        }
        else if(command == "right exclude")
        {
            for (int i = 0; i < left.Length; i++)
            {
                if(right.Contains(left[i]) == false)
                {
                    result.Add(left[i]);
                }
            }
        }
        else if (command == "left exclude")
        {
            for (int i = 0; i < right.Length; i++)
            {
                if (left.Contains(right[i]) == false)
                {
                    result.Add(right[i]);
                }
            }
        }
        result.Sort();
        foreach(var entry in result)
        {
            Console.Write(entry);
        }
    }
}

