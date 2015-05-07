using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class SpyHard
{
    static void Main(string[] args)
    {
        int baseSystem = int.Parse(Console.ReadLine());
        string message = Console.ReadLine().ToLower();
        int mLength = message.Length;
        int value = 0;
        foreach (var symbol in message)
        {
            if(symbol >= 'a' && symbol <= 'z')
            {
                value += (symbol - 'a' + 1);
            }
            else
            {
                value += symbol;
            }
        }
        string convertedValue = "";
        while (value > 0)
        {
            convertedValue = value % baseSystem + convertedValue;
            value = value / baseSystem;
        }
        string result = baseSystem.ToString() + mLength.ToString() + convertedValue;
        Console.WriteLine(result);
    }
}

