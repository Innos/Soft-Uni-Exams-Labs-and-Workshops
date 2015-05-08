using System;

class JoroTheFootballPlayer
{
    static void Main(string[] args)
    {
        string leapYear = Console.ReadLine();
        int holidays = int.Parse(Console.ReadLine());
        int hometownWeekends = int.Parse(Console.ReadLine());
        int normalWeekends = 52 - hometownWeekends;
        int plays = (normalWeekends * 2) / 3 + hometownWeekends + (holidays / 2);
        if (leapYear == "t")
        {
            plays = plays + 3;
        }
        Console.WriteLine(plays);
    }
}

