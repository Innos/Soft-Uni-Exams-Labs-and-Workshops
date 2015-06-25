using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitBuilder
{
    class BitBuilder
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            while(true)
            {
                string input = Console.ReadLine();
                if (input=="quit")
                {
                    break;
                }
                int a = int.Parse(input);
                string order = Console.ReadLine();

                switch (order)
                {
                    case "flip":
                        n = FlipBit(n, a);
                        break;
                    case "insert":
                        n = InsertBit(n, a);
                        break;
                    case "remove":
                        n = RemoveBit(n, a);
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(n);
        }

        static int RemoveBit(int n, int a)
        {
            int result = 0;
            int addition = 0;
            for (int i = 0; i < 32; i++)
            {
                int mask = 1 << i;
                if (i == a)
                {
                    addition = 1;
                    continue;
                }
                result += (n & mask) >> addition;
            }
            return result;
        }

        static int InsertBit(int n, int a)
        {
            int result = 0;
            int addition = 0;
            for (int i = 0; i < 32; i++)
            {
                
                int mask = 1 << i;
                if (i == a)
                {
                    result += 1 << a;
                    addition = 1;
                }
                result += (n & mask) << addition;
            }
            return result;
        }

        static int FlipBit(int n, int a)
        {
            int mask = 1 << a;
            
            int bit = mask & n;
            if (bit == 1)
            {
                n = n & ~mask;
            }
            else
            {
                n = n | mask;
            }
            return n;
        }
    }
}
