using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class EncryptTheMessage
{
    static void Main(string[] args)
    {
        List<string> codedMessages = new List<string>();
        char[] symbolsToChange = new char[] { ' ', ',', '.', '?', '!' };
        char[] newChars = new char[] { '+', '%', '&', '#', '$', };
        string start = Console.ReadLine();
        while (start.ToLower() != "start")
        {
            start = Console.ReadLine();
        }
        string message = Console.ReadLine();
        while (message.ToLower() != "end")
        {
            char[] temp = message.ToCharArray();
            if (message == String.Empty)
            {
            }
            else
            {
                for (int i = 0; i < message.Length; i++)
                {
                    if (temp[i] >= 'A' && temp[i] <= 'M')
                    {
                        temp[i] = (char)(temp[i] + ('N' - 'A'));
                    }
                    else if (temp[i] >= 'N' && temp[i] <= 'Z')
                    {
                        temp[i] = (char)(temp[i] - ('N' - 'A'));
                    }
                    else if (temp[i] >= 'a' && temp[i] <= 'm')
                    {
                        temp[i] = (char)(temp[i] + ('n' - 'a'));
                    }
                    else if (temp[i] >= 'n' && temp[i] <= 'z')
                    {
                        temp[i] = (char)(temp[i] - ('n' - 'a'));
                    }
                    else if (symbolsToChange.Contains(temp[i])) temp[i] = newChars[Array.IndexOf(symbolsToChange, temp[i])];
   
                }
                Array.Reverse(temp);
                codedMessages.Add(String.Join("", temp));

            }
            message = Console.ReadLine();
        }
        if (codedMessages.Count == 0)
        {
            Console.WriteLine("No messages sent.");
        }
        else
        {
            Console.WriteLine("Total number of messages: {0}", codedMessages.Count);
            foreach (var cMessage in codedMessages)
            {
                Console.WriteLine(cMessage);
            }
        }
    }
}

