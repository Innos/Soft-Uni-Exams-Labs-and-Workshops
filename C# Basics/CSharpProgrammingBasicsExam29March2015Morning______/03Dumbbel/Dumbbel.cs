using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Dumbbel
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int width = n * 3;
        int sideSpace = n / 2;
        int dumbbel = n / 2 + 1;
        int inside = n / 2;
        for (int i = 0; i < n; i++)
        {
            if(i == 0 || i == n-1)
            {
                Console.WriteLine("{0}{1}{2}{1}{0}",new string('.',sideSpace),new string('&',dumbbel),new string('.',n));
            }
            else if (i == n/2)
            {
                Console.WriteLine("&{0}&{1}&{0}&",new string('*',inside),new string('=',n));
            }
            else if( i < n/2)
            {
                sideSpace -= 1;
                Console.WriteLine("{0}&{1}&{2}&{1}&{0}",new string('.',sideSpace),new string('*',inside),new string('.',n));
                inside += 1;
            }
            else if(i > n/2)
            {

                inside -= 1;
                Console.WriteLine("{0}&{1}&{2}&{1}&{0}", new string('.', sideSpace), new string('*', inside), new string('.', n));
                sideSpace += 1;
            }
        }
    }
}

