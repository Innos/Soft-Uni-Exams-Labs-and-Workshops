using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ExanSchedule
{
    static void Main(string[] args)
    {
        int startHour = int.Parse(Console.ReadLine());
        int startMinute = int.Parse(Console.ReadLine());
        string partOfDay = Console.ReadLine();
        int examHours = int.Parse(Console.ReadLine());
        int examMinutes = int.Parse(Console.ReadLine());
        string startTime = startHour + ":" + startMinute + " " + partOfDay;
        DateTime startExam = DateTime.Parse(startTime);
        startExam = startExam.AddHours(examHours);
        startExam = startExam.AddMinutes(examMinutes);
        Console.WriteLine(startExam.ToString("hh:mm:tt"));
    }
}

