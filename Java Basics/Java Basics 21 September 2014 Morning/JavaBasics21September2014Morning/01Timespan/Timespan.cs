using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Timespan
{
    static void Main(string[] args)
    {
        int[] startTokens = Array.ConvertAll(Console.ReadLine().Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
        int[] endTokens = Array.ConvertAll(Console.ReadLine().Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
        TimeSpan start = new TimeSpan(startTokens[0], startTokens[1], startTokens[2]);
        TimeSpan end = new TimeSpan(endTokens[0], endTokens[1], endTokens[2]);
        TimeSpan time = start.Subtract(end);
        Console.WriteLine("{0}:{1:00}:{2:00}",(int)time.TotalHours,time.Minutes,time.Seconds);
    }
}

