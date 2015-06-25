using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


class Durts
{
    static void Main(string[] args)
    {
        string[] centerCoordinates = Console.ReadLine().Split();
        int centerX = int.Parse(centerCoordinates[0]);
        int centerY = int.Parse(centerCoordinates[1]);
        int radius = int.Parse(Console.ReadLine());
        int numberOfShots = int.Parse(Console.ReadLine());
        string[] shots = Regex.Split(Console.ReadLine(), @"\s+");
        for (int i = 0; i < numberOfShots * 2; i = i + 2)
        {
            int shotX = int.Parse(shots[i]);
            int shotY = int.Parse(shots[i + 1]);
            int a = Math.Abs(shotX - centerX);
            int b = Math.Abs(shotY - centerY);
            if ((a <= radius && b <= radius / 2) || (a <= radius / 2 && b <= radius) && a + b <= radius + radius / 2)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}

