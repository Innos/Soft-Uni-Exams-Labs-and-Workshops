using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Triangle
{
    static void Main(string[] args)
    {
        int Ax = int.Parse(Console.ReadLine());
        int Ay = int.Parse(Console.ReadLine());
        int Bx = int.Parse(Console.ReadLine());
        int By = int.Parse(Console.ReadLine());
        int Cx = int.Parse(Console.ReadLine());
        int Cy = int.Parse(Console.ReadLine());
        double sideA = Math.Sqrt(Math.Pow((Bx - Cx), 2) + Math.Pow((By - Cy), 2));
        double sideB = Math.Sqrt(Math.Pow((Ax - Cx), 2) + Math.Pow((Ay - Cy), 2));
        double sideC = Math.Sqrt(Math.Pow((Ax - Bx), 2) + Math.Pow((Ay - By), 2));
        if (sideA + sideB > sideC && sideB + sideC > sideA && sideA + sideC > sideB)
        {
            double halfPerimeter = (sideA + sideB + sideC) / 2;
            double area = Math.Sqrt(halfPerimeter * (halfPerimeter - sideA) * (halfPerimeter - sideB) * (halfPerimeter - sideC));
            Console.WriteLine("Yes \n{0:0.00}",area);
        }
        else
        {
            Console.WriteLine("No \n{0:0.00}",sideC);
        }
    }
}

