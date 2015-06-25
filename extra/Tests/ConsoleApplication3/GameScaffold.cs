using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class CommandInterpreter
{
    static void Main()
    {
        // input

        var sortFrom = @"(sort\s+from\s+)(-?\d+)(\s+count\s+)(-?\d+)|(-?\d+)(\s+count\s+)(-?\d+)|(sort\s+from\s+)(-?\d+)\s?(-?\d+)";
        Regex sort = new Regex(sortFrom);
        var reverse = @"(reverse\s+from\s+)(-?\d+)(\s+count\s+)(-?\d+)";
        Regex rev = new Regex(reverse);
        var rollLeft = @"(rollLeft\s+)(-?\d+)";
        Regex RL = new Regex(rollLeft);
        var rollRight = @"(rollRight\s+)(-?\d+)";
        Regex RR = new Regex(rollRight);

        var seriesOfStrings =
            Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        var L = seriesOfStrings.Count;

        while (true)
        {
            var line = Console.ReadLine().Trim();

            if (line == "end")
            {
                break;
            }

            Match matchSort = sort.Match(line);
            Match matchReverse = rev.Match(line);
            Match matchRL = RL.Match(line);
            Match matchRR = RR.Match(line);

            if (matchReverse.Success)
            {
                int start = int.Parse(matchReverse.Groups[2].Value);
                int count = int.Parse(matchReverse.Groups[4].Value);

                if (start < 0 || start > L - 1 || count < 0)
                {
                    Console.WriteLine("Invalid input parameters.");
                }
                else
                {
                    var piece = seriesOfStrings.Skip(start).Take(count);
                    piece = piece.Reverse().ToList();
                    seriesOfStrings.RemoveRange(start, count);
                    seriesOfStrings.InsertRange(start, piece);
                }
            }
            else if (matchSort.Success)
            {
                int start = int.Parse(matchSort.Groups[2].Value);
                int count = int.Parse(matchSort.Groups[4].Value);

                if (start < 0 || start > L - 1 || count < 0)
                {
                    Console.WriteLine("Invalid input parameters.");
                }
                else
                {
                    var piece = seriesOfStrings.Skip(start).Take(count).ToList();
                    piece.Sort();
                    seriesOfStrings.RemoveRange(start, count);
                    seriesOfStrings.InsertRange(start, piece);
                }
            }
            else if (matchRL.Success)
            {
                int count = int.Parse(matchRL.Groups[2].Value);

                if (count < 0)
                {
                    Console.WriteLine("Invalid input parameters.");
                }
                else
                {
                    var piece = seriesOfStrings.Take(count % L).ToList();
                    seriesOfStrings.RemoveRange(0, count % L);
                    seriesOfStrings = seriesOfStrings.Concat(piece).ToList();
                }
            }
            else if (matchRR.Success)
            {
                int count = int.Parse(matchRR.Groups[2].Value);

                if (count < 0)
                {
                    Console.WriteLine("Invalid input parameters.");
                }
                else
                {
                    //Console.WriteLine(L);
                    //Console.WriteLine(count % L);
                    var piece = seriesOfStrings.Skip(seriesOfStrings.Count - (count % L)).Take(count % L).ToList();
                    //Console.WriteLine(string.Join(" ", piece));
                    //piece.Reverse();
                    //Console.WriteLine(string.Join(" ", piece));
                    seriesOfStrings.RemoveRange(seriesOfStrings.Count - (count % L), (count % L));
                    seriesOfStrings = piece.Concat(seriesOfStrings).ToList();
                }
            }
            else
            {
                Console.WriteLine("Invalid input parameters.");
            }
        }
        Console.WriteLine("[{0}]", string.Join(", ", seriesOfStrings));
    }

}
