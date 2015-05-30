using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



class SchoolSystem
{
    static void Main(string[] args)
    {
        int lines = int.Parse(Console.ReadLine());
        SortedDictionary<string, SortedDictionary<string,List<int>>> students = new SortedDictionary<string, SortedDictionary<string,List<int>>>();
        for (int i = 0; i < lines; i++)
        {
            string input = Console.ReadLine();
            string[] tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string fullName = tokens[0] + " " + tokens[1];
            string subjectName = tokens[2];
            int grade = int.Parse(tokens[3]);
            if (!students.ContainsKey(fullName))
            {
                students.Add(fullName,new SortedDictionary<string,List<int>>());
            }
            if(!students[fullName].ContainsKey(subjectName))
            {
                students[fullName].Add(subjectName, new List<int>());
            }
            students[fullName][subjectName].Add(grade);
        }

        StringBuilder sb = new StringBuilder();
        foreach (var student in students)
        {
            var sub = student.Value.Select(x => x.Key + " - " + x.Value.Average().ToString("0.00")).Aggregate((x, y)=> x + ", " + y);
            sb.AppendLine(String.Format("{0}: [{1}]", student.Key, sub));
        }
        Console.Write(sb.ToString());
    }
}

