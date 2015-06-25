using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car
{
    class Car
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            // Car roof
            string dots = new string('.', n);
            string asterix = new string('*', n);
            Console.WriteLine(dots+asterix+dots);
            for (int i = 0; i < n/2 - 1; i++)
            {
                string dotsOut = new string('.', n-1-i);
                string dotsIn = new string('.', n + i*2);
                Console.WriteLine(dotsOut + "*" + dotsIn + "*" + dotsOut);
            }

            //Car body
            asterix = new string('*', n/2 + 1);
            dots = new string('.', 3*n - 2*(n/2 + 1));
            Console.WriteLine(asterix+dots+asterix);
            for (int i = 0; i < n/2 - 2; i++)
            {
                dots = new string('.', 3*n - 2);
                Console.WriteLine("*" + dots + "*");
            }
            asterix = new string('*', 3 * n);
            Console.WriteLine(asterix);

            //Car tyres
            for (int i = 0; i < n/2 - 2; i++)
            {
                dots = new string('.', n / 2);
                string dotsIn = new string('.', n/2 - 1);
                Console.WriteLine(dots + "*" + dotsIn + "*" + dotsIn + dotsIn + "*" + dotsIn + "*" + dots);
            }
            asterix = new string('*', n / 2 + 1);
            string dotsBetween = new string('.', 2 * (n/2 - 1));
            Console.WriteLine(dots + asterix + dotsBetween + asterix + dots);
        }
    }
}
