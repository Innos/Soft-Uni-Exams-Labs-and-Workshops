using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class InsideTheBuilding
{
    static void Main(string[] args)
    {
        double height = double.Parse(Console.ReadLine());
        double[] x = new double[5];
        double[] y = new double[5];
        for (int i = 0; i < 5; i++)
        {
            x[i] = double.Parse(Console.ReadLine());
            y[i] = double.Parse(Console.ReadLine());
            if (((x[i] >= 0 && x[i] <= height * 3) && (y[i] >= 0 && y[i] <= height)) || ((x[i] >= height && x[i] <= height * 2) && (y[i] >= height && y[i] <= height * 4)))
            {
                Console.WriteLine("inside");
            }
            else
            {
                Console.WriteLine("outside");
            }
        }

    }
}
