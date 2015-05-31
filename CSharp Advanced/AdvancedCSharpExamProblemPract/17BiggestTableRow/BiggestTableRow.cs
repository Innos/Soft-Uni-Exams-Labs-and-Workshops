using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


class BiggestTableRow
{
    static void Main(string[] args)
    {
        string table = Console.ReadLine();
        string firstLine = Console.ReadLine();
        string input;
        double maxSum = double.MinValue;
        bool resultFound = false;
        List<string> maxSumNumbers = new List<string>();

        while((input = Console.ReadLine()) != "</table>")
        {
            string pattern = @"<td>(.*?)</td>";
            MatchCollection matches = Regex.Matches(input, pattern);
            double sum = 0;
            List<string> numbers = new List<string>();    

            foreach (Match match in matches)
            {
                double number;
                bool isNumber = double.TryParse(match.Groups[1].Value,out number);
                if(isNumber)
                {
                    sum += number;
                    numbers.Add(match.Groups[1].Value);
                    resultFound = true;
                }
            }
            if (sum > maxSum)
            {
                maxSum = sum;
                maxSumNumbers = numbers;
            }
        }

        if(!resultFound)
        {
            Console.WriteLine("no data");
        }
        else
        {
            Console.WriteLine("{0} = {1}",maxSum,String.Join(" + ",maxSumNumbers));
        }
    }
}

