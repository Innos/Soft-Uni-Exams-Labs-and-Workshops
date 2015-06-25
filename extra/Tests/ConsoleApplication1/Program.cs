using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PythagoreanNumbers
{
    class PythagoreanNumbers
    {
        static void Main(string[] args)
        {
            for (int i = 0x2630; i <= 0x2630; i += 0x10)
            {
                for (int c = 0; c <= 0xF; ++c)
                {
                    Console.Write((char)(i + c));
                }

                Console.WriteLine();
            }

            Console.WriteLine((char)'\u263B');
            char[] shapes = { '\u2588', '\u2580', '\u2593', '\u2592', '\u2591' };
            foreach (var item in shapes)
            {
                Console.WriteLine(item);
            }
        }

    }
}
