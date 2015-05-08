using System;

class Volleyball
{
    static void Main(string[] args)
    {
        string leapYear = Console.ReadLine();
        int holidays = int.Parse(Console.ReadLine());
        int hometownWeekends = int.Parse(Console.ReadLine());
        int normalWeekends = 48 - hometownWeekends;
        double plays = (normalWeekends * 3d / 4d) + (holidays * 2d / 3d) + (hometownWeekends * 1d);
        if (leapYear == "leap")
        {
            plays = plays * 1.15;
        }
        Console.WriteLine((int)plays);
    }
}

