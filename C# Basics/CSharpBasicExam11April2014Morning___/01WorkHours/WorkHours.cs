using System;

class WorkHours
{
    static void Main(string[] args)
    {
        int requiredHours = int.Parse(Console.ReadLine());
        double daysAvailable = double.Parse(Console.ReadLine());
        double productivity = double.Parse(Console.ReadLine());
        double usableHours = (daysAvailable * 0.9) * 12;
        int efficentHours = (int)(usableHours * (productivity/100));
        if (efficentHours - requiredHours < 0)
        {
            Console.WriteLine("No");
            Console.WriteLine("{0}",efficentHours - requiredHours);
        }
        else
        {
            Console.WriteLine("Yes");
            Console.WriteLine("{0}",efficentHours - requiredHours);
        }
    }
}

