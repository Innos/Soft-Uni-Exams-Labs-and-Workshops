using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Pyramid
{
    static void Main(string[] args)
    {
        string input;
        List<int> result = new List<int>();
        int lines = int.Parse(Console.ReadLine());
        int[] line = new int[lines];
        int lastElement = int.Parse(Console.ReadLine());
        result.Add(lastElement);
        for (int row = 1; row < lines; row++)
        {
            input = Console.ReadLine();
            line = Array.ConvertAll(input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
            int min = int.MaxValue;
            for (int col = 0; col < line.Length; col++)
            {
                if(min > line[col] && line[col] > lastElement)
                {    
                        min = line[col];
                }
                
            }
            if(min != int.MaxValue)
            {
                result.Add(min);
                lastElement = min;
            }
            else
            {
                lastElement++;
            }
        }
        Console.WriteLine(String.Join(", ",result));
    }
}

