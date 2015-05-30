namespace BePositive
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Numerics;

    public class BePositiveMain
    {
        public static void Main()
        {
            int countSequences = int.Parse(Console.ReadLine());
            for (int i = 0; i < countSequences; i++)
            {
                string[] input = Console.ReadLine().Split(new char[]{' '},StringSplitOptions.RemoveEmptyEntries);
                var numbers = new List<int>();
                for (int j = 0; j < input.Length; j++)
                {
                    //we cut all empty spaces with StringSplitOptions so there is no need to check with if
                        int num = int.Parse(input[j]);
                        numbers.Add(num);
                }
                bool found = false;
                for (int j = 0; j < numbers.Count; j++)
                {
                    int currentNum = numbers[j];
                    if (currentNum >= 0)
                    {
                        if (found)
                        {
                            Console.Write(" ");
                        }
                        Console.Write(currentNum);
                        found = true;
                    }
                    else
                    {
                        if(j < numbers.Count -1)
                        {
                            //j+1 goes beyond numbers.Count
                            currentNum += numbers[j + 1];
                            if (currentNum >= 0)
                            {
                                if (found)
                                {
                                    Console.Write(" ");
                                }

                                Console.Write(currentNum);
                                found = true;
                            }
                            j = j + 1;
                        }
                    }
                }
                if (!found)
                {
                    Console.WriteLine("(empty)");
                }
                else
                {
                    //seperate results on different lines no need to do it for (empty) as it is already in Console.WriteLine
                    Console.WriteLine();
                }
            }
        }
    }
}