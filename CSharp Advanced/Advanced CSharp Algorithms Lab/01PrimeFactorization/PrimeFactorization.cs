using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class PrimeFactorization
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int number = n;
        List<int> primes = new List<int>();
        for (int i = 2; i <= number ; i++)
        {
            while(number % i == 0 && number > 1)
            {
                primes.Add(i);
                number = number / i;
            }
        }
            Console.WriteLine("{0} = {1}", n, String.Join(" * ", primes));
    }
}

