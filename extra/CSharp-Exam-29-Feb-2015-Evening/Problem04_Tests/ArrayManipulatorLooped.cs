using System;
using System.Collections.Generic;

class ArrayManipulatorLooped
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split('\\');

        char[] firstArr = input[0].ToCharArray();
        char[] secondArr = input[1].ToCharArray();
        string command = input[2];

        List<char> newArr = new List<char>();

        if (command == "join")
        {
            for (int i = 0; i < firstArr.Length; i++)
            {
                for (int j = 0; j < secondArr.Length; j++)
                {
                    if (firstArr[i] == secondArr[j])
                    {
                        newArr.Add(firstArr[i]);
                    }
                }
            }
        }
        else if (command == "right exclude")
        {
            ExecuteExtract(firstArr, secondArr, newArr);
        }
        else
        {
            ExecuteExtract(secondArr, firstArr, newArr);
        }


        newArr.Sort();
        foreach (var el in newArr)
        {
            Console.Write(el);
        }
    }

    private static void ExecuteExtract(char[] firstArr, char[] secondArr, List<char> newArr)
    {
        for (int i = 0; i < firstArr.Length; i++)
        {
            bool contains = false;
            for (int j = 0; j < secondArr.Length; j++)
            {
                if (firstArr[i] == secondArr[j])
                {
                    contains = true;
                }
            }

            if (!contains)
            {
                newArr.Add(firstArr[i]);
            }
        }
    }
}
