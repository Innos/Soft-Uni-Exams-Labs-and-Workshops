using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class DecryptTheMessage
{
    static void Main(string[] args)
    {
        char[] encryptedChars = new char[] { '+', '%', '&', '#', '$' };
        char[] decryptedChars = new char[] { ' ', ',', '.', '?', '!' };
        List<string> codedMessages = new List<string>();
        string start = Console.ReadLine();
        while(start.ToLower() != "start")
        {
            start = Console.ReadLine();
        }
        string message = Console.ReadLine();
        while(message.ToLower() != "end" )
        {
            char[] mes = message.ToCharArray();
            if(message != String.Empty)
            {
                for (int i = 0; i < mes.Length; i++)
                {
                    if (mes[i] >= 'A' && mes[i] <= 'M')
                    {
                        mes[i] = (char)(mes[i] + 13);
                    }
                    else if (mes[i] >= 'N' && mes[i] <= 'Z')
                    {
                        mes[i] = (char)(mes[i] - 13);
                    }
                    else if (mes[i] >= 'a' && mes[i] <= 'm')
                    {
                        mes[i] = (char)(mes[i] + 13);
                    }
                    else if (mes[i] >= 'n' && mes[i] <= 'z')
                    {
                        mes[i] = (char)(mes[i] - 13);
                    }
                    else if (encryptedChars.Contains(mes[i])) mes[i] = decryptedChars[Array.IndexOf(encryptedChars, mes[i])];
                }
                Array.Reverse(mes);
                codedMessages.Add(String.Join("",mes));
            }
            message = Console.ReadLine();
        }
        if(codedMessages.Count == 0)
        {
            Console.WriteLine("No message received.");
        }
        else
        {
            Console.WriteLine("Total number of messages: {0}",codedMessages.Count);
            foreach (var cMessage in codedMessages)
            {
                Console.WriteLine(cMessage);
            }
        }
    }
}

