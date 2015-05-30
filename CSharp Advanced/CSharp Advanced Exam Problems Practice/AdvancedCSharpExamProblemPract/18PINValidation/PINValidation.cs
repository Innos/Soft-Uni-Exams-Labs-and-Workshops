using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


class PINValidation
{
    static void Main(string[] args)
    {
        string name = Console.ReadLine();
        string sex = Console.ReadLine();
        string PIN = Console.ReadLine();
        if (nameCheck(name) && PINAndSexCheck(PIN, sex))
        {
            string result = @"{""name"":""" + name + @""",""gender"":""" + sex + @""",""pin"":""" + PIN + @"""}";
            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine("<h2>Incorrect data</h2>");
        }
    }

    static bool nameCheck(string name)
    {
        string namePattern = @"[A-Z][a-z]*\s[A-Z][a-z]*";
        if (Regex.IsMatch(name, namePattern))
        {
            return true;
        }
        return false;
    }


    static bool PINAndSexCheck(string pin, string sex)
    {
        string PINPattern = @"\d{10}";
        if (Regex.IsMatch(pin, PINPattern))
        {
            int month = int.Parse(pin.Substring(2, 2));
            int day = int.Parse(pin.Substring(4, 2));
            var numbers = pin.Substring(0, 9).Select(digit => int.Parse(digit.ToString())).ToArray();
            int checksum = ((numbers[0] * 2 + numbers[1] * 4 + numbers[2] * 8 + numbers[3] * 5 + numbers[4] * 10 + numbers[5] * 9 + numbers[6] * 7 + numbers[7] * 3 + numbers[8] * 6) % 11) % 10;
            bool isMale = ((numbers[8] % 2) == 0);
            int lastDigit = int.Parse(pin.Substring(9, 1));

            if (((month > 0 && month < 13) || (month > 20 && month < 33) || (month > 40 && month <= 53)) &&
                (day > 0 && day < 31) &&
                ((sex == "male" && isMale) || (sex == "female" && (!isMale))) &&
                checksum == lastDigit)
            {
                return true;
            }
        }
        return false;
    }
}

