namespace Arrays
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ArraysMain
    {
        private const char ArgumentsDelimiter = ' ';
        public static void Main()
        {
            int sizeOfArray = int.Parse(Console.ReadLine());
            long[] array = Console.ReadLine()
                .Split(ArgumentsDelimiter)
                .Select(long.Parse)
                .ToArray();

            string command = Console.ReadLine();

            while (!command.Equals("stop"))
            {
                string[] line = command.Split();
                int[] args = new int[2];

                if (line[0].Equals("lshift") ||
                    line[0].Equals("rshift"))
                {

                }
                else if (line[0].Equals("add") ||
                    line[0].Equals("subtract") ||
                    line[0].Equals("multiply"))
                {

                    args[0] = int.Parse(line[1]);
                    args[1] = int.Parse(line[2]);


                }

                PerformAction(array, line[0], args);
                PrintArray(array);
                Console.WriteLine();
                command = Console.ReadLine();
            }
        }

        static void PerformAction(long[] array, string action, int[] args)
        {
            int pos = args[0] - 1;
            int value = args[1];

            switch (action)
            {
                case "multiply":
                    array[pos] *= value;
                    break;
                case "add":
                    array[pos] += value;
                    break;
                case "subtract":
                    array[pos] -= value;
                    break;
                case "lshift":
                    ArrayShiftLeft(array);
                    break;
                case "rshift":
                    ArrayShiftRight(array);
                    break;
            }
        }

        private static void ArrayShiftRight(long[] array)
        {
            long temp = array.Last();
            for (int i = array.Length - 1; i >= 1; i--)
            {
                array[i] = array[i - 1];
            }
            array[0] = temp;
        }

        private static void ArrayShiftLeft(long[] array)
        {
            long temp = array.First();
            for (int i = 0; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }
            array[array.Length - 1] = temp;
        }

        private static void PrintArray(long[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}
