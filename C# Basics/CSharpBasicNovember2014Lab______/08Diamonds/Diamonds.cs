using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Diamonds
{
    static void Main(string[] args)
    {
        int length = int.Parse(Console.ReadLine());
        for (int i = 0; i < length; i++)
        {
            if (i == 0 || i == length - 1)
            {
                int sideSpace = (length) / 2;
                Console.WriteLine("{0}*{0}", new string('-', sideSpace));
            }
            else if( i<= length/2)
            {
                int midSpace = i*2 -1;
                int sideSpace = (length - 2 - midSpace)/2;
                Console.WriteLine("{0}*{1}*{0}",new string('-',sideSpace),new string('-',midSpace));
            }
            else if(i > length/2)
            {
                int midSpace = ((length-1) - i) *2 -1;
                int sideSpace = (length -2 - midSpace)/2;
                Console.WriteLine("{0}*{1}*{0}",new string('-',sideSpace), new string('-',midSpace));
            }
        }
    }
}

