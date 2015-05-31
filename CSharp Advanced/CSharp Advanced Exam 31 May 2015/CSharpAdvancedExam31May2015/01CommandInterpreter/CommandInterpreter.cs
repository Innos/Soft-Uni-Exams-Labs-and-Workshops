using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class CommandInterpreter
{
    static void Main(string[] args)
    {
        StringBuilder sb = new StringBuilder();
        string input = Console.ReadLine();
        List<string> collection = collection = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        while ((input = Console.ReadLine()) != "end")
        {
            int start;
            int count;
            string tempString;
            List<string> temp = new List<string>();
            string[] commands = input.Split();
            switch (commands[0])
            {
                case "reverse":
                    start = int.Parse(commands[2]);
                    count = int.Parse(commands[4]);
                    if (IsValidOrder(collection, start, count))
                    {
                        for (int i = start; i < start + count; i++)
                        {
                            temp.Add(collection[i]);
                        }
                        temp.Reverse();
                        collection.RemoveRange(start, count);
                        collection.InsertRange(start, temp);
                    }
                    else
                    {
                        sb.AppendLine("Invalid input parameters.");
                    }
                    break;
                case "sort":
                    start = int.Parse(commands[2]);
                    count = int.Parse(commands[4]);
                    if (IsValidOrder(collection, start, count))
                    {
                        for (int i = start; i < start + count; i++)
                        {
                            temp.Add(collection[i]);
                        }
                        temp.Sort();
                        collection.RemoveRange(start, count);
                        collection.InsertRange(start, temp);
                    }
                    else
                    {
                        sb.AppendLine("Invalid input parameters.");
                    }
                    break;
                case "rollLeft":
                    count = int.Parse(commands[1]);
                    if (IsValidRoll(collection, count))
                    {
                        for (int i = 0; i < (count%collection.Count); i++)
                        {
                            tempString = collection[0];
                            for (int l = 0; l < collection.Count - 1; l++)
                            {
                                collection[l] = collection[l + 1];
                            }
                            collection[collection.Count - 1] = tempString;
                        }
                    }
                    else
                    {
                        sb.AppendLine("Invalid input parameters.");
                    }
                    break;
                case "rollRight":
                    count = int.Parse(commands[1]);
                    if (IsValidRoll(collection, count))
                    {
                        for (int i = 0; i < (count % collection.Count); i++)
                        {
                            tempString = collection.Last();
                            for (int l = collection.Count - 1; l > 0; l--)
                            {
                                collection[l] = collection[l - 1];
                            }
                            collection[0] = tempString;
                        }
                    }
                    else
                    {
                        sb.AppendLine("Invalid input parameters.");
                    }
                    break;
            }
        }
        Console.Write(sb.ToString());
        Console.WriteLine("[{0}]", String.Join(", ", collection));
    }
    static bool IsValidOrder(List<string> collection, int start, int count)
    {
        if (start < 0 || start >= collection.Count ||
            count < 0 ||
            start + count > collection.Count)
        {
            return false;
        }
        return true;
    }
    static bool IsValidRoll(List<string> collection, int count)
    {
        if (count < 0)
        {
            return false;
        }
        return true;
    }
}

